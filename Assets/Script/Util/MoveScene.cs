﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public void BacktoMusicSelect()
    {
        var obj = GameObject.Find("SelectManager");
        Destroy(obj);
        SceneManager.LoadScene("MusicSelect");
    }
}
