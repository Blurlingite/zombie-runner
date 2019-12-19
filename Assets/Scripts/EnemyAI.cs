using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{


  [SerializeField] Transform target;

  NavMeshAgent navMeshAgent;
  // Start is called before the first frame update
  void Start()
  {
    navMeshAgent = GetComponent<NavMeshAgent>();
  }

  // Update is called once per frame
  void Update()
  {
    // each frame move by setting the destination of the Nav Mesh Agent to be wherever the player currently is

    navMeshAgent.SetDestination(target.position);
  }
}
