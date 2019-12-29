using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
  [SerializeField] Camera fpsCamera;
  [SerializeField] float zoomedOutFOV = 60f; // regular field of vision
  [SerializeField] float zoomedInFOV = 20f; // zoomed field of vision

  bool zoomedInToggle = false;

  void Update()
  {
    // If you press the right mouse button or the Z key, change bool to true and zoom in
    if (Input.GetMouseButton(1) || Input.GetKeyDown(KeyCode.Z))
    {
      if (zoomedInToggle == false)
      {
        zoomedInToggle = true;
        fpsCamera.fieldOfView = zoomedInFOV;
      }
      else
      {
        zoomedInToggle = false;
        fpsCamera.fieldOfView = zoomedOutFOV;
      }
    }
  }



}

