using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    GameObject player;
    public GameObject enemyBullet;
    SpriteRenderer rend;
    public GameObject resource;
    public GameObject healthResource;
    public GameObject bossResource;
    ArrayList colorList;

    public float speed;
    public bool isMelee;
    public int damage;
    public int score;
    
    public int health;
    public float attackSpeed;
    bool playerContact = false;
    private float distance;
    private float attackCooldown;
    public bool isBoss;

    public GameObject healthTriangle;
    float startingHealth;

    public Sprite[] animSprites;
    SpriteRenderer animRenderer;
    bool wingsOpen;
    float timeSinceSpriteChange;
    public bool flyingDemon;

    public GameObject dyingEnemy;
    public bool beez;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Bullet") {
            Hit(); 
		}
	}

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject == player){
            playerContact = true;
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject == player){
            playerContact = false;
        }
    }

    void Start() {
        this.speed *= GameMaster.enemySpeedMultiplier;
        this.health = (int)(this.health * GameMaster.enemyHealthMultiplier);
        player = GameObject.FindWithTag("Player");
        AIDestinationSetter enemy = GetComponent<AIDestinationSetter>();
        enemy.target = player.transform;
        rend = GetComponent<SpriteRenderer>();
        colorList = new ArrayList();

        var triRenderer = healthTriangle.GetComponent<Renderer>();
        triRenderer.material.SetColor("_Color", Color.green);

        //TONY'S TESTING START
        animRenderer = GetComponent<Renderer>() as SpriteRenderer;
        startingHealth = health;
        //TONY'S TESTING END
    }

    void Update()
    {
        if(!GameMaster.pause){
            attackCooldown -= Time.deltaTime;
            if(attackCooldown <= 0){
                if(isMelee){
                    if(playerContact){
                        Attack();
                    }
                } else {
                    if(Utility.isVisible(GetComponent<Renderer>(), Camera.main)) {
                        Fire();
                    }
                }
                attackCooldown = attackSpeed;
            }

            //TONY'S TESTING START
            timeSinceSpriteChange += Time.deltaTime;
            if(flyingDemon && timeSinceSpriteChange >= 0.25f){
                timeSinceSpriteChange = 0f;
                if(wingsOpen){
                    animRenderer.sprite = animSprites[1];
                    wingsOpen = false;
                }else{
                    animRenderer.sprite = animSprites[0];
                    wingsOpen = true;
                }
            }
        }
        //TONY'S TESTING END
    }

    void Attack(){
        StartCoroutine(ColorChangeSequence(rend, Color.blue, 0.5f, 0));
        attackCooldown = attackSpeed;
        GameMaster.PlayerHit(damage);
    }

    IEnumerator ColorChangeSequence(SpriteRenderer sr, Color dmgColor, float duration, float delay)
	{
		// save origin color
        colorList.Add(sr.color);
		Color originColor = sr.color;

		// tint the sprite with damage color
		sr.color = dmgColor;

		// you can delay the animation
		yield return new WaitForSeconds(delay);

		// lerp animation with given duration in seconds
		for (float t = 0; t < 1.0f; t += Time.deltaTime/duration)
		{
			sr.color = Color.Lerp(dmgColor, originColor , t);

			yield return null;
		}

		// restore origin color
		sr.color = (Color)colorList[0];
        colorList.Remove(0);
	}

    public void Hit(){
        StartCoroutine(ColorChangeSequence(rend, Color.black, 0.5f, 0));
        
        health -= (int)(Weapon.bulletDamage * PlayerController.damageMultiplier);
        if(health <= 0){
            Instantiate(dyingEnemy, transform.position, transform.rotation);
            GameMaster.enemyCount--;
            Destroy(this.gameObject);
            GameMaster.score += score;
            if(beez){
                GameMaster.KillBeez();
            }
            if(isBoss){
                Instantiate(bossResource, transform.position, transform.rotation);
            }else{
                if(GameMaster.resourceCount <= 100){
                    if(GameMaster.randomInt(0, 5) == 4){
                        Instantiate(healthResource, transform.position, transform.rotation);
                    } else {
                        Instantiate(resource, transform.position, transform.rotation);
                    }
                    GameMaster.resourceCount++;
                }
                if(GameMaster.enemyList.IndexOf(gameObject) != -1){
                    GameMaster.enemyList.Remove(gameObject);
                    GameMaster.kills++;
                }
            }
        }

        //Instantiate(bloodSplatter, transform.position, transform.rotation);

        //TONY'S TEST
        if((float)health / startingHealth < 0.33){
            var triRenderer = healthTriangle.GetComponent<Renderer>();
            triRenderer.material.SetColor("_Color", Color.red);
        }
        else if((float)health / startingHealth < 0.66){
            var triRenderer = healthTriangle.GetComponent<Renderer>();
            triRenderer.material.SetColor("_Color", Color.yellow);
        }
        //TONY'S TEST
    }

    void Fire(){
        GameObject b = Instantiate(enemyBullet);
        b.GetComponent<Bullet>().damage = damage;
        b.transform.SetParent(this.transform);
        b.transform.position = transform.position;
    }
}