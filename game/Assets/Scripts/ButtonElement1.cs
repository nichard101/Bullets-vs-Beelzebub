using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonElement1 : MonoBehaviour
{
    public int soulCost = 20;
    public bool available = true;

    public TextMeshProUGUI text;

    public void IncreaseCost(float multiplier){
        soulCost = Mathf.RoundToInt(soulCost * multiplier);
    }

    public void Disable(){
        available = false;
    }
}
