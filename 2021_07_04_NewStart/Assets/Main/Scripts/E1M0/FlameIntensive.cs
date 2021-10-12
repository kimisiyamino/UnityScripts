// Code by EleonoraLion
//
// Иммитация интенсивности пламени
// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameIntensive : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float Range = 0.5f;

    void Update()
    {
        GetComponent<Light>().intensity = Random.Range(Range, 1.0f);
    }
}
