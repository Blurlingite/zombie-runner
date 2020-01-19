using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
  [SerializeField] float lightDecay = 0.1f;
  [SerializeField] float angleDecay = 1.0f;
  // so the light doesn't get too small
  [SerializeField] float minimumAngle = 40f;

  Light myLight;


  void Start()
  {
    myLight = GetComponent<Light>();
  }

  void Update()
  {
    DecreaseLightAngle();
    DecreaseLightIntensity();
  }

  public void RestoreLightAngle(float restoreAngle)
  {
    myLight.spotAngle = restoreAngle;
  }

  public void AddLightIntensity(float intensityAmount)
  {
    myLight.intensity += intensityAmount;
  }

  private void DecreaseLightAngle()
  {
    if (myLight.spotAngle <= minimumAngle)
    {
      return;
    }
    else
    {
      myLight.spotAngle -= angleDecay * Time.deltaTime;
    }
  }

  private void DecreaseLightIntensity()
  {
    myLight.intensity -= lightDecay * Time.deltaTime;
  }
}
