using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public GameObject player;

    public Text hpText;

    private float curHP;
    private float maxHP;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curHP = player.GetComponent<HPSystem>().curHP;
        maxHP = player.GetComponent<HPSystem>().maxHP;
        hpText.text = "HP: " + curHP.ToString() + "/" + maxHP.ToString();
    }
}
