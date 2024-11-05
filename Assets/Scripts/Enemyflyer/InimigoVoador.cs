using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoVoador : MonoBehaviour
{
    public float speed;
    public bool Seguindo;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Seguindo == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    public void MoveRandom()
    {

    }
}
