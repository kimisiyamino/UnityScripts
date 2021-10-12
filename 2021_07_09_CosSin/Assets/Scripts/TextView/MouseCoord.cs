using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCoord : MonoBehaviour
{
    void Update()
    {
        string coords = "Mouse: \n" + Input.mousePosition.x.ToString("0.00") + " " + Input.mousePosition.y.ToString("0.00");
        GetComponent<TextMesh>().text = coords;
    }
}
