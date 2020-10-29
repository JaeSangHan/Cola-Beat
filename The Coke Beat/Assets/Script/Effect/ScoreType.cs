using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreType : MonoBehaviour
{
    static public ScoreType instance;

    Text scoreTypeText;
    RectTransform rt;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        scoreTypeText = GetComponent<Text>();
        rt = GetComponent<RectTransform>();
    }

    public void ShowScoreType(Note.ScoreType type)
    {
        scoreTypeText.DOKill();
        rt.DOKill();

        scoreTypeText.color = new Color(scoreTypeText.color.r, scoreTypeText.color.g, scoreTypeText.color.b, 1.0f);
        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, -30.0f);

        rt.DOAnchorPos(new Vector2(0, 0), 0.5f).SetEase(Ease.OutElastic).OnComplete(()=> scoreTypeText.DOFade(0, 0.5f));
        switch (type)
        {
            case Note.ScoreType.NONE:
                break;
            case Note.ScoreType.PERFECT:
                scoreTypeText.text = "PERFECT";
                break;
            case Note.ScoreType.GOOD:
                scoreTypeText.text = "GOOD";
                break;
            case Note.ScoreType.MISS:
                scoreTypeText.text = "MISS";
                break;
        }

        ClearText();
    }

    void ClearText()
    {
        //GetComponent<Text>().DOFade(0f, 0.5f).From().SetEase(Ease.OutQuad);
    }
}
