using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    public float lifetime = 2.0f;

    // Use this for initialization
    void Start() {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void FixedUpdate() {
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
