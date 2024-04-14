using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UpgradeMenuManager : MonoBehaviour
{   
    public HUDManager hud;

    public Button healthButton;
    public Button resistButton;
    public Button multiButton;
    public Button dmgButton;
    public Button speedButton;
    public Button rofButton;

    public Dropdown slot1;
    public Dropdown slot2;

    public bool isActive = false;
    public static int lowestCost = 10;

    Button[] buttonArray;

    public void Start() {
        buttonArray = new Button[6];
        buttonArray[0] = healthButton;
        buttonArray[1] = resistButton;
        buttonArray[2] = multiButton;
        buttonArray[3] = dmgButton;
        buttonArray[4] = speedButton;
        buttonArray[5] = rofButton;
        buttonArray[0].GetComponent<ButtonElement1>().soulCost = 10;// = healthButton;
        buttonArray[1].GetComponent<ButtonElement1>().soulCost = 10;// = resistButton;
        buttonArray[2].GetComponent<ButtonElement1>().soulCost = 20;// = multiButton;
        buttonArray[3].GetComponent<ButtonElement1>().soulCost = 15;// = dmgButton;
        buttonArray[4].GetComponent<ButtonElement1>().soulCost = 20;// = speedButton;
        buttonArray[5].GetComponent<ButtonElement1>().soulCost = 20;// = rofButton;
    }
    public void ShowMenu(){
        Time.timeScale = 0;
        gameObject.SetActive(true);
        isActive = true;
    }

    public void Hide() {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        hud.hud.SetActive(true);
        GameMaster.StartTheCount();
        isActive = false;
        GameMaster.pause = false;
    }

    public void RateOfFire() {
        PlayerController.fireRateMultiplier *= 1.5f;
        //PlayerController.damageMultiplier *= 0.9f;
        PlayerController.souls -= rofButton.GetComponent<ButtonElement1>().soulCost;
        rofButton.GetComponent<ButtonElement1>().IncreaseCost(3f);
    }

    public void HealthRegen() {
        PlayerController.healthRegenMultiplier *= 1.5f;
        PlayerController.souls -= healthButton.GetComponent<ButtonElement1>().soulCost;
        healthButton.GetComponent<ButtonElement1>().IncreaseCost(2f);
    }

    public void DamageResistance() {
        PlayerController.damageResistanceMultiplier *= 1.5f;
        PlayerController.souls -= resistButton.GetComponent<ButtonElement1>().soulCost;
        resistButton.GetComponent<ButtonElement1>().IncreaseCost(1.5f);
    }

    public void Multishot() {
        PlayerController.multiShot += 1;
        PlayerController.damageMultiplier *= 0.9f;
        PlayerController.souls -= multiButton.GetComponent<ButtonElement1>().soulCost;
        multiButton.GetComponent<ButtonElement1>().IncreaseCost(4f);
    }

    public void IncreasedDamage() {
        PlayerController.damageMultiplier *= 1.2f;
        PlayerController.souls -= dmgButton.GetComponent<ButtonElement1>().soulCost;
        dmgButton.GetComponent<ButtonElement1>().IncreaseCost(1.5f);
    }

    public void MovementSpeed() {
        PlayerController.moveSpeed *= 1.4f;
        PlayerController.souls -= speedButton.GetComponent<ButtonElement1>().soulCost;
        speedButton.GetComponent<ButtonElement1>().IncreaseCost(3f);
    }

    public void Update(){
        if(isActive){
            int num = 123456;
            foreach(Button b in buttonArray){
                b.transform.GetComponent<ButtonElement1>().text.text = b.GetComponent<ButtonElement1>().soulCost.ToString();
                if(b.GetComponent<ButtonElement1>().available && PlayerController.souls >= b.GetComponent<ButtonElement1>().soulCost){
                    b.interactable = true;
                    if(b.GetComponent<ButtonElement1>().soulCost < num){
                        num = b.GetComponent<ButtonElement1>().soulCost;
                    }
                } else {
                    b.interactable = false;
                }
            }
            lowestCost = num;

            if(Input.GetKeyDown(KeyCode.Escape)){
                Hide();
            }
        }
    }

    public void Reset(){
        buttonArray[0].GetComponent<ButtonElement1>().soulCost = 20;// = reloadButton;
        buttonArray[1].GetComponent<ButtonElement1>().soulCost = 10;// = healthButton;
        buttonArray[2].GetComponent<ButtonElement1>().soulCost = 10;// = resistButton;
        buttonArray[3].GetComponent<ButtonElement1>().soulCost = 20;// = multiButton;
        buttonArray[4].GetComponent<ButtonElement1>().soulCost = 15;// = dmgButton;
        buttonArray[5].GetComponent<ButtonElement1>().soulCost = 20;// = speedButton;
        buttonArray[6].GetComponent<ButtonElement1>().soulCost = 10;// = rofButton;
    }

    public void Exit() {
        Hide();
        SceneManager.LoadScene("MainMenu");
    }
}
