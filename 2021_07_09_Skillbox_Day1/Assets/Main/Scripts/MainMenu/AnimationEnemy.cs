using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnemy : MonoBehaviour
{
    void Update()
    {
        GetComponent<Animator>().SetInteger("int", Random.Range(0, 3));
    }
}


