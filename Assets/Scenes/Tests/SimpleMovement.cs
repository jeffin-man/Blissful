using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    private float input;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxis("Vertical");
        if (input != 0)
        {
            transform.Translate(0, 0, input * Time.deltaTime * 5);
            Debug.Log("Movement");
        }
    }
}
