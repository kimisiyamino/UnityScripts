using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look : MonoBehaviour
{

    public float Radius, FireDelay, Damage;
    public LayerMask EnemyLayer;
    //public Transform BulletPrefab;

    //private float timeToFire;

    //private Vector3 firePoint;

    public Transform gun, enemy;
   
    void Start()
    {
        //timeToFire = FireDelay;
        //gun = transform.GetChild(0);
        //firePoint = gun.GetChild(0).position;
        //firePoint = gun.GetChild(0);
    }


    void Update()
    {
        if (enemy) // != null
        {
            Vector3 lookAt = new Vector3(enemy.position.x, enemy.position.y, 0); 
            //lookAt.z = gun.position.z;  
            gun.transform.rotation = Quaternion.LookRotation(lookAt); 


           // if (Vector3.Distance(transform.position, enemy.position) > Radius)
          // {
           //     enemy = null;
            //}
        }
       // else if (enemy == null)
       // {
            //Collider[] coll = Physics.OverlapSphere(transform.position, Radius, EnemyLayer);

            //if (coll.Length > 0)
            //{
           //     enemy = coll[0].transform;
           // }
     //   }
    }
}
