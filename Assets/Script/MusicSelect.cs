using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MusicSelect : MonoBehaviour
{
    public AudioClip[] previewMusic;

    public Song[] SongList;
    public Song selectedSong;
    public Text currentSongName;
    public Text currentSpeedText;

    public SpriteRenderer AlbumCover;
    public Sprite[] CoverImages;
    public GameObject HighlightPanel;
    public float MusicSpeed = 1.0f;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        selectedSong = SongList[0];
        currentSongName.text = selectedSong.MusicName;

        GetComponent<AudioSource>().clip = previewMusic[0];
        GetComponent<AudioSource>().Play();
    }

    public void SelectMusic_Faded()
    {
        selectedSong = SongList[0];
        AlbumCover.sprite = CoverImages[0];
        currentSongName.text = selectedSong.MusicName;

        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = previewMusic[0];
        GetComponent<AudioSource>().Play();

        HighlightPanel.transform.DOMove(new Vector3(-5.2f, 2.6f, 0), 0.5f).SetEase(Ease.InOutCubic);
    }

    public void SelectMusic_Warriors()
    {
        selectedSong = SongList[1];
        AlbumCover.sprite = CoverImages[1];
        currentSongName.text = selectedSong.MusicName;

        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = previewMusic[1];
        GetComponent<AudioSource>().Play();

        HighlightPanel.transform.DOMove(new Vector3(-5.2f, 1.35f, 0), 0.5f).SetEase(Ease.InOutCubic);
    }

    public void SelectMusic_Dinosuar()
    {
        selectedSong = SongList[2];
        AlbumCover.sprite = CoverImages[2];
        currentSongName.text = selectedSong.MusicName;

        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = previewMusic[2];
        GetComponent<AudioSource>().Play();

        HighlightPanel.transform.DOMove(new Vector3(-5.2f, 0.1f, 0), 0.5f).SetEase(Ease.InOutCubic);
    }

    public void IncreaseSpeed()
    {
        if (MusicSpeed < 2.0f)
            MusicSpeed += 0.1f;
        selectedSong.musicSpeed = 1 / MusicSpeed;
    }

    public void DecreaseSpeed()
    {
        if (0.5f < MusicSpeed)
            MusicSpeed -= 0.1f;
        selectedSong.musicSpeed = 1 / MusicSpeed;
    }

    public void Update()
    {
        //selectedSong.musicSpeed = Slider.value;
        currentSpeedText.text = MusicSpeed.ToString("N1");
    }

    public void MoveScene()
    {
        GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene("Ingame");
    }

}
