using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

  // how close to the enemy the player has to be for the enemy to start chasing them
  [SerializeField] float chaseRange = 10f;
  [SerializeField] float turnSpeed = 5f;

  NavMeshAgent navMeshAgent;
  // we want to intialize this as a giant number so the enemy doesn't chase the player right away
  float distanceToTarget = Mathf.Infinity;
  bool isProvoked = false;
  Transform target;
  EnemyHealth health;

  void Start()
  {
    navMeshAgent = GetComponent<NavMeshAgent>();
    health = GetComponent<EnemyHealth>();

    target = FindObjectOfType<PlayerHealth>().transform;

  }

  void Update()
  {
    if (health.IsDead())
    {
      // disable this script so enemy can't move
      this.enabled = false;
      // also need to disable nav mesh agent b/c it will still keep calculating and running when active 
      navMeshAgent.enabled = false;
    }
    // calculate distance from player(the target) to enemy (this object)
    distanceToTarget = Vector3.Distance(target.position, transform.position);

    // if the zombie is provoked(by shooting it)
    if (isProvoked)
    {
      EngageTarget();
    }

    // if the distance the player is from enemy is less than the chase range, start chasing the player
    else if (distanceToTarget <= chaseRange)
    {
      // set to true so even if you leave the chase range, the zombie will still chase you. So once you've entered the chase range at least once, it will keep chasing you
      isProvoked = true;

    }

  }

  public void OnDamageTaken()
  {
    isProvoked = true;
  }

  private void EngageTarget()
  {
    // rather than using FaceTarget() in ChaseTarget() & AttackTarget(), we can use it once here. As soon as you engage the target, you shoould be facing the target
    FaceTarget();
    // stoppingDistance is how far away from it's target the enemy will be once it reaches it's target. So if it is set to 1, the enemy will move towards the target until there is 1 unit of space between it and the target
    // Since distanceToTarget is the space between the player and enemy and as long as it is greater than the stoppingDistance, the enemy will engage the player by moving towards it until it reaches the stoppingDistance
    if (distanceToTarget >= navMeshAgent.stoppingDistance)
    {
      ChaseTarget();
    }

    // If we are close enough to the player, attack them
    if (distanceToTarget <= navMeshAgent.stoppingDistance)
    {
      AttackTarget();
    }
  }

  // This is where we transition from Idle state to the Move state(animation)
  private void ChaseTarget()
  {
    // see AttackTarget() for more comments
    // We set attack animation to false in the case we have just attacked and the player leaves the chase radius. That means we need to move again, which means we can't attack while chasing the player(at least in hand to hand combat)
    GetComponent<Animator>().SetBool("attack", false);

    // SetTrigger() lets you trigger an animation by it's name or id
    GetComponent<Animator>().SetTrigger("move");
    // Set the destination of the Nav Mesh Agent to be wherever the player (the target) currently is
    navMeshAgent.SetDestination(target.position);
  }

  // This is where we transition from Move state to the Attack state(animation)
  private void AttackTarget()
  {
    // activate attack animation, since it's a bool, we use SetBool() which takes in the name of the animation (attack) and true(to activate it in this case) or false(to deactivate it in this case b/c of how we set up the attack animation in the Animator, It only activates the attack animation if the bool is true)
    GetComponent<Animator>().SetBool("attack", true);
  }

  private void FaceTarget()
  {

    // we need to find the direction, not the distance the player is from the enemy so we use "normalized". That will return a magnitude of 1(instead of what the subtraction below results in) and will also keep the direction 
    Vector3 direction = (target.position - transform.position).normalized;

    // pass in 0 for y so enemy doesn't rotate up or down
    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
    // transform.rotation = where target is, we need to rotate at a certain speed
    // Quaternion.Slerp() takes in 2 Quaternions and a float(for speed). It will create a smooth rotation between the 2 Quaternions.
    // transform.rotation is the enemy's current rotation.
    // lookRotation is the rotation the enemy needs to be to be facing the player, that was calculated above
    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);

  }

  // this method listens for when this object (an object with this script) is selected
  void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.red;
    // params: the center of the object, the radius(or range) of how large the sphere will be
    Gizmos.DrawWireSphere(transform.position, chaseRange);
  }
}
