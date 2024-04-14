using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameMaster : MonoBehaviour
{
    public static int playerHealth = 1000;
    public static int score = 0;
    public static bool gameOver = false;
    public static int enemyCount = 0;
    public static int kills = 0;
    public static float time = 0f;
    public static DateTime startTime;
    public static DateTime finishTime;
    public static System.Random rnd = new System.Random();
    public static ArrayList enemyList = new ArrayList();
    public static bool pause = false;
    public static float enemySpeedMultiplier = 1;
    public static float enemyHealthMultiplier = 1;
    public static ArrayList scoreList = new ArrayList();
    public static HUDManager HUDManager;
    public static string csvOfScores = "";

    public static bool storyFlag = false;
    public static float volume = 0.5f;
    public static int resourceCount = 0;

    //TONY'S TESTING START
    public static int startingHealth = playerHealth;

    public static float HealthRatio(){
        return (float)playerHealth / (float)startingHealth;
    }
    //TONY'S TESTING END

    public static void PlayerHit(int damage) {
        playerHealth -= (int)(damage / PlayerController.damageResistanceMultiplier);
        if(playerHealth <= 0){
            gameOver = true;
            LevelOver();
        }
        
    }

    public static void Reset(){
        playerHealth = 1000;
        PlayerController.Reset();
        score = 0;
        kills = 0;
        PlayerController.souls = 0;
        gameOver = false;
        startTime = System.DateTime.Now;
        time = 0f;
        EnemySpawner.flag = true;
        //UpgradeMenuManager.Reset();
        enemyList = new ArrayList();
        pause = false;
        PlayerController.weaponList = new ArrayList();
        PlayerController.weaponList.Add("Empty");
        PlayerController.weaponList.Add("SMG");
        //GiveAllWeapons();
        EnemySpawner.bossSpawnedYet = false;
    }

    public static void StopTheCount(){
        EnemySpawner.Deactivate();
    }

    public static void StartTheCount(){
        EnemySpawner.Activate();
    }

    public static int randomInt(int low, int high){
        return rnd.Next(low, high);
    }

    public static bool randomBool(){
        return rnd.Next() > (Int32.MaxValue / 2);
    }

    public static bool randomBoolean(){
        return rnd.Next() > (Int32.MaxValue / 2);
    }

    public static void LevelOver(){
        finishTime = System.DateTime.Now;
        SceneManager.LoadScene("GameOver");
    }

    public static void GiveAllWeapons(){
        PlayerController.weaponList.Add("MachineGun");
        PlayerController.weaponList.Add("Minigun");
    }

    public static void SwapWeapons(){
        (PlayerController.weapon1ID, PlayerController.weapon2ID) = (PlayerController.weapon2ID, PlayerController.weapon1ID);
        if(PlayerController.currentWeapon == PlayerController.weapon2ID){
            PlayerController.currentWeapon = PlayerController.weapon1ID;
        } else {
            PlayerController.currentWeapon = PlayerController.weapon1ID;
        }
    }

    public static void TextAlert(String message){
        HUDManager.TextAlert(message);
    }

    public static void KillBeez(){
        storyFlag = true;
        GameMaster.TextAlert("Story Complete!\nEnding Unlocked");
    }

    public static void UpdateScores(){
        string[] array = csvOfScores.Split("\n");
        foreach(string element in array){
            string[] x = element.Split(",");
            if(element.Length > 2){
                GameOverUI.AddScore(int.Parse(x[1]), x[0]);
            }else{
                return;
            }
        }
        

    }
}
