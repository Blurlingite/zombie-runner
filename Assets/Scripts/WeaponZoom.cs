using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
  [SerializeField] Camera fpsCamera;
  [SerializeField] float zoomedOutFOV = 60f; // regular field of vision
  [SerializeField] float zoomedInFOV = 20f; // zoomed field of vision
  [SerializeField] float zoomOutSensitivity = 2f;
  [SerializeField] float zoomInSensitivity = 0.5f;


  bool zoomedInToggle = false;
  RigidbodyFirstPersonController fpsController;

  void Start()
  {
    fpsController = GetComponent<RigidbodyFirstPersonController>();
  }

  void Update()
  {
    // If you press the right mouse button or the Z key, change bool to true and zoom in
    if (Input.GetMouseButton(1) || Input.GetKeyDown(KeyCode.Z))
    {
      if (zoomedInToggle == false)
      {
        zoomedInToggle = true;
        fpsCamera.fieldOfView = zoomedInFOV;
        fpsController.mouseLook.XSensitivity = zoomInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomInSensitivity;
      }
      else
      {
        zoomedInToggle = false;
        fpsCamera.fieldOfView = zoomedOutFOV;
        fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
      }
    }
  }



}

