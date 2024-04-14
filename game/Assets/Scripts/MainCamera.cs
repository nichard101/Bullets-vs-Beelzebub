using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    GameObject player;
    public float followDistance;
    public float followSpeed;

    void Start(){
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if(distance >= followDistance){
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, followSpeed * Time.deltaTime);
        } else if(distance > 0){
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, followSpeed * Time.deltaTime * 0.5f);
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
