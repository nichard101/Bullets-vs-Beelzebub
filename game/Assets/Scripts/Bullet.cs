using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{

    //public AudioClip hitSound;

    public int damage;
    public bool isEnemyProjectile;

    private void OnTriggerEnter2D(Collider2D collision){
        string[] tags = {"Bullet", "EnemyProjectile", "Resource", null};
        if(isEnemyProjectile){
            tags[3] = "Enemy";
        } else {
            tags[3] = "Player";
        }
        bool flag = true;
        foreach(string x in tags){
            if(x == collision.gameObject.tag) flag = false;
        }
        if(flag){
            //AudioSource.PlayClipAtPoint(hitSound, transform.position);
            Destroy(gameObject);
        }
        
    }
    void Update(){
        // Check if the game object is visible, if not, destroy self   
      if(!Utility.isVisible(GetComponent<Renderer>(), Camera.main)) {
         Destroy(gameObject);
      }
    }
}
