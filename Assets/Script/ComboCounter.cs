using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ComboCounter : MonoBehaviour
{
    static public ComboCounter instance;

    public Text comboText;
    public int combo;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        comboText.text = "";
    }

    void Update()
    {
        if (combo > 0)
        {
            string tmp = "COMBO : " + combo.ToString();
            if (tmp == "COMBO : ") comboText.text = "";
            else comboText.text = tmp;
        }
    }

    public void PlusCombo()
    {
        combo++;
    }

    public void FailCombo()
    {
        combo = 0;
        comboText.text = "";
    }
}
