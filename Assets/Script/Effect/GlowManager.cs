using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowManager : MonoBehaviour
{
    public Material nonglow;
    public Material glow;
    bool isGlowing;

    public void ToggleGlow()
    {
        if (isGlowing)
        {
            gameObject.GetComponent<SpriteRenderer>().material = nonglow;
            isGlowing = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().material = glow;
            isGlowing = true;
        }
    }
}
