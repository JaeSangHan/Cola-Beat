using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScan : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "HitBox")
        {
            if (coll.gameObject.name == "HitBox_Perfect")
                GetComponentInParent<Note>().scoreType = Note.ScoreType.PERFECT;

            if (coll.gameObject.name == "HitBox_Miss")
                GetComponentInParent<Note>().scoreType = Note.ScoreType.MISS;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "HitBox")
        {
            if (coll.gameObject.name == "HitBox_Perfect")
                GetComponentInParent<Note>().scoreType = Note.ScoreType.NONE;

            if (coll.gameObject.name == "HitBox_Miss")
                GetComponentInParent<Note>().scoreType = Note.ScoreType.NONE;
        }
    }
}
