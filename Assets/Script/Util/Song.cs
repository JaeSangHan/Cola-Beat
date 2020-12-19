using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "New Song", menuName = "Song")]
public class Song : ScriptableObject
{
    public string MusicName;
    public string CSVName;
    public AudioClip clip;
    public VideoClip videoClip;

    public double bpm;                           //BPM
    public double beat;                       //1박
    public float musicStartDelay;             //첫 음악 시작까지 딜레이
    public float noteStartDelay;              //첫 노트 생성까지 딜레이

    [Range(0.1f, 2.0f)]
    public float musicSpeed;

    public bool isRandomNote;                 //노트를 무작위 트랙에 생성할 것인가
}
