// code by EleonoraLion
//
// Выводим в TextMesh дистанцию от pointA до pointB в формате "0.000"
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    void Update()
    { 
        GetComponent<TextMesh>().text = Vector3.Distance(pointA.position, pointB.position).ToString("0.000");
    }
}
