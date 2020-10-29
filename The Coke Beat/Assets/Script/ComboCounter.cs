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
        comboText.gameObject.SetActive(false);
    }

    public void PlusCombo()
    {
        combo++;
        if (combo >= 0)
        {
            if (comboText.gameObject.activeSelf == false)
                comboText.gameObject.SetActive(true);
            comboText.text = "COMBO : " + combo.ToString();
        }
    }

    public void FailCombo()
    {
        combo = 0;
        comboText.gameObject.SetActive(false);
    }
}
