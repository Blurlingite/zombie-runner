using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
  [SerializeField] AmmoSlot[] ammoSlots;
  // This class can only be accessed by the Ammo class since it is private
  // Ammo class can access the private AmmoSlot's public variables
  // [System.Serializable] allows you to see this class' content in Unity's inspector
  [System.Serializable]
  private class AmmoSlot
  {
    public AmmoType ammoType;
    public int ammoAmount;
  }

  public int GetCurrentAmmo(AmmoType ammoType)
  {
    // use the GetAmmoSlot() to get the ammo slot and then you can get the ammoAmount of that particular ammo slot
    return GetAmmoSlot(ammoType).ammoAmount;
  }

  public void ReduceCurrentAmmo(AmmoType ammoType)
  {
    // After getting the ammo slot, reduce ammo amount
    GetAmmoSlot(ammoType).ammoAmount--;
  }

  // cycles through the ammo slots (the AmmoSlots array) and return the ammo type that matches the one you passed in (ex. bullets with an amount of 10, etc.)
  private AmmoSlot GetAmmoSlot(AmmoType ammoType)
  {
    foreach (AmmoSlot slot in ammoSlots)
    {
      if (slot.ammoType == ammoType)
      {
        return slot;
      }
    }
    // if we didn't get an ammo slot back, return null so we know to check here
    return null;
  }

}
