using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Orbes;


    public void PegouOrbe()
    {
        Orbes++;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            Slider.instance.UsePureza(15);
    }
}
