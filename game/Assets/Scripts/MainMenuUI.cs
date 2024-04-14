using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{   

    public Button HordeButton;
    [SerializeField] Slider volumeSlider;

    void Start(){
        Leaderboard.GetScores();
        if(GameMaster.scoreList.Count == 0){
            GameOverUI.AddScore(5000, "Tony");
            Debug.Log("a");
            GameOverUI.AddScore(10000, "Will");
            Debug.Log("b");
            GameOverUI.AddScore(15000, "Nick");
            Debug.Log("c");
        }
        AudioListener.volume = GameMaster.volume;
    }

    public void StartGame(){
        GameMaster.Reset();
        SceneManager.LoadScene("Level1 1");
    }

    public void LeaderboardMenu(){
        SceneManager.LoadScene("Leaderboard");
    }

    public void Story(){
        SceneManager.LoadScene("Story");
    }

    public void Controls(){
        SceneManager.LoadScene("Controls");
    }

    public void Credits(){
        SceneManager.LoadScene("Credits");
    }

    public void Options(){
        SceneManager.LoadScene("Options");
    }

    public void ReturnToMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void ChangeVolume(){
        AudioListener.volume = volumeSlider.value;
        GameMaster.volume = volumeSlider.value;
    }
}