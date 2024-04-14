using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;

    public PlayerController player;

    Vector2 moveDirection;
    public float moveSpeed = 5f;

    public AudioClip popSound;

    public bool isHealth;

    public bool isBoss;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameMaster.pause){
        if(player != null){
            float playerX = player.transform.position.x;
            float playerY = player.transform.position.y;

            float currentX = transform.position.x;
            float currentY = transform.position.y;

            float x = playerX - currentX;
            float y = playerY - currentY;

            moveDirection = new Vector2(x, y).normalized;

            if(Vector3.Distance(player.transform.position, transform.position) < 0.5f){
                AudioSource.PlayClipAtPoint(popSound, transform.position);
                
                if(isBoss){
                    GameMaster.playerHealth += 200;
                    PlayerController.souls += 30;
                }else{
                    if(isHealth){
                        GameMaster.playerHealth += 20;
                        if(GameMaster.playerHealth > 1000){
                            GameMaster.playerHealth = 1000;
                        }
                    } else {
                        PlayerController.souls += 1;
                    }
                }

                
                GameMaster.resourceCount--;
                Destroy(gameObject);
            }
        }
        }
    }
    
    void OnTriggerEnter2D(Collider2D other){
      if (other.tag == "Player"){
        player = other.GetComponent<PlayerController>();
      }
    }

   private void FixedUpdate(){
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
