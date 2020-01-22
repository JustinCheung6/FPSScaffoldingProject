using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetToScreenSize : MonoBehaviour
{
    private RectTransform rectTrans;
    private void Start()
    {
        //This will expand an image to the UI screen
        rectTrans = GetComponent<RectTransform>();
        rectTrans.localScale = new Vector2(Screen.width, Screen.height);
    }
}
