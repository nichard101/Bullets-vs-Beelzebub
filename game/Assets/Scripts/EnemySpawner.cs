using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject boss;
    public GameObject beelzebub;
    public float cooldownTime;
    public bool isTopRightEnemySpawner;
    public static bool isActive = true;
    public static bool flag = true;
    public static int tick = 1;
    public static bool endSpawn = false;
    System.DateTime countdown;
    public static double multiplier = 4.5;

    public static int frame = 0;

    public static bool bossSpawnedYet = true;
    public static bool beezSpawnedYet = false;

    // Update is called once per frame
    void Update()
    {   
        if(!GameMaster.pause){
            frame++;
            Debug.Log(multiplier);
            if(frame % (int)(10 * multiplier) == 0){
                //countdown = System.DateTime.Now.AddSeconds(cooldownTime);
                Spawn();
                if(GameMaster.playerHealth < 1000){
                    GameMaster.playerHealth += (int)(PlayerController.healthRegenMultiplier * 1);
                }
            }
            Debug.Log(multiplier);
        }
    }

    void Spawn(){
        if(GameMaster.enemyCount < 200){
            bool r = GameMaster.randomBool();
            bool r2 = GameMaster.randomBool();
            int x = 0;
            int y = 0;
            int transformMultiplier = 1;

            GameObject e;

                bool enemyTypeFlag = GameMaster.randomBool();
                
                if(isActive){

                    if(GameMaster.score % 1000 > 800){
                        bossSpawnedYet = false;
                    }
                    if(GameMaster.score > 10000 && !beezSpawnedYet){
                            e = Instantiate(beelzebub);
                            e.transform.position = new Vector3(0, 0, 0);
                            beezSpawnedYet = true;
                            if(multiplier < 3){
                                multiplier = multiplier * 0.95;
                            }
                            multiplier = multiplier * 0.9;
                            PlayerController.damageMultiplier = PlayerController.damageMultiplier * 0.99f;
                    }else if(GameMaster.score % 1000 < 800 && GameMaster.score > 800 && !bossSpawnedYet){
                        e = Instantiate(boss);
                        int spawnPos = GameMaster.randomInt(0, 4);
                        if(spawnPos == 0) e.transform.position = new Vector3(-45, 0, 0);
                        if(spawnPos == 1) e.transform.position = new Vector3(45, 0, 0);
                        if(spawnPos == 2) e.transform.position = new Vector3(0, -47, 0);
                        if(spawnPos == 3) e.transform.position = new Vector3(45, 0, 0);
                        bossSpawnedYet = true;
                        if(multiplier < 3){
                            if(multiplier < 2){
                                if(multiplier < 1){
                                    multiplier = multiplier * 0.95;
                                    GameMaster.enemySpeedMultiplier *= 1.02f;
                                    GameMaster.enemyHealthMultiplier *= 1.01f;
                                }else{
                                    multiplier = multiplier * 0.9;
                                    //PlayerController.damageMultiplier = PlayerController.damageMultiplier * 0.99f;
                                    
                                    GameMaster.enemySpeedMultiplier *= 1.02f;
                                    GameMaster.enemyHealthMultiplier *= 1.01f;
                                }
                            }else{
                                multiplier = multiplier * 0.8;
                                //PlayerController.damageMultiplier = PlayerController.damageMultiplier * 0.98f;
                                GameMaster.enemySpeedMultiplier *= 1.05f;
                                GameMaster.enemyHealthMultiplier *= 1.02f;
                            }
                        }else{
                            multiplier = multiplier * 0.7;
                            //PlayerController.damageMultiplier = PlayerController.damageMultiplier * 0.95f;
                            GameMaster.enemySpeedMultiplier *= 1.05f;
                            GameMaster.enemyHealthMultiplier *= 1.02f;
                        }

                    }else{
                        if(enemyTypeFlag){
                            e = Instantiate(enemy);
                        }else{
                            e = Instantiate(enemy2);
                        }
                        if(r){
                            x = GameMaster.randomInt(0, 87) * transformMultiplier;
                        } else {
                            y = GameMaster.randomInt(0, 85) * transformMultiplier;
                        }
                        if(r2){
                            e.transform.position = new Vector3(42 - x, 40 - y, 0);
                        }else{
                            e.transform.position = new Vector3(-42 + x, -44 + y, 0);
                        }
                        
                        GameMaster.enemyList.Add(e);
                    }
                    GameMaster.enemyCount++;
                    
                }
                    
                }
                
            //}
            if(multiplier <= 0.10){
                multiplier = 0.10;
            }
        }
        
    

    public static void Deactivate(){
        isActive = false;
    }

    public static void Activate(){
        isActive = true;
    }
}
