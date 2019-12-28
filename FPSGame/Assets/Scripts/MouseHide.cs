using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Press Ctrl + P to stop the game.");
        Debug.Log("Press Ctrl + Shift + P to pause the game.");

        //Lock the mouse from moving and hide it from the player
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
