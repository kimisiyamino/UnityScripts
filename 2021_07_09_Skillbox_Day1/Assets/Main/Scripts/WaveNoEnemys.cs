using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveNoEnemys : IWave
{
    [Tooltip("seconds")]
    public float time;

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0) {
            isActive = false;
        }
    }
}
