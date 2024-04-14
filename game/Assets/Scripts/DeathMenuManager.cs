using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenuManager : MonoBehaviour {

   public HUDManager hudManager;
   public bool isActive = false;
   public void ShowGameOver() {
      gameObject.SetActive(true);
      GameMaster.StopTheCount();
      Time.timeScale = 0;
      isActive = true;
   }
   
   // Hide the menu panel
   public void Hide() {
      gameObject.SetActive(false);
      Time.timeScale = 1f;
      GameMaster.StartTheCount();
      isActive = false;
      GameMaster.pause = false;
   }

   public void Restart(){
      Hide();
      GameMaster.Reset();
      EnemySpawner.tick = 1;
      SceneManager.LoadScene("Level1 1");
   }

   public void QuitGame() {
      Hide();
      SceneManager.LoadScene("MainMenu");
   }
}
