using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mist : MonoBehaviour
{

    public float mistDelay = 5;
    public float mistDmg = 5;
    private float delay;
    
    void Start()
    {
        delay = mistDelay;
    }
    private void Update()
    {
        

    }
    private void OnTriggerStay(Collider other)
        {
            mistDelay -= Time.deltaTime;
        
            if (mistDelay <= 0)
            {
                
                other.gameObject.GetComponent<HPSystem>().curHP -= mistDmg;
                mistDelay++;
            }

        }
    private void OnTriggerExit(Collider other)
    {
        mistDelay = delay;
    }
}