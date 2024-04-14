using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//hi

public class HUDManager : MonoBehaviour {

   public GameObject hud;
   public GameObject upgrades;
   public GameObject alerts;
   
   UpgradeMenuManager upgradeMenu;
   TextAlerts textAlerts;

   public RawImage weapon1;
   ImageManager weapon1Image;
   public RawImage weapon2;
   ImageManager weapon2Image;

   public Text hudScore = null;
   public Text hudHealth = null;
   public Text enemyCount = null;
   public Text souls = null;
   
   // Use this for initialization
   void Start () {

      upgradeMenu = upgrades.GetComponent<UpgradeMenuManager>();
      upgradeMenu.Hide();
      weapon1Image = weapon1.GetComponent<ImageManager>();
      weapon2Image = weapon2.GetComponent<ImageManager>();
      textAlerts = alerts.GetComponent<TextAlerts>();
   }
   
   // Update is called once per frame
   void Update () {

      hudScore.text = "Score: " + GameMaster.score;
      hudHealth.text = "Health";
      enemyCount.text = "Enemies: "  + GameMaster.enemyCount;
      souls.text = "Souls: " + PlayerController.souls;
      weapon1Image.UpdateImage(PlayerController.weapon1ID);
      weapon2Image.UpdateImage(PlayerController.weapon2ID);

      if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape)) {
         upgradeMenu.ShowMenu();
         GameMaster.StopTheCount();
         GameMaster.pause = true;
      }
   }

   public void TextAlert(string message){
      textAlerts.DisplayMessage(message);
   }
}
