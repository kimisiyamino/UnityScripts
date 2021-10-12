// code by EleonoraLion
//
// Рандомное вращение объекта по оси с изменением цвета туда сюда(Mathf.PingPong), путём интерполяции
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public bool isRotate = false;
    public float rotateX;
    public float rotateY;
    public float rotateZ;

    public Material material1;
    public Material material2;
    public float Interpol, Duration, Speed;

    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (isRotate)
            transform.Rotate(Random.Range(0, rotateX), Random.Range(0, rotateY), Random.Range(0, rotateZ));

        Interpol = Mathf.PingPong(Time.time * Speed, Duration);
        renderer.material.Lerp(material1, material2, Interpol);
    }
}
