using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
  [SerializeField] Canvas gameOverCanvas;


  private void Start()
  {
    gameOverCanvas.enabled = false;
  }

  public void HandleDeath()
  {
    gameOverCanvas.enabled = true;
    // freeze time so game doesn't keep playing while Game Over UI is displayed
    Time.timeScale = 0;
    // disable weapon switching when player is dead
    FindObjectOfType<WeaponSwitcher>().enabled = false;
    // makes the mouse cursor stop reacting to the game so we can click on things(the equivalent of pressing the ESCAPE key)
    Cursor.lockState = CursorLockMode.None;
    // makes the mouse cursor visible
    Cursor.visible = true;
  }
}
