using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    public float scaleFactor = 0.01f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //ScaleWorld();
    }

    public void ScaleWorld() {
        transform.localScale += new Vector3(scaleFactor, scaleFactor, 0);
    }
}
