using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
  PlayerHealth target;
  [SerializeField] float damage = 40f;


  void Start()
  {
    target = FindObjectOfType<PlayerHealth>();
  }

  // called from our Animation event we placed in the Animation window for the Enemy's attack state
  public void AttackHitEvent()
  {
    if (target == null) return;
    target.TakeDamage(damage);
    Debug.Log("bang bang");
  }

}
