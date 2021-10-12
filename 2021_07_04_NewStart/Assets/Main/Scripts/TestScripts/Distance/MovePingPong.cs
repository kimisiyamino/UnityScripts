// code by EleonoraLion
//
// Интерполяция (point1, point2) с Mathf.PingPong от 0 до Length со скоростью Speed
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePingPong : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public float Interpol, Speed, Length;

    void Update()
    {
        Interpol = Mathf.PingPong(Time.time * Speed, Length);
        transform.position = Vector3.Lerp(point1.position, point2.position, Interpol);
    }
}
