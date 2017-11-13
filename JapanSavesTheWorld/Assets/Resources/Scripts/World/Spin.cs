using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

	private Quaternion rotation;

	// Update is called once per frame
	void Update () {
		this.transform.RotateAround(Vector3.forward, Vector3.up, 10 * Time.deltaTime);
	}
}
