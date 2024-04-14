using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;
    int counter = 0;

    public void SpawnBoss(){
        Vector3 coords;
        if(counter<2){
            coords.y = 20;
            if(counter==0){
                coords.x = -20;
            } else {
                coords.x = 20;
            }
        } else if(counter<4){
            coords.y = -8;
            if(counter==2){
                coords.x = 25;
            } else {
                coords.x = -25;
            }
        } else {
            coords.y = -30;
            coords.x = 0;
            counter = 0;
        }
        coords.z = 0;
        counter++;

        GameObject e = Instantiate(bossPrefab, coords, Quaternion.identity);
        GameMaster.enemyList.Add(e);
    }

    public void SpawnFinalBoss(){
        counter = 0;
        for(int i = 0; i < 5; i++){
            SpawnBoss();
        }
    }
}
