//
// https://ru.stackoverflow.com/questions/533735/unity-5-движение-по-кругу-через-поворот
//
//



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround0 : MonoBehaviour
{
    [Header("cos/sin Rotate around 0")]
    [Space(10)]
    public bool isCircle = false; // условие движения по кругу
    public float angle = 0; // угол 
    public float radius = 0.5f; // радиус
    public float speed = 0.5f;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCircle)
        {
            angle += Time.deltaTime; // меняется плавно значение угла

            var x = Mathf.Cos(angle * speed) * radius;
            var y = Mathf.Sin(angle * speed) * radius;
            transform.position = new Vector2(x, y);
        }
    }
}
