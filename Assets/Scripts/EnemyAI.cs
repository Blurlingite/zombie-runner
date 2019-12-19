using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{


  [SerializeField] Transform target;
  // how close to the enemy the player has to be for the enemy to start chasing them
  [SerializeField] float chaseRange = 5f;

  NavMeshAgent navMeshAgent;
  // we want to intialize this as a giant number so the enemy doesn't chase the player right away
  float distanceToTarget = Mathf.Infinity;

  void Start()
  {
    navMeshAgent = GetComponent<NavMeshAgent>();
  }

  void Update()
  {
    // calculate distance from player(the target) to enemy (this object)
    distanceToTarget = Vector3.Distance(target.position, transform.position);

    // if the distance the player is from enemy is less than the chase range, start chasing the player
    if (distanceToTarget <= chaseRange)
    {
      // each frame move (if in range) by setting the destination of the Nav Mesh Agent to be wherever the player currently is
      navMeshAgent.SetDestination(target.position);
    }

  }
}
