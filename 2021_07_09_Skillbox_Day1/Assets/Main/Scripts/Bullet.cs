using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed, Damage;
    void Start()
    {
        Destroy(gameObject, 2);
    }

    void Update()
    {
      // transform.Translate(transform.forward * Speed * Time.deltaTime);
        //GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * (Speed * Time.deltaTime));
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * (Speed * Time.fixedDeltaTime));
    }
}
