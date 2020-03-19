using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenToggle : MonoBehaviour
{

    void Update()
    {
        if (Screen.fullScreen && Input.GetKeyDown(KeyCode.Escape))
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }

    }
}
