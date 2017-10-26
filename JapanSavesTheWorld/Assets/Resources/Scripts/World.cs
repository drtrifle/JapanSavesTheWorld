using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    public float scaleFactor = 0.01f;

    GameManager gameManager;

    // Use this for initialization
    void Start() {
        gameManager = GameManager.managerInstance;
    }

    // Update is called once per frame
    void Update() {
    }

    //Called By GameManager when player successfuly blocks a missile
    public void ScaleWorld() {
        transform.localScale += new Vector3(scaleFactor, scaleFactor, 0);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "EnemyBullet")
        {
            gameManager.PlayerFailedToBlockMissile();
        }
    }
}
