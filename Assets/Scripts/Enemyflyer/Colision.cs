using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{

    public GameObject inimigo;
    private void Start()
    {
      
    }
    private void OnTriggerEnter(Collider other)
    {
        inimigo.GetComponent<InimigoVoador>().Seguindo = true;
    }
    private void OnTriggerExit(Collider other)
    {
        inimigo.GetComponent<InimigoVoador>().Seguindo=false;
    }

}
