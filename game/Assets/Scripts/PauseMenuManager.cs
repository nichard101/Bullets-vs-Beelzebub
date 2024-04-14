using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour {

   public HUDManager hudManager;
   
   public void ShowPause() {
      gameObject.SetActive(true);
      GameMaster.StopTheCount();
      Time.timeScale = 0;
   }
   
   // Hide the menu panel
   public void Hide() {
      gameObject.SetActive(false);
      Time.timeScale = 1f;
      GameMaster.StartTheCount();
   }

   public void Resume(){
      Hide();
      hudManager.hud.SetActive(true);
      GameMaster.pause = false;
   }

   public void QuitGame() {
      Hide();
      SceneManager.LoadScene("MainMenu");
   }

   void Update () {
      if(Input.GetKeyDown(KeyCode.Escape)) {
         Resume();
      }
   }
}
