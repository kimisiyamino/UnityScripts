/*
 * ���������������
 * 
 * virtual - �������� ���������������� �����
 * override - �������� ���������������
 * public new void Method() - �� �������������� �����
 * 
 * private ������ �� ����������������, ������� ��� ������ �� �������� virtual
 * 
 * base.Drive() - ����� ������������� ������, �������� ����� base
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


