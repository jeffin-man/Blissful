using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoVoador : MonoBehaviour
{
    public float speed;
    public bool Seguindo;
    public GameObject player;
    public int numeroaleatorio1;
    public float cooldown = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = speed * Time.deltaTime;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Cooldown();

        if (Seguindo == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
        }
        else
        {
            MoveRandom();
        }
    }

    public void Cooldown()
    {
        if (cooldown <= 0)
        {
            RandomRange();
            cooldown = 5;
            Debug.Log(numeroaleatorio1);
        }
        cooldown -= Time.deltaTime;
    }
   public void RandomRange()
    {
       numeroaleatorio1 = Random.Range(0, 14);
    }
    public void MoveRandom()
    {
        if (numeroaleatorio1 == 0)
        {
            transform.Translate(speed, 0, 0);
        }

        else if (numeroaleatorio1 == 1)
        {
            transform.Translate(-speed, 0, 0);
        }

        else if (numeroaleatorio1 == 2)
        {
            transform.Translate(0, speed, 0);
        }

        else if (numeroaleatorio1 == 3)
        {
            transform.Translate(0, -speed, 0);
        }

        else if (numeroaleatorio1 == 4)
        {
            transform.Translate(0, 0, speed);
        }

       else if (numeroaleatorio1 == 5)
        {
            transform.Translate(0, 0, -speed);
        }

        else if (numeroaleatorio1 == 6)
        {
            transform.Translate(speed, speed, 0);
        }

        else if (numeroaleatorio1 == 7)
        {
            transform.Translate(-speed, speed, 0);
        }

        else if (numeroaleatorio1 == 8)
        {
            transform.Translate(speed, -speed, 0);
        }

        else if (numeroaleatorio1 == 9)
        {
            transform.Translate(-speed, -speed, 0);
        }

        else if (numeroaleatorio1 == 10)
        {
            transform.Translate(speed, 0, speed);
        }

        else if (numeroaleatorio1 == 11)
        {
            transform.Translate(-speed, 0, speed);
        }

        else if (numeroaleatorio1 == 12)
        {
            transform.Translate(speed, 0, -speed);
        }

        else if (numeroaleatorio1 == 13)
        {
            transform.Translate(-speed, 0, -speed);
        }
    }

}
