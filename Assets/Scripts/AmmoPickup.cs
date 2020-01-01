using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

  [SerializeField] int ammoAmount = 5;
  // will be assigned in Unity inspector so you can pass it in to the methods in this script
  [SerializeField] AmmoType ammoType;


  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType, ammoAmount);
      Destroy(this.gameObject);
    }
  }
}
