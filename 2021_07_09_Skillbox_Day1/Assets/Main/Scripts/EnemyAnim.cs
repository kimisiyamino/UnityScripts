using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    public string AnimName = "move";

    void Update()
    {
        GetComponent<Animator>().Play(AnimName);
    }
}
