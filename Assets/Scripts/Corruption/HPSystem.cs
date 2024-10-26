using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSystem : MonoBehaviour
{

    public float maxHP = 100;
    public float curHP = 100;
    public float minHP = 0;

    private void Update()
    {
        DeathMensage();
    }
    void DeathMensage()
    {
        if (curHP <= minHP)
        {

            Debug.Log("Você até morreu, mas vou te reviver.");
            curHP = 100;

        }
    }
}
