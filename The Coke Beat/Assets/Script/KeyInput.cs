using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyInput : MonoBehaviour
{
    public GameObject[] cans;
    public GameObject[] spawnPoints;
    public GameObject TouchEffect;

    void Start()
    {
        for (int i = 0; i < cans.Length; i++)
            cans[i] = GameObject.Find("can"+i);
        //주의 : 인스펙터에서 can1 이름을 바꾸지 마시오
        for (int i = 0; i< spawnPoints.Length; i++)
            spawnPoints[i] = GameObject.Find("SP" + i);
        //주의 : 인스펙터에서 SP 이름을 바꾸지 마시오

    }

    void Update()
    {
        //하드코딩 해결할 방법 없나.. 흠
        if (Input.GetKeyDown(KeyCode.Q))
        {
            cans[0].GetComponent<GlowManager>().ToggleGlow();
            Hit(0);
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            cans[0].GetComponent<GlowManager>().ToggleGlow();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            cans[1].GetComponent<GlowManager>().ToggleGlow();
            Hit(1);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            cans[1].GetComponent<GlowManager>().ToggleGlow();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            cans[2].GetComponent<GlowManager>().ToggleGlow();
            Hit(2);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            cans[2].GetComponent<GlowManager>().ToggleGlow();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            cans[3].GetComponent<GlowManager>().ToggleGlow();
            Hit(3);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            cans[3].GetComponent<GlowManager>().ToggleGlow();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            cans[4].GetComponent<GlowManager>().ToggleGlow();
            Hit(4);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            cans[4].GetComponent<GlowManager>().ToggleGlow();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            cans[5].GetComponent<GlowManager>().ToggleGlow();
            Hit(5);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            cans[5].GetComponent<GlowManager>().ToggleGlow();
        }
    }


    void Hit(int trackIndex)
    {
        if (spawnPoints[trackIndex].transform.childCount < 1) return;
        var obj = spawnPoints[trackIndex].transform.GetChild(0).GetComponent<Note>();
        GetComponent<AudioSource>().Play();


        ScoreType.instance.ShowScoreType(obj.scoreType); //TEXT UI 업데이트
        if (obj.scoreType == Note.ScoreType.PERFECT)
        {
            ComboCounter.instance.PlusCombo();

            Instantiate(TouchEffect, spawnPoints[trackIndex].transform);
            obj.Eliminate();
        }
        if (obj.scoreType == Note.ScoreType.MISS)
        {
            ComboCounter.instance.FailCombo();
            obj.Eliminate();
        }
    }


}
