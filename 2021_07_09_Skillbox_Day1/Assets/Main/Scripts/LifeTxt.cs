using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeTxt : MonoBehaviour
{
    public ResourceManager resourceManager;

    void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
    }

    void Update()
    {
        GetComponent<Text>().text = "" + resourceManager.Lifes;
    }
}
