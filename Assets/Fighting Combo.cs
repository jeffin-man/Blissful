using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public enum Attacktype { quad = 0, tri = 1, bol = 2, xis = 3 }
public class FightingCombo : MonoBehaviour
{
    [Header("inputs")]
    public KeyCode quadkey;
    public KeyCode triangulokey;
    public KeyCode bolakey;
    public KeyCode xiskey;

    [Header("Attacks")]
    public ComboAttack quad;
    public ComboAttack tri;
    public ComboAttack bol;
    public ComboAttack xis;
    public List<Combo> combos;
    public float comboLeeway = 0.2f;

    [Header("Components")]
    Animator ani;

    ComboAttack curAttack = null;
    ComboInput lastInput = null;
    List<int> currentCombos = new List<int>();

    float timer = 0;
    float leeway = 0;
    bool skip = false;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        PrimeCombos();  // Inicializando os combos
    }

    void PrimeCombos()
    {
        for (int i = 0; i < combos.Count; i++)
        {
            Combo c = combos[i];
            c.onInputted.AddListener(() =>
            {
                skip = true;
                Attack(c.comboAttack);
                ResetCombos();
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (curAttack != null)
        {
            if (timer > 0)
                timer -= Time.deltaTime;
            else
                curAttack = null;

            return;
        }

        if (currentCombos.Count > 0)
        {
            leeway += Time.deltaTime;
            if (leeway >= comboLeeway)
            {
                if (lastInput != null)
                {
                    Attack(getAttackFromType(lastInput.type));
                    lastInput = null;
                }

                ResetCombos();
            }
        }
        else
            leeway = 0;

        ComboInput input = null;
        if (Input.GetKeyDown(quadkey))
            input = new ComboInput(Attacktype.quad);
        if (Input.GetKeyDown(triangulokey))
            input = new ComboInput(Attacktype.tri);
        if (Input.GetKeyDown(bolakey))
            input = new ComboInput(Attacktype.bol);
        if (Input.GetKeyDown(xiskey))
            input = new ComboInput(Attacktype.xis);

        if (input == null) return;

        lastInput = input;
        List<int> remove = new List<int>();

        for (int i = 0; i < currentCombos.Count; i++)
        {
            Combo c = combos[currentCombos[i]];
            if (c.ContinueCombo(input))
                leeway = 0;
            else
                remove.Add(i);
        }

        if (skip)
        {
            skip = false;
            return;
        }

        for (int i = 0; i < combos.Count; i++)
        {
            if (currentCombos.Contains(i)) continue;
            if (combos[i].ContinueCombo(input))
            {
                currentCombos.Add(i);
                leeway = 0;
            }
        }

        foreach (int i in remove)
            currentCombos.RemoveAt(i);

        if (currentCombos.Count <= 0)
            Attack(getAttackFromType(input.type));
    }

    private ComboAttack getAttackFromType(Attacktype type)
    {
        if (type == Attacktype.quad)
            return quad;
        if (type == Attacktype.tri)
            return tri;
        if (type == Attacktype.bol)
            return bol;
        if (type == Attacktype.xis)
            return xis;
        return null;
    }

    void ResetCombos()
    {
        leeway = 0;
        for (int i = 0; i < currentCombos.Count; i++)
        {
            Combo c = combos[currentCombos[i]];
            c.ResetCombo();
        }
    }

    void Attack(ComboAttack att)
    {
        curAttack = att;
        timer = att.lenght;
        ani.Play(att.name, -1, 0);
    }

    [System.Serializable]
    public class ComboAttack
    {
        public string name;
        public float lenght;
    }

    [System.Serializable]
    public class ComboInput
    {
        public Attacktype type;

        public ComboInput(Attacktype t)
        {
            type = t;
        }

        public bool IsSameAs(ComboInput test)
        {
            return (type == test.type);
        }
    }

    [System.Serializable]
    public class Combo
    {
        public string name;
        public List<ComboInput> input;
        public ComboAttack comboAttack;
        public UnityEvent onInputted;
        int curInput = 0;

        public bool ContinueCombo(ComboInput i)
        {
            if (input[curInput].IsSameAs(i))
            {
                curInput++;
                if (curInput >= input.Count)
                {
                    onInputted.Invoke();
                    curInput = 0;
                }
                return true;
            }
            else
            {
                curInput = 0;
                return false;
            }
        }

        public ComboInput CurrentComboInput()
        {
            if (curInput >= input.Count) return null;
            return input[curInput];
        }

        public void ResetCombo()
        {
            curInput = 0;
        }
    }
}

