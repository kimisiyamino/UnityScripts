using System.Collections;
using UnityEngine;

// Steering - рулевое управление, рулевое устройство
/*
  Пользовательский тип данных для хранения значений перемещения и поворота агента
*/
public class Steering
{
    // угловой
    public float angular;

    public Vector3 linear;

    public Steering()
    {
        angular = 0.0f;
        linear = new Vector3();
    }
}
