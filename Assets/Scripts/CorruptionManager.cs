using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CorruptionManager : MonoBehaviour
{

    public Image PurezaBar;
    public float PurezaAmounth = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Corruption(20);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal(5);
        }
    }


    public void Corruption(float damage)
    {
        PurezaAmounth -= damage;
        PurezaBar.fillAmount = PurezaAmounth / 100f;
    }

    public void Heal(float healingAmount)
    {
        PurezaAmounth += healingAmount;
        PurezaAmounth = Mathf.Clamp(PurezaAmounth, 0, 100);

        PurezaBar.fillAmount = PurezaAmounth / 100f;
    }
}
