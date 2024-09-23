using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider : MonoBehaviour
{
    public UnityEngine.UI.Slider slider;

    private int MaxPureza = 100;
    private int CurrentPureza;

    public static Slider instance;

    private int value;
    private int maxValue;

    private WaitForSeconds regenTick = new WaitForSeconds(0.3f);



    private void Awake()
    {
        instance = this; 
    }

    void Start()
    {
         CurrentPureza = MaxPureza;
         slider.maxValue = MaxPureza;
         slider.value = MaxPureza;
    }


    public void UsePureza(int amount)
    {
        if (CurrentPureza - amount >= 0)
        {
            CurrentPureza -= amount;
            slider.value = CurrentPureza;

            StartCoroutine(RegenPureza());
        }
        else
        {
            Debug.Log("sem pureza");

        }
    }

    private IEnumerator RegenPureza()
    {
        yield return new WaitForSeconds(3);

        while (CurrentPureza < MaxPureza)
        {
            CurrentPureza += MaxPureza / 100;
            slider.value = CurrentPureza;
            yield return regenTick;
        }
    }
}
