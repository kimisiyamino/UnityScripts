/*
 * Переопределение
 * 
 * virtual - помечаем переопределяемый метод
 * override - помечаем переопределение
 * public new void Method() - не переопределяет метод
 * 
 * private методы не переопределяются, поэтому нет смысла их помечать virtual
 * 
 * base.Drive() - вызов родительского метода, ключевое слово base
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVirtualOverride : MonoBehaviour
{
    // Main
    void Start()
    {
        Person person = new Person();
        person.Drive(new SportCar());
    }
}



class Car 
{
    public virtual void Drive() 
    {
        Debug.Log("class Car");
    }
}

class SportCar : Car
{
    public override void Drive()
    {
        Debug.Log("class SportCar");
    }
}



class Person 
{
    public void Drive(Car car) 
    {
        car.Drive();
    }
}


