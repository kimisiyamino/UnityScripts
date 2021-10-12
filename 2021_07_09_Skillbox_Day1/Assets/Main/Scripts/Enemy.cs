using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed, RotationSpeed;
    public Transform[] Points;
    public float maxHP;
    public int Cost;
    public bool Run;

    public float HP;
    private Transform currentPoint;
    private int index;
    private Vector3 direction;

    public ResourceManager resourceManager;

    void Start()
    {
        index = 0;
        HP = maxHP;
        currentPoint = Points[index];

        resourceManager = FindObjectOfType<ResourceManager>();
    }

    void Update()
    {
        if (Run)
        {
            // Вектор направления
            direction = currentPoint.position - transform.position;
            // Вектор направления поворота
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, Time.deltaTime * RotationSpeed, 0);
            // Поворот по вектору
            transform.rotation = Quaternion.LookRotation(newDirection);

            // Следовать к...
            transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, Time.deltaTime * Speed);

            // Если пришли к точке...
            if (transform.position == currentPoint.position)
            {
                // Индекс следующей точки
                index++;

                // Если точки кончились
                if (index >= Points.Length)
                {
                    // Уничтожаем противника и минусуем жизнь
                    Destroy(gameObject);
                    resourceManager.Lifes -= 1;
                }
                else
                {
                    // Следующая точка
                    currentPoint = Points[index];
                }
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        // Столкновение коллайдера пули с противником
        if (collider.CompareTag("Bullet")) 
        {
            // Уничтожаем пулю
            Destroy(collider.gameObject);
            // Вычитаем HP противника 
            HP -= collider.GetComponent<Bullet>().Damage;

            // Если HP меньше 0
            if (HP <= 0) 
            {
                Destroy(gameObject);
                resourceManager.Gold += Cost;
            }
        }
    }
}
