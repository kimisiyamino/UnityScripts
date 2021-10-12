using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    private GameObject cameraPos;

    void Start()
    {
        cameraPos = GameObject.FindGameObjectWithTag("CameraObject");
    }

    void Update()
    {
        // Всегда поворачиваем меню к камере
        transform.rotation = Quaternion.Euler(45f, cameraPos.transform.eulerAngles.y, 0f);
    }
}
