using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
  [SerializeField] float hitPoints = 100f;

  public void TakeDamage(float damage)
  {
    // calls the method you pass in as a string on every script attached to the gameobject (or it's children) this one is attached to
    BroadcastMessage("OnDamageTaken");
    hitPoints -= damage;
    if (hitPoints <= 0)
    {
      Destroy(this.gameObject);
    }
  }
}
