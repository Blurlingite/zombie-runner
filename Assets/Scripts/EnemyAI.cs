using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{


  [SerializeField] Transform target;
  // how close to the enemy the player has to be for the enemy to start chasing them
  [SerializeField] float chaseRange = 10f;

  NavMeshAgent navMeshAgent;
  // we want to intialize this as a giant number so the enemy doesn't chase the player right away
  float distanceToTarget = Mathf.Infinity;
  bool isProvoked = false;
  void Start()
  {
    navMeshAgent = GetComponent<NavMeshAgent>();
  }

  void Update()
  {
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

  private void EngageTarget()
  {
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

    Debug.Log(name + " ATTACKS " + target.name);
  }



  // this method listens for when this object (an object with this script) is selected
  void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.red;
    // params: the center of the object, the radius(or range) of how large the sphere will be
    Gizmos.DrawWireSphere(transform.position, chaseRange);
  }
}
