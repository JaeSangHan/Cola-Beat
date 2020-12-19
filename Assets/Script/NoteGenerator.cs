using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{
    public ReadCSV csv;
    public GameObject notePrefab;
    public GameObject spawnedPrefab;
    public GameObject[] spawnPoint;
    public Sprite[] sprites;

    public float musicPlayedTime = 0.00f;     //노래 플레이 후 경과 시간
    public float arriveSpentTime;             //노트가 지점까지 가는데에 걸리는 시간
    float tick = 0.03f;
    double count;                             //디버깅 편의상, 나중엔 private로 바꾸기

    void Awake()
    {
        Init();
    }

    void Init()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        for (int i = 0; i < 6; i++)
            spawnPoint[i] = GameObject.Find("SP" + i);
        //주의 : 인스펙터에서 "SP+(숫자)" 이름을 바꾸지 마시오
    }

    void Start()
    {
        //Invoke("PlayMusic", csv.currentSong.musicStartDelay);
        //InvokeRepeating("Timer", csv.noteStartDelay, tick);

        Invoke("PlayMusic", csv.musicStartDelay);
        var delay = csv.musicStartDelay - csv.musicSpeed + csv.noteStartDelay;
        InvokeRepeating("Timer", delay, tick);

        //2초 뒤에, 0.03초 간격으로 timer 메서드 호출
        //노래 시작 타이밍을 조절해서 싱크 맞출 수 있음
    }
    //Invoke를 써야 정확하다!

    void PlayMusic()
    {
        GetComponent<AudioSource>().clip = csv.currentSong.clip;
        GetComponent<AudioSource>().Play();
    }

    void Timer()
    {
        count += csv.CountperSec * tick;
        musicPlayedTime += tick;

        if (csv.note.Count < 1) //남은 큐가 없으면
            return;

        if (count > csv.note.Peek().startTime)
        {
            GenerateNote(musicPlayedTime);
        }
    }

    void GenerateNote(float musicPlayedTime)
    {
        int rand;
        rand = csv.note.Peek().track;
        spawnedPrefab = Instantiate(notePrefab, spawnPoint[rand].transform);
        spawnedPrefab.GetComponent<Note>().spawnedTiming = HighSpeed.Instance.CurrentTime;
        spawnedPrefab.GetComponent<Note>().noteType = csv.note.Peek().noteType;
        spawnedPrefab.GetComponent<Note>().speedInTime = csv.currentSong.musicSpeed;

        //스프라이트 설정
        switch (csv.note.Peek().noteType)
        {
            case Note.NoteType.NORMAL:
                spawnedPrefab.GetComponent<SpriteRenderer>().sprite = sprites[0];
                break;
            case Note.NoteType.LONG:
                spawnedPrefab.GetComponent<SpriteRenderer>().sprite = sprites[1];
                break;
        }


        //Debug.Log(csv.note.Peek());
        csv.note.Dequeue();
    }
}
