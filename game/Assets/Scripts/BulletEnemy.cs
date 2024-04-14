using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletEnemy : MonoBehaviour
{
    public float speed;

    public int damage = 1;

    void Update()
    {   
        gameObject.GetComponent<Rigidbody2D>().AddForce(this.transform.parent.up * speed, ForceMode2D.Impulse);
        if(!Utility.isVisible(GetComponent<Renderer>(), Camera.main)) {
            Destroy(gameObject);
        }

    }
}
