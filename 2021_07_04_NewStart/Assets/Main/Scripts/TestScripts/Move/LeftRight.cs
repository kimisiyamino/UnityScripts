using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRight : MonoBehaviour
{
    public float Speed, Angle, Radius;
    public float Annn;

    private float _x;
    private bool flag = true;

    void Start()
    {
        _x = transform.position.x;
    }


    void Update()
    {
        Angle %= 180;

        
        if (flag)
        {
            Angle += Time.deltaTime;
        }
        else {
            Angle -= Time.deltaTime;
        }

        Annn = Angle * Mathf.Rad2Deg;

        if (Annn >= 180)
        {
            flag = false;
        }
        else if (Annn <= 0) {
            flag = true;
        }

        float x = _x + Mathf.Sin(Speed * Angle) * Radius;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
