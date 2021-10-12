// Code by EleonoraLion
//
// Слежение за объектом по осям x, z
// Переключение методов Quaternion.LookRotation и transform.LookAt

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRotationTest : MonoBehaviour
{
    public Transform point;
    public Vector vectorAxe = Vector.Up;
    public Look lookMethod = Look.LookAt;

    private Vector3 axe = Vector3.up;

    void Update()
    {
        switch (vectorAxe)
        {
            case Vector.Left: axe = Vector3.left; break;
            case Vector.Right: axe = Vector3.right; break;
            case Vector.Down: axe = Vector3.down; break;
            case Vector.Up: axe = Vector3.up; break;
            case Vector.Forward: axe = Vector3.forward; break;
            case Vector.Back: axe = Vector3.back; break;
            case Vector.One: axe = Vector3.one; break;
            case Vector.Zero: axe = Vector3.zero; break;
        }

        Vector3 v = point.position - transform.position;

        if(lookMethod == Look.LookRotation)
            transform.rotation = Quaternion.LookRotation(new Vector3(v.x, 0, v.z), axe);
        else
            transform.LookAt(point.position, axe);

    }

   
}
public enum Vector
{
    Left, Right, Up, Down, Forward, Back, One, Zero 
}

public enum Look
{
    LookAt, LookRotation
}
