using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameOverUI : MonoBehaviour
{
    public Text scoreText = null;
    public Text timeText = null;
    public Text killsText = null;
    public Text titleText = null;
    public InputField input;
    public Button MainButton;
    public string username = "";

    void Update()
    {   
        if(GameMaster.gameOver){
            titleText.text = "YOU DIED";
        } else {
            titleText.text = "GAME OVER";
        }
        TimeSpan finalTime = GameMaster.finishTime - GameMaster.startTime;
        Debug.Log(finalTime);

        scoreText.text = "Score: " + GameMaster.score;
        timeText.text = "Time: " + TimeSpan.FromSeconds((double)(new decimal(GameMaster.time))).ToString(@"mm\:ss");
        killsText.text = "Kills: " + GameMaster.kills;
        Debug.Log(GameMaster.score + " " + GameMaster.kills);
        Debug.Log(GameMaster.csvOfScores);
        if(username == ""){
            MainButton.interactable = false;
        } else {
            MainButton.interactable = true;
        }
    }

    public void MainMenu(){
        AddScore(GameMaster.score, username);
        SceneManager.LoadScene("MainMenu");
    }

    public static void AddScore(int score, string name){
        ArrayList userScore = new ArrayList(){name, score};
        if(GameMaster.scoreList.Count == 0){
            GameMaster.scoreList.Add(userScore);
        } else {
            ArrayList scores = new ArrayList();
            for(int i = 0; i < GameMaster.scoreList.Count; i++){
                ArrayList temp = (ArrayList)GameMaster.scoreList[i];
                int x = (int)temp[1];
                Debug.Log("hi " + x);
                scores.Add(x);
            }
            int position = 0;
            foreach(int s in scores){
                if(score > s){
                    Debug.Log(score);
                    GameMaster.scoreList.Insert(position, userScore);
                    break;
                }
                position++;
                if(position == GameMaster.scoreList.Count){
                    GameMaster.scoreList.Add(userScore);
                }
            }
        }
    }

    public void Name(string i){
        username = i;
        Debug.Log(username);
    }
}
