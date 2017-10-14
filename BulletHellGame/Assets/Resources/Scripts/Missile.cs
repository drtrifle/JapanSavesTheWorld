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
}
