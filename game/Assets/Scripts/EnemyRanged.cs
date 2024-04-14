using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyRanged : MonoBehaviour
{
    GameObject player;
    Enemy enemy;
    public float proximity;

    float speed;
    private float distance;
    Vector2 direction;
    private float angle;
    AIDestinationSetter AI;
    AIPath path;

    void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Enemy") {
			direction = transform.position - other.transform.position;
		}
	}

    void Start() {
        player = GameObject.FindWithTag("Player");
        enemy = GetComponent<Enemy>();
        AI = GetComponent<AIDestinationSetter>();
        AI.target = player.transform;
        path = GetComponent<AIPath>();
        speed = enemy.speed;
        path.maxSpeed = speed;
    }

    void Update()
    {
        if(!GameMaster.pause){
        Vector2 pos = player.transform.position;
        Vector2 thisPos = transform.position;
        distance = Vector2.Distance(thisPos, pos);

        if(distance >= 1.2*proximity){
            path.maxSpeed = speed;
        } else if(distance <= 0.8*proximity){
            path.maxSpeed = 0;
            MoveAway(thisPos, pos);
        } else {
            path.maxSpeed = 0;
        }
        }
    }

    void MoveTo(Vector2 thisPos, Vector2 playerPos){
        transform.position = Vector2.MoveTowards(thisPos, playerPos, speed * Time.deltaTime);
    }

    void MoveAway(Vector2 thisPos, Vector2 playerPos){
        transform.position = Vector2.MoveTowards(thisPos, thisPos - playerPos, speed * Time.deltaTime);
    }
}