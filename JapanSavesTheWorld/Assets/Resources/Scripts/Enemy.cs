using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject MissilePrefab;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnMissile",2.0f,0.3f);
	}
	
	void SpawnMissile()
    {
        Instantiate(MissilePrefab, transform.position, transform.rotation);
    }
}
