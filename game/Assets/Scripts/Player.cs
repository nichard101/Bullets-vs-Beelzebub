using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	// Private variables (not visible in the Inspector panel)
	// The speed of player movement
	public float speed = 5;
	
	bool atLeftWall = false;
	bool atRightWall = false;
	bool atTopWall = false;
	bool atBottomWall = false;

	public int health;

	//ArrayList enemyList = new ArrayList();

	void Start() {
	}
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "LeftWall") {
			atLeftWall = true;
		} else if(other.tag == "RightWall") {
			atRightWall = true;
		} else if(other.tag == "TopWall") {
			atTopWall = true;
		} else if(other.tag == "BottomWall") {
			atBottomWall = true;
		} else if(other.gameObject.tag == "EnemyProjectile"){
			Bullet b = other.GetComponent<Bullet>();
			Destroy(b.gameObject);
			GameMaster.PlayerHit(b.damage);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.tag == "LeftWall") {
			atLeftWall = false;
		} else if(other.tag == "RightWall") {
			atRightWall = false;
		} else if(other.tag == "TopWall") {
			atTopWall = false;
		} else if(other.tag == "BottomWall") {
			atBottomWall = false;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Enemy") {
			//enemyList.Add(other);
		}
	}

	void OnCollisionExit2D(Collision2D other) {
		if(other.gameObject.tag == "Enemy"){
			//enemyList.Remove(other);
		}
	}
	

	// Update is called once per frame
	void Update () {
		
		float movementX = Input.GetAxis("Horizontal");
		float movementY = Input.GetAxis("Vertical");

		if(atLeftWall && (movementX < 0)) {
			movementX = 0;
		}
		if(atRightWall && (movementX > 0)) {
			movementX = 0;
		}
		if(atTopWall && (movementY < 0)) {
			movementY = 0;
		}
		if(atBottomWall && (movementY > 0)) {
			movementY = 0;
		}

		// Move the player object
		transform.Translate( new Vector3(Time.deltaTime * speed * movementX,Time.deltaTime * speed * movementY,0), Space.World);	

		if(Input.GetButton("Jump")) {

		}
	}
}