// Code by EleonoraLion
//
// Вращение объекта вокруг target через косинус и синус
// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundSinCos : MonoBehaviour
{
    public bool isCircle = false; // условие движения по кругу

    public float angle = 0; // угол 
    public float radius = 0.5f; // радиус
    public float speed = 0.5f;

    public Transform target;

    public bool isPrint;

    private float x, y, cosX, cosY, cosXRadius, cosYRadius, endX, endY;


    void Start()
    {
        if(isPrint)
            StartCoroutine(COUT());
    }

   
    void Update()
    {
        if (isCircle)
        {
            angle += Time.deltaTime; // меняется плавно значение угла
            angle %= Mathf.PI*2;

            //x = target.position.x + Mathf.Sin(angle * speed) * radius;
            //y = target.position.z + Mathf.Cos(angle * speed) * radius;

            
            cosX = Mathf.Sin(angle * speed);
            cosY = Mathf.Cos(angle * speed);
            cosXRadius = cosX * radius;
            cosYRadius = cosY * radius;
            endX = target.position.x + cosXRadius;
            endY = target.position.z + cosYRadius;
            x = endX;
            y = endY;

            transform.position = new Vector3(x, transform.position.y, y);
        }
    }

    IEnumerator COUT() {
        while (true)
        {
            print("x: " + x);
            print("y: " + y);
            print("cosX: " + cosX);
            print("cosY: " + cosY);
            print("cosXRadius: " + cosXRadius);
            print("cosYRadius: " + cosYRadius);
            print("endX: " + endX);
            print("endY: " + endY);
            if (target)
            {
                print("target.position.x: " + target.position.x);
                print("target.position.y: " + target.position.y);
            }
            else {
                print("target: NULL= " + target == null);
            }
            print("================================================");
            yield return new WaitForSeconds(3);
        }
    }
}
