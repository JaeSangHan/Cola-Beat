using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyInput : MonoBehaviour
{
    public GameObject[] cans;
    public GameObject[] spawnPoints;

    public JudgeManager[] judgeManager;

    void Start()
    {
        for (int i = 0; i < cans.Length; i++)
        {
            cans[i] = GameObject.Find("can" + i);
            judgeManager[i] = cans[i].GetComponent<JudgeManager>();
        }
        //주의 : 인스펙터에서 can1 이름을 바꾸지 마시오
        for (int i = 0; i< spawnPoints.Length; i++)
            spawnPoints[i] = GameObject.Find("SP" + i);
        //주의 : 인스펙터에서 SP 이름을 바꾸지 마시오
    }

    void Update()
    {
        KeyboardInput();
    }

    void KeyboardInput()
    {
        //하드코딩 해결할 방법 없나.. 흠

        InputKeyDown();
        InputKeyHold();
        InputKeyUp();
    }

    void InputKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            cans[0].GetComponent<GlowManager>().ToggleGlow();
            judgeManager[0].Hit(0);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            cans[1].GetComponent<GlowManager>().ToggleGlow();
            judgeManager[1].Hit(1);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            cans[2].GetComponent<GlowManager>().ToggleGlow();
            judgeManager[2].Hit(2);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            cans[3].GetComponent<GlowManager>().ToggleGlow();
            judgeManager[3].Hit(3);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            cans[4].GetComponent<GlowManager>().ToggleGlow();
            judgeManager[4].Hit(4);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            cans[5].GetComponent<GlowManager>().ToggleGlow();
            judgeManager[5].Hit(5);
        }
    }

    void InputKeyHold()
    {
        if (Input.GetKey(KeyCode.U))
        {
            judgeManager[0].isHolding = true;
            judgeManager[0].Hit(0);
        }

        if (Input.GetKey(KeyCode.I))
        {
            judgeManager[1].isHolding = true;
            judgeManager[1].Hit(1);
        }

        if (Input.GetKey(KeyCode.O))
        {
            judgeManager[2].isHolding = true;
            judgeManager[2].Hit(2);
        }

        if (Input.GetKey(KeyCode.J))
        {
            judgeManager[3].isHolding = true;
            judgeManager[3].Hit(3);
        }

        if (Input.GetKey(KeyCode.K))
        {
            judgeManager[4].isHolding = true;
            judgeManager[4].Hit(4);
        }

        if (Input.GetKey(KeyCode.L))
        {
            judgeManager[5].isHolding = true;
            judgeManager[5].Hit(5);
        }
    }

    void InputKeyUp()
    {
        if (Input.GetKeyUp(KeyCode.U))
        {
            cans[0].GetComponent<GlowManager>().ToggleGlow();
            judgeManager[0].isHolding = false;
            judgeManager[0].isJudgingLongNote = false;
        }

        if (Input.GetKeyUp(KeyCode.I))
        {
            cans[1].GetComponent<GlowManager>().ToggleGlow();
            judgeManager[1].isHolding = false;
            judgeManager[1].isJudgingLongNote = false;
        }

        if (Input.GetKeyUp(KeyCode.O))
        {
            cans[2].GetComponent<GlowManager>().ToggleGlow();
            judgeManager[2].isHolding = false;
            judgeManager[2].isJudgingLongNote = false;
        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            cans[3].GetComponent<GlowManager>().ToggleGlow();
            judgeManager[3].isHolding = false;
            judgeManager[3].isJudgingLongNote = false;
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            cans[4].GetComponent<GlowManager>().ToggleGlow();
            judgeManager[4].isHolding = false;
            judgeManager[4].isJudgingLongNote = false;
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            cans[5].GetComponent<GlowManager>().ToggleGlow();
            judgeManager[5].isHolding = false;
            judgeManager[5].isJudgingLongNote = false;
        }
    }
}

