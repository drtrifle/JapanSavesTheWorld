﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[Header("Settings")]
	[SerializeField]
	private float maxSpeed = 0.5f;
	[SerializeField]
	private float timeToReachMaxSpeed = 0.3f;

	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start() {
		Cursor.visible = false;
	}

	void LateUpdate() {
		if (Input.GetMouseButton(0)) {
			// Shield superpower
		} else if (Input.GetMouseButton(1)) {
			// Hyperspeed superpower
		} else {
			FollowMousePosition();
		}
	}

	void FollowMousePosition() {
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition.z = 0.0f;

		this.transform.position = Vector3.SmoothDamp(this.transform.position, mousePosition, ref this.velocity, timeToReachMaxSpeed, this.maxSpeed);
	}
}