using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

  [SerializeField] Camera FPCamera;
  [SerializeField] float range = 100f;
  [SerializeField] float damage = 30f;
  [SerializeField] ParticleSystem muzzleFlash;
  [SerializeField] GameObject hitEffect;
  [SerializeField] Ammo ammoSlot;
  // type of ammo this weapon can use
  [SerializeField] AmmoType ammoType;


  bool canShoot = true;
  [SerializeField] float timeBetweenShots = 0.5f;

  // when this script is enabled, this method executes
  private void OnEnable()
  {
    canShoot = true;
  }

  void Update()
  {
    if ((Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0)) && canShoot == true)
    {
      StartCoroutine(Shoot());
    }
  }

  IEnumerator Shoot()
  {
    canShoot = false;

    if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
    {
      PlayMuzzleFlash();
      ProcessRaycast();
      ammoSlot.ReduceCurrentAmmo(ammoType);
    }

    yield return new WaitForSeconds(timeBetweenShots);
    canShoot = true;
  }

  private void PlayMuzzleFlash()
  {
    muzzleFlash.Play();
  }

  private void ProcessRaycast()
  {
    RaycastHit hit;

    if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
    {
      CreateHitImpact(hit);
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

  private void CreateHitImpact(RaycastHit hit)
  {
    // you can choose the direction the gameobject is instanitated (like having the explosion go towards the camera) with Quaternion.LookRotation()
    GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));

    Destroy(impact, .1f);
  }
}
