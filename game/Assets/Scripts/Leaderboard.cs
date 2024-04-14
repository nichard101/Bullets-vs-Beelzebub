using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Text;


public class Leaderboard : MonoBehaviour
{   
    private static readonly HttpClient client = new HttpClient();
    public Text scores = null;

    void Start(){

            int num = 1;
            string text = "";
            foreach(ArrayList score in GameMaster.scoreList){
                string name = score[0].ToString();
                int sc = (int)score[1];
                text += (num + ". " + name + " " + sc + "\n");
                num++;
            }
            scores.text = text;
    }

    async public static void PostScore(string name, int score){
        string myJson = "{\"id\": \"" + name + "\", \"text\": \"" + score + "\"}";
        HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                response = await client.PostAsync(
                    "http://210.54.238.3:25565/append-to-csv", 
                    new StringContent(myJson, Encoding.UTF8, "application/json"));
            }
            Debug.Log(response);
            GetScores();
    }

    async public static void GetScores(){
        HttpResponseMessage response;
        string result = "";
            using (var client = new HttpClient())
            {
                response = await client.GetAsync("http://210.54.238.3:25565/get-csv");
            }
            if (response.IsSuccessStatusCode)
            {
                HttpContent content = response.Content;
                result = await content.ReadAsStringAsync();
            }
            GameMaster.csvOfScores = result;
            Debug.Log(GameMaster.csvOfScores);
            GameMaster.UpdateScores();
    }
}
