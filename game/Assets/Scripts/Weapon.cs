using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{   

    public int fireRate;
    public float projectileSpeed;
    public int ammoUsage;             //set these to pistol as it's the starter gun
    public static int bulletDamage = 1;
    public int knockback;
    public bool isThrowable;

    //public AudioClip shootSound;


    public GameObject bulletPrefab;
    public Transform firePoint;
    
    public int weaponFrames = 0;

    public void Fire(){
        //AudioSource.PlayClipAtPoint(shootSound, transform.position);
        if(PlayerController.currentWeapon == "MachineGun"){
            fireRate = (int)(10 * PlayerController.fireRateMultiplier);
            projectileSpeed = 50f * PlayerController.projectileSpeedMultiplier;
            ammoUsage = 2;
            bulletDamage = (int)(4 * PlayerController.damageMultiplier);
            knockback = 1;
            GenerateBullets();
        }else if(PlayerController.currentWeapon == "SMG"){
            fireRate = (int)(20 * PlayerController.fireRateMultiplier);
            projectileSpeed = 50f * PlayerController.projectileSpeedMultiplier;
            ammoUsage = 1;
            bulletDamage = (int)(2 * PlayerController.damageMultiplier);
            knockback = 3;
            GenerateBullets();
        }else if(PlayerController.currentWeapon == "Minigun"){
            fireRate = (int)(80 * PlayerController.fireRateMultiplier);
            projectileSpeed = 80f * PlayerController.projectileSpeedMultiplier;
            ammoUsage = 1;
            bulletDamage = (int)(1 * PlayerController.damageMultiplier);
            knockback = 5;
            GenerateBullets();
        }
        
    
    }

    public void GenerateBullets(){
        if(PlayerController.multiShot != 1){
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * (projectileSpeed * 0.5f), ForceMode2D.Impulse);
        }
        if(PlayerController.multiShot > 0){
            int counter = 2 * PlayerController.multiShot;
            float f = 0.1f;
            while(counter > 0){
                GameObject bullet2 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                GameObject bullet3 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                bullet2.GetComponent<Rigidbody2D>().AddForce((((firePoint.up + (firePoint.right * f)) / 2)) * (projectileSpeed ), ForceMode2D.Impulse);
                bullet3.GetComponent<Rigidbody2D>().AddForce((((firePoint.up - (firePoint.right * f)) / 2)) * (projectileSpeed ), ForceMode2D.Impulse);
                counter -= 2;
                f += 0.1f;
            }
        }
    }
}
