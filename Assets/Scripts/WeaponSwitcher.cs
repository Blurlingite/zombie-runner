using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
  [SerializeField] int currentWeapon = 0;



  void Start()
  {
    SetWeaponActive();
  }

  void Update()
  {
    int previousWeapon = currentWeapon;

    // for keyboard users
    ProcessKeyInput();
    // for mouse scrollwheel users, but will throw an exception if there is no scrollwheel on that computer, which is why it is commented out now
    // ProcessScrollWheel();

    // currentWeapon may change due to the above methods according to user input. If it does, this if statement will execute so we can switch to the weapon the user chose
    if (previousWeapon != currentWeapon)
    {
      SetWeaponActive();
    }
  }
  // only keyboard users can see this method working
  private void ProcessKeyInput()
  {
    // if you press the "1" key
    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
      currentWeapon = 0;
    }

    if (Input.GetKeyDown(KeyCode.Alpha2))
    {
      currentWeapon = 1;
    }

    if (Input.GetKeyDown(KeyCode.Alpha3))
    {
      currentWeapon = 2;
    }
  }
  // only mouse users can see this method working
  private void ProcessScrollWheel()
  {
    // access the axis the scroll wheel belongs to
    // if you scroll upwards
    if (Input.GetAxis("Mouse ScollWheel") < 0)
    {
      // if we are at the maximum, go back to 0
      if (currentWeapon >= transform.childCount - 1)
      {
        currentWeapon = 0;
      }
      else
      {
        currentWeapon++;
      }
    }

    // if you scroll downwards
    if (Input.GetAxis("Mouse ScrollWheel") > 0)
    {
      // if we are at the maximum, go back to 0
      if (currentWeapon <= 0)
      {
        // return to the weapon with the highest index (3-1 = 2)
        currentWeapon = transform.childCount - 1;
      }
      else
      {
        currentWeapon--;
      }
    }

  }



  private void SetWeaponActive()
  {
    int weaponIndex = 0;

    // go through each weapon and set active the weapon whose index is equal to currentWeapon
    // "transform" is the transform of the object this script is attached to
    foreach (Transform weapon in transform)
    {
      if (weaponIndex == currentWeapon)
      {
        weapon.gameObject.SetActive(true);
      }
      else
      {
        weapon.gameObject.SetActive(false);
      }
      // if we don't increment, all weapons will be active
      weaponIndex++;
    }

  }
}
