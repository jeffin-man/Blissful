using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    
    GameObject player;
    public float SpeedEnemy = 5;
    public string polenta = "finjo que n percebo mas esta tudo sendo observado";
    public bool RealouFake;
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (RealouFake == true)
        {
            FollowPlayer();
        }
    }

    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, SpeedEnemy * Time.deltaTime);
        Debug.Log(polenta);
    }

    

   
}
