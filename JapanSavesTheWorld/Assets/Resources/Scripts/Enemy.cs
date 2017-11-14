using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[Header("References (Must not be null)")]
	[SerializeField]
	private ObjectPool missileObjectPool;

	void Awake() {
		Debug.Assert(this.missileObjectPool != null);
	}

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnMissile", 5.0f, 1.0f);
	}
	
	void SpawnMissile() {
		Missile missile = this.missileObjectPool.getUnusedObject().GetComponent<Missile>();
		missile.transform.position = this.transform.position;
		missile.transform.rotation = this.transform.rotation;
		missile.Initialize();
    }
}
