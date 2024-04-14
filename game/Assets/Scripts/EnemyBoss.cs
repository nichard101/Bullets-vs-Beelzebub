using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering.Universal;


public class EnemyBoss : MonoBehaviour
{
    GameObject player;
    public GameObject fireball;
    public float distance;

    public float proximity;
    Vector3 playerPos;
    Enemy boss;

    public int atkCooldown;
    DateTime rAttackTime;
    DateTime cAttackTime;
    //Light2D light;
    Color color;

    //TONY'S TESTING START
    //TONY'S TESTING END

    //TONY'S TESTING START
    public Sprite[] animSprites;
    SpriteRenderer animRenderer;
    bool attacking;
    float timeAsAttackSprite;
    //TONY'S TESTING END

    void Start() {
        rAttackTime = System.DateTime.Now.AddSeconds(atkCooldown);
        cAttackTime = System.DateTime.Now.AddSeconds(atkCooldown);
        player = GameObject.FindWithTag("Player");

        //TONY'S TESTING START
        animRenderer = GetComponent<Renderer>() as SpriteRenderer;
        //TONY'S TESTING END
    }
    
    void Update()
    {   
        if(!GameMaster.pause){
            playerPos = player.transform.position;

            if(Vector2.Distance(playerPos,this.transform.position) >= proximity){
                if(System.DateTime.Now >= rAttackTime){
                    FireWave();

                    //TONY'S TESTING START
                    attacking = true;
                    timeAsAttackSprite = 0;
                    animRenderer.sprite = animSprites[1];
                    //TONY'S TESTING END
                }
            } else {
                if(System.DateTime.Now >= cAttackTime){
                    Charge();
                }
            }

            timeAsAttackSprite += Time.deltaTime;
            if(attacking && timeAsAttackSprite >= 0.5f){
                attacking = false;
                animRenderer.sprite = animSprites[0];
            }
        }
    }



    void FireWave(){
        Vector3 direction = playerPos - this.transform.position;

        Vector2 center = transform.position;

        //StartCoroutine(ColorChangeSequence(light, new Color(255, 165, 0), 3f, 0));

        for(int i = -3; i < 4; i++){
            float a = -(i*30);
            Vector2 pos = RandomCircle(center, distance, a + Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg);
            GameObject fb = Instantiate(fireball, pos, Quaternion.identity);
            fb.GetComponent<Fireball>().direction = fb.transform.position - this.transform.position;
            fb.transform.rotation = Quaternion.Euler(direction);
        }

        //StartCoroutine(ColorChangeSequence(light, color, 3f, 0));

        rAttackTime = System.DateTime.Now.AddSeconds(atkCooldown);
    }

    void Charge() {
        //StartCoroutine(ColorChangeSequence(light, Color.blue, 3f, 0));
        cAttackTime = System.DateTime.Now.AddSeconds(atkCooldown);
    }

    Vector2 RandomCircle(Vector2 center, float radius, float a){
        Debug.Log("angle " + a);
        float ang = a;
        Vector2 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }

    IEnumerator ColorChangeSequence(Light2D l, Color dmgColor, float duration, float delay)
	{
		// you can delay the animation
		yield return new WaitForSeconds(delay); 

        Color originColor = l.color;

		// lerp animation with given duration in seconds
		for (float t = 0; t < 1.0f; t += Time.deltaTime/duration)
		{
			l.color = Color.Lerp(originColor, dmgColor , t);

			yield return null;
		}
	}
}
