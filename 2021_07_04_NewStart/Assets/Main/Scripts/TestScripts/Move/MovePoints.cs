// code by EleonoraLion
//
// Движение объекта по вершинам куба через рёбра в рандомном порядке, без хода назад
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoints : MonoBehaviour
{
    
    public Point nextPoint;
    public float Speed;

    private Vector3 oldPoint;

    void Start()
    {
        // Первый проход
        oldPoint = new Vector3();
    }

    void Update()
    {
        // Двигаемся к первой точке nextPoint.transform.position скоростью Speed
        transform.position = Vector3.MoveTowards(transform.position, nextPoint.transform.position, Speed * Time.deltaTime);

        // Когда точка достигнута
        if (nextPoint.transform.position == transform.position) {
           
            Transform newPoint;
            do {
                // Выбираем у достигнутой точки рандомно "соседа" (следующую точку)
                newPoint = nextPoint.NeighborPoints[(int)Random.Range(0f, 3f)];
            } while (oldPoint == newPoint.position); // Если следующая точка = предыдущей точке, то заново ищем. (В первом проходе выбор из 3 соседей)
                                                     // Так как мы не можем двигарться назад

            // Сохраняем корды текущей точки, как предыдущую
            oldPoint = nextPoint.transform.position;
            // Кладём в nextPoint нового "соседа"
            nextPoint = newPoint.GetComponent<Point>();
        }
    }
}
