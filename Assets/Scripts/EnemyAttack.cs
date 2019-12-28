using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
  [SerializeField] Transform target;
  [SerializeField] float damage = 40f;


  void Start()
  {

  }

  // called from our Animation event we placed in the Animation window for the Enemy's attack state
  public void AttackHitEvent()
  {
    if (target == null) return;
    Debug.Log("bang bang");
  }

}
