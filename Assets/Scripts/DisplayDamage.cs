using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
  [SerializeField] Canvas impactCanvas;
  [SerializeField] float impactTime = 0.3f;
  // GameObject damageReceivedCanvas;

  void Start()
  {
    // damageReceivedCanvas = GameObject.Find("Damage Received Canvas");
    // damageReceivedCanvas.SetActive(false);
    impactCanvas.enabled = false;
  }

  public void ShowDamageImpact()
  {
    StartCoroutine(ShowSplatter());
  }

  IEnumerator ShowSplatter()
  {
    impactCanvas.enabled = true;
    // damageReceivedCanvas.SetActive(true);

    yield return new WaitForSeconds(impactTime);
    impactCanvas.enabled = false;
    // damageReceivedCanvas.SetActive(false);
  }
}
