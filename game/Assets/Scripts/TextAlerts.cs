using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TextAlerts : MonoBehaviour
{
    public Text text = null;
    DateTime delay;

    void Start(){
        text.text = "";
    }

    void Update(){
        if(delay <= System.DateTime.Now){
            text.text = "";
        }
    }

    public void DisplayMessage(string message){
        delay = System.DateTime.Now.AddSeconds(3);
        text.text = message;
        StartCoroutine(FadeTextToZeroAlpha(3f, text));
    }

    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
 
    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
