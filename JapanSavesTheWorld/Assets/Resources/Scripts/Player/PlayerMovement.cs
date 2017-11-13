using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[Header("Settings")]
	[SerializeField]
	private float maxSpeed = 0.5f;
	[SerializeField]
	private float timeToReachMaxSpeed = 0.3f;

	private Vector3 velocity = Vector3.zero;
	private Vector3 mousePosition;

	// Use this for initialization
	void Start() {
		Cursor.visible = false;
	}

	void LateUpdate() {
		// Update 
		this.mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		this.mousePosition.z = 0.0f;

		if (Input.GetMouseButton(0)) {
			// Shield superpower
			SlowerFollow();
		} else if (Input.GetMouseButton(1)) {
			// Hyperspeed superpower
			HyperSpeedFollow();
		} else {
			// Normal blocking mode
			NormalFollow();
		}
	}

	private void NormalFollow() {
		this.transform.position = Vector3.SmoothDamp(this.transform.position, mousePosition, ref this.velocity, timeToReachMaxSpeed, this.maxSpeed);
	}

	private void HyperSpeedFollow() {
		this.transform.position = Vector3.SmoothDamp(this.transform.position, mousePosition, ref this.velocity, 0.01f, this.maxSpeed * 2.0f);
	}

	private void SlowerFollow() {
		this.transform.position = Vector3.SmoothDamp(this.transform.position, mousePosition, ref this.velocity, timeToReachMaxSpeed, this.maxSpeed * 0.75f);
	}
}
