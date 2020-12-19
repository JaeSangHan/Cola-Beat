using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    Vector3 target = new Vector3(5.0f, 0, 0);
    Vector3 velo = Vector3.zero;

    public float minSize;
    public float growFactor;
    public float waitTime;

    public int trackNum;           //몇 번 캔에 놓여있는지
    public int priority;           //안쪽으로부터 몇 번째 노트인가

    public float spawnedTiming;    //스폰된 타이밍
    public float speedInTime;      //n초동안 줄어듦
    public float willPlayTiming;   //연주될 타이밍

    public bool isStateChecked;    //이미 판정 되었는지

    public enum NoteType
    {
        NORMAL,
        LONG,
        BOUNCE_UP,
        BOUNCE_DOWN
    }

    public enum ScoreType
    {
        NONE,
        PERFECT,
        GOOD,
        BAD,
        MISS
    }

    public NoteType noteType;
    public ScoreType scoreType;

    void Start()
    {
        minSize = 0.1f;
        growFactor = 1 / speedInTime;
        waitTime = 0;
        
        willPlayTiming = spawnedTiming + speedInTime;

        StartCoroutine(Scale());
    }

    IEnumerator Scale()
    {
        float timer = 0;
        while (true)
        {
            timer = 0;
            while (minSize < transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                yield return null;
            }
            Debug.Log("소멸까지 "+ timer + "초 걸림");
            scoreType = Note.ScoreType.MISS;
            ScoreManager.instance.ShowScoreType(scoreType); //TEXT UI 업데이트
            ComboCounter.instance.FailCombo();
            Eliminate();
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void Eliminate()
    {
        Destroy(gameObject);
    }
}