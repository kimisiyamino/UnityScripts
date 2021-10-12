// Eleonora Lion
// 
// Движение объекта по рандомным координатам
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTest : MonoBehaviour
{
    public float Speed = 0.5f;
    public Transform[] currentPoints;

    private Transform currentPoint;
    private int index;

    void Start()
    {
        index = 0;
        currentPoint = currentPoints[index];
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, Time.deltaTime * Speed);

        /*
        if (transform.position == currentPoint.position) {
            index++;
            if (index > currentPoints.Length-1) {
                index = 0;
            }
            currentPoint = currentPoints[index];
        }
        */

        if (transform.position == currentPoint.position)
        {
            index = Random.Range(0, currentPoints.Length);
            currentPoint = currentPoints[index];
        }

    }
}
