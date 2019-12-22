using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

  [SerializeField] Camera FPCamera;

  [SerializeField] float range = 100f;
  [SerializeField] float damage = 30f;


  void Update()
  {

    if (Input.GetButtonDown("Fire1"))
    {
      Shoot();
    }

  }

  private void Shoot()
  {
    RaycastHit hit;

    if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
    {
      Debug.Log("I hit this thing: " + hit.transform.name);
      // TODO: Add hit effect visual
      EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
      // call a method to decrease enemy health
      // If you shoot something that is not an enemy (doesn't have EnemyHealth script), return to avoid null exception
      if (target == null) return;
      target.TakeDamage(damage);
    }
    else
    {
      // If you shoot the sky and get a null exception, just return to avoid triggering the null exception
      return;
    }

  }
}
