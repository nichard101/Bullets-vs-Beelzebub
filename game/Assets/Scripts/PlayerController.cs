using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public static int souls = 0;

    public Weapon weapon1;
    public Weapon weapon2;
    public static string weapon1ID;
    public static string weapon2ID;
    public static string otherWeaponID;
    public static string currentWeapon = "SMG";

    public static bool testing = false;

    public static float moveSpeed = 10f;
    public static int multiShot = 0;
    public int multiShotTesting; // to set multiShot in unity editor whilst keeping multishot static;
    public static float projectileSpeedMultiplier = 1f;              // below "testing" variables are the same
    public float projectileSpeedTesting; //                  // these are accessed in Testing()
    public static float fireRateMultiplier = 1f;
    public float fireRateTesting; // 
    public static float damageMultiplier = 2f;
    public float damageTesting; // 
    public static float knockbackMultiplier = 1f;
    public float knockbackTesting; // 
    public static float reloadSpeedMultiplier = 1f;
    public float reloadSpeedTesting;
    public static float healthRegenMultiplier = 1f;
    public float healthRegenTesting;
    public static float damageResistanceMultiplier = 1f;
    public float damageResistanceTesting;
    public static float fireCooldownFrames = 200;

    bool mouseHasBeenClicked;
    static bool upgradeMessage = false;

    static bool machineGunUnlocked = false;
    static bool minigunUnlocked = false;

    float fireCooldownFramesLeft = 0; 

    public GameObject takeDamage;

    Vector2 moveDirection;
    Vector2 mousePosition;

    //TONY'S TESTING START
    public Sprite[] animSprites;
    SpriteRenderer animRenderer;
    bool wingsOpen;
    float timeSinceSpriteChange;
    //TONY'S TESTING END

    public static ArrayList weaponList;

    void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "EnemyProjectile"){
			Bullet b = other.GetComponent<Bullet>();
			Destroy(b.gameObject);
			GameMaster.PlayerHit(b.damage);

            TakeDamage();
		}
	}

    void Start(){
        weaponList = new ArrayList();
        PlayerController.weaponList.Add("Empty");
        PlayerController.weaponList.Add("SMG");
        weapon1ID = "SMG";
        weapon2ID = "Empty";
        multiShotTesting = multiShot;
        projectileSpeedTesting = projectileSpeedMultiplier;
        fireRateTesting = fireRateMultiplier;
        damageTesting = damageMultiplier;
        knockbackTesting = knockbackMultiplier;
        reloadSpeedTesting = reloadSpeedMultiplier;
        healthRegenTesting = healthRegenMultiplier;
        damageResistanceTesting = damageResistanceMultiplier;
        GameMaster.HUDManager = GameObject.Find("PauseMenu").GetComponent<HUDManager>();

        //TONY'S TESTING START
        animRenderer = GetComponent<Renderer>() as SpriteRenderer;
        //TONY'S TESTING END
    }

    // Update is called once per frame
    void Update()
    {        
        if(damageMultiplier < 0.1f){
            damageMultiplier = 0.1f;
        }
        if(!GameMaster.pause){
            GameMaster.time += Time.deltaTime;
            if(testing){
                Testing();
            }

            if(souls >= UpgradeMenuManager.lowestCost){
                if(upgradeMessage){
                    GameMaster.TextAlert("Upgrades are available!");
                    upgradeMessage = false;
                }
            } else {
                upgradeMessage = true;
            }

            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            if(fireCooldownFramesLeft > 0) {
                fireCooldownFramesLeft--;
            }

            
            if(Input.GetMouseButtonDown(0)){
                mouseHasBeenClicked = true;
            }

            if(mouseHasBeenClicked){
                if(currentWeapon == weapon1ID){
                    currentWeapon = weapon2ID;
                }else{
                    currentWeapon = weapon1ID;
                }
                GameMaster.SwapWeapons();
                fireCooldownFramesLeft = (fireCooldownFrames / weapon1.fireRate) / fireRateMultiplier;
            }
            mouseHasBeenClicked = false;

            if(fireCooldownFramesLeft <= 0){
                weapon1.Fire();
                fireCooldownFramesLeft = (int)(fireCooldownFrames / weapon1.fireRate); 
            }     

            moveDirection = new Vector2(moveX, moveY).normalized;
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            //TONY'S TESTING START
            timeSinceSpriteChange += Time.deltaTime;
            if(timeSinceSpriteChange >= 0.25f){
                timeSinceSpriteChange = 0f;
                if(wingsOpen){
                    animRenderer.sprite = animSprites[1];
                    wingsOpen = false;
                }else{
                    animRenderer.sprite = animSprites[0];
                    wingsOpen = true;
                }
            }

            //if(GameMaster.playerHealth)
            //TONY'S TESTING END
        }

        if(GameMaster.score > 1000 && !machineGunUnlocked){
            weaponList.Add("MachineGun");
            machineGunUnlocked = true;
            GameMaster.TextAlert("Unlocked Machine Gun");
        }else if(GameMaster.score > 4000 && !minigunUnlocked){
            weaponList.Add("Minigun");
            minigunUnlocked = true;
            GameMaster.TextAlert("Unlocked Minigun");
        }
        
    }

    private void FixedUpdate(){
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    private void Testing(){
        multiShot = multiShotTesting;
        projectileSpeedMultiplier = projectileSpeedTesting;
        fireRateMultiplier = fireRateTesting;
        damageMultiplier = damageTesting;
        knockbackMultiplier = knockbackTesting;
        reloadSpeedMultiplier = reloadSpeedTesting;
        healthRegenMultiplier = healthRegenTesting;
        damageResistanceMultiplier = damageResistanceTesting;
    }

    public static void Reset(){
        moveSpeed = 10f;
        multiShot = 0;
        projectileSpeedMultiplier = 1f;              // below "testing" variables are the same
        fireRateMultiplier = 1f;
        damageMultiplier = 2f;
        knockbackMultiplier = 1f;
        reloadSpeedMultiplier = 1f;
        healthRegenMultiplier = 1f;
        damageResistanceMultiplier = 1f;
        fireCooldownFrames = 200;
        machineGunUnlocked = false;
        minigunUnlocked = false;
        upgradeMessage = true;
        EnemySpawner.multiplier = 5;
        GameMaster.enemySpeedMultiplier = 1;
        GameMaster.enemyHealthMultiplier = 1;
    }

    public void TakeDamage(){        
        Instantiate(takeDamage, transform.position, transform.rotation);    
    }
}
