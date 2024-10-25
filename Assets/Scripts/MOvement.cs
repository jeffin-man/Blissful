using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOvement : MonoBehaviour
{
    public float speed = 1;


    void Update()
    {
      
        transform.Translate(Input.GetAxisRaw("Horizontal") * speed, 0, Input.GetAxisRaw("Vertical") * speed);
    }
}
