using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndButton : MonoBehaviour
{
    public Button endButton;

    public void Ending(){
        SceneManager.LoadScene("Story 1");
    }

    // Update is called once per frame
    public void Update(){
        if(GameMaster.storyFlag){
            endButton.interactable = true;
        }
    }
}
