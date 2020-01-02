using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
  [SerializeField] float hitPoints = 100f;

  bool isDead = false;

  public bool IsDead()
  {
    return isDead;
  }

  public void TakeDamage(float damage)
  {
    // calls the method you pass in as a string on every script attached to the gameobject (or it's children) this one is attached to
    BroadcastMessage("OnDamageTaken");
    hitPoints -= damage;
    if (hitPoints <= 0)
    {
      Die();
    }
  }

  private void Die()
  {
    // if already dead, return so you can't keep killing the same enemy
    if (isDead) return;
    isDead = true;
    GetComponent<Animator>().SetTrigger("die");
  }
}
