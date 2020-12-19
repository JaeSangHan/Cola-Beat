using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public Song currentSong;

    void Awake()
    {
        var obj = GameObject.Find("SelectManager");
        if (obj == null)
        {
            Debug.Log("[경고] 전달된 곡 데이터 없음!");
            return;
        }
        currentSong = obj.GetComponent<MusicSelect>().selectedSong;
    }

    void Start()
    {
        GetComponent<VideoPlayer>().clip = currentSong.videoClip;
        GetComponent<VideoPlayer>().Play();
    }

}
