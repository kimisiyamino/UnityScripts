using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float FullHP;

    public Transform bar;
    public Enemy enemy;

    public float onePercentBar, onePercentHealth;

   // public Color greenHealthColor;
    private float BarY, BarZ;
 
    void Start()
    {
        enemy = transform.GetComponent<Enemy>();
        bar = transform.GetChild(0).GetChild(0);

        BarY = bar.localScale.y;
        BarZ = bar.localScale.z;

        FullHP = enemy.maxHP;
        onePercentBar = bar.localScale.x / 100f;
        onePercentHealth = FullHP / 100f;
    }


    void Update()
    {
        float percents = enemy.HP / onePercentHealth;
        bar.localScale = new Vector3(percents * onePercentBar, BarY, BarZ);

        if (percents < 50)
        {
            bar.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        

    }
}
