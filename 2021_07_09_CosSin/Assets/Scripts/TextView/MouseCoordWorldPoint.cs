using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCoordWorldPoint : MonoBehaviour
{
    void Update()
    {
        GetComponent<TextMesh>().text = Camera.main.ScreenToWorldPoint(Input.mousePosition).ToString();
    }
}
