using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownManager : MonoBehaviour
{
    Dropdown drop;
    public int num = 1;
    void Start()
    {
        drop = this.GetComponent<Dropdown>();
        
    }
    void Update()
    {
        drop.options.Clear();
        foreach(string weapon in PlayerController.weaponList){
            drop.options.Add(new Dropdown.OptionData() {text = weapon});
        }
        if(num==1){
            drop.captionText.text = PlayerController.weapon1ID;
        } else {
            drop.captionText.text = PlayerController.weapon2ID;
        }  
    }

    public void DropdownSelected(){
        int index = drop.value;
        if(num==1){
            PlayerController.weapon1ID = drop.options[index].text;
            PlayerController.currentWeapon = PlayerController.weapon1ID;
            drop.captionText.text = PlayerController.weapon1ID;
        } else {
            PlayerController.weapon2ID = drop.options[index].text;
            drop.captionText.text = PlayerController.weapon2ID;
        }
        
    }
}
