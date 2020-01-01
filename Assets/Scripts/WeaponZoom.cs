using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
  [SerializeField] Camera fpsCamera;
  [SerializeField] RigidbodyFirstPersonController fpsController;
  [SerializeField] float zoomedOutFOV = 60f; // regular field of vision
  [SerializeField] float zoomedInFOV = 20f; // zoomed field of vision
  [SerializeField] float zoomOutSensitivity = 2f;
  [SerializeField] float zoomInSensitivity = 0.5f;

  bool zoomedInToggle = false;

  void OnDisable()
  {
    // when you leave the weapon (b/c OnDisable() runs when the object this script is attached to is disabled), zoom out
    // this fixes the bug where you zoom in and switch to a different weapon and are still zoomed in
    ZoomOut();
  }

  void Update()
  {
    // If you press the right mouse button or the Z key, change bool to true and zoom in
    if (Input.GetMouseButton(1) || Input.GetKeyDown(KeyCode.Z))
    {
      if (zoomedInToggle == false)
      {
        ZoomIn();
      }
      else
      {
        ZoomOut();
      }
    }
  }

  private void ZoomIn()
  {
    zoomedInToggle = true;
    fpsCamera.fieldOfView = zoomedInFOV;
    fpsController.mouseLook.XSensitivity = zoomInSensitivity;
    fpsController.mouseLook.YSensitivity = zoomInSensitivity;
  }

  private void ZoomOut()
  {
    zoomedInToggle = false;
    fpsCamera.fieldOfView = zoomedOutFOV;
    fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
    fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
  }


}

