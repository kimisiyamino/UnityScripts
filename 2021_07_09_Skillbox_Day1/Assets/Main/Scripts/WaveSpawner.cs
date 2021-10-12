using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class WaveSpawner : MonoBehaviour
{
    public IWave[] Waves;
    [Tooltip("Milliseconds")]
    public int timeBeetweenWaves; 

    private int index;

    void Start()
    {
        if (Waves.Length > 0)
            index = 0;

/*        foreach (Wave wave in Waves)
        {
            wave.gameObject.SetActive(true);

            while (wave.isActive)
            {
                
            }
            Thread.Sleep(timeBeetweenWaves);}*/
       
    }

    void Update()
    {

        if (Waves[index].gameObject.activeSelf == false){
            Waves[index].gameObject.SetActive(true);
        }

        if (!Waves[index].isActive) {
            Waves[index].gameObject.SetActive(false);
            index++;
            if(index >= Waves.Length) {
                //index = 0;
                Destroy(this); 
            }
        }
    }

    
}
