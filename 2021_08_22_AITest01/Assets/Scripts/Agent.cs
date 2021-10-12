using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Основной компонент ответственный за реализацию моделей интеллектуального перемещения
public class Agent : MonoBehaviour
{
    public float maxSpeed;
    public float maxAccel; // acceleration - ускорение
    public float orientation;
    public float rotation;
    public Vector3 velocity; // скорость перемещения
    protected Steering steering;
    void Start()
    {
        velocity = Vector3.zero; // 0, 0, 0
        steering = new Steering();
    }

    public virtual void Update()
    {
        // displacement - перемещение 
        Vector3 displacement = velocity * Time.deltaTime;

        if (orientation < 0.0f)
            orientation += 360.0f;
        else if (orientation > 360.0f)
            orientation -= 360.0f;

        transform.Translate(displacement, Space.World);
        transform.rotation = new Quaternion();
        transform.Rotate(Vector3.up, orientation);
    }

    public virtual void LateUpdate() 
    {
        velocity += steering.linear * Time.deltaTime;
        rotation += steering.angular * Time.deltaTime;


    }

    public void SetSteering(Steering steering)
    {
        this.steering = steering;
    }
}
