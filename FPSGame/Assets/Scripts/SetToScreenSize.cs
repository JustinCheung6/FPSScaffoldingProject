using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetToScreenSize : MonoBehaviour
{
    private RectTransform rectTrans;
    private void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        rectTrans.localScale = new Vector2(Screen.width, Screen.height);
    }
}
