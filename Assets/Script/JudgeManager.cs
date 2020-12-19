using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject TouchEffect;
    public SoundManager sound;

    public bool isHolding;                         //마우스 꾹 누르는 상태인가
    Note.ScoreType previousLongNoteScore;   //가장 처음 처리한 롱노트 스코어
    public bool isJudgingLongNote;                 //현재 롱노트 처리중인지

    public void Hit(int trackIndex)
    {
        if (spawnPoints[trackIndex].transform.childCount < 1) return;
        var note = spawnPoints[trackIndex].transform.GetChild(0).GetComponent<Note>();
        if (note == null) return;

        JudgeNote(note);
        switch (note.noteType)
        {
            case Note.NoteType.NORMAL:
                {
                    if (isHolding == true) return;

                    isJudgingLongNote = false;

                    if (note.scoreType == Note.ScoreType.PERFECT || note.scoreType == Note.ScoreType.GOOD)
                    {
                        //이펙트 업데이트
                        sound.PlaySound();
                        ScoreManager.instance.ShowScoreType(note.scoreType); //TEXT UI 업데이트
                        ComboCounter.instance.PlusCombo();
                        //====================

                        Instantiate(TouchEffect, spawnPoints[trackIndex].transform);
                        note.Eliminate();
                    }
                    else if (note.scoreType == Note.ScoreType.BAD || note.scoreType == Note.ScoreType.MISS)
                    {
                        //이펙트 업데이트
                        ScoreManager.instance.ShowScoreType(note.scoreType); //TEXT UI 업데이트
                        ComboCounter.instance.FailCombo();
                        //====================
                        note.Eliminate();
                    }
                }
                break;
            case Note.NoteType.LONG:
                {
                    if (isHolding == false) return;
                    //if (note.scoreType == Note.ScoreType.NONE) return;

                    if (isJudgingLongNote == false)
                    {
                        isJudgingLongNote = true;
                        previousLongNoteScore = note.scoreType;
                        ComboCounter.instance.PlusCombo();
                        //이펙트 업데이트
                        sound.PlaySound();                                           //효과음
                        ScoreManager.instance.ShowScoreType(note.scoreType);         //UI Text
                        Instantiate(TouchEffect, spawnPoints[trackIndex].transform); //이펙트
                        //====================
                        note.Eliminate();
                    }
                    else if (isJudgingLongNote == true)
                    {
                        if (note.transform.localScale.x <= 0.7f) //원 중앙까지 온 다음
                        {
                            ComboCounter.instance.PlusCombo();
                            //이펙트 업데이트
                            sound.PlaySound();                                              //효과음
                            ScoreManager.instance.ShowScoreType(previousLongNoteScore);     //UI Text //전 노트 점수로 판정
                            Instantiate(TouchEffect, spawnPoints[trackIndex].transform);    //이펙트
                            //====================
                            note.Eliminate();
                        }
                    }
                    
                }
                break;
        }
    }

    void JudgeNote(Note note)
    {
        var noteTiming = note.willPlayTiming;
        var now = HighSpeed.Instance.CurrentTime; // 클릭한 시간

        if (note.isStateChecked == false) // state 판정
        {
            if (noteTiming - 0.3 <= now && now <= noteTiming + 0.3) // perfect
            {
                Debug.Log("노트 타이밍 : " + noteTiming + "노래 : " + now);
                note.scoreType = Note.ScoreType.PERFECT;
                note.isStateChecked = true;
            }
            else if (noteTiming - 0.5 <= now && now <= noteTiming + 0.5) // good
            {
                note.scoreType = Note.ScoreType.GOOD;
                note.isStateChecked = true;
            }
            else if (noteTiming - 0.6 <= now && now <= noteTiming + 0.6)    // bad
            {
                note.scoreType = Note.ScoreType.BAD;
                note.isStateChecked = true;
            }
            else
            {
                note.isStateChecked = false;
            }
        }
    }
}
