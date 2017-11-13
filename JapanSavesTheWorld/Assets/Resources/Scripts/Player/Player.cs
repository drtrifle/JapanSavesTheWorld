using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    GameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameManager.managerInstance;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "EnemyBullet") {
            gameManager.PlayerSuccessfullyBlockedMissile();
        }
    }
}
