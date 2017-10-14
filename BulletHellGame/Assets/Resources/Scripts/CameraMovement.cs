using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	[SerializeField]
	private SpriteRenderer background;

	private Vector2 backgroundDimensions;
	private Vector2 backgroundBLCoords;
	private Vector2 cameraHalfDimensions;

	private float cameraHeight;
	private float cameraWidth;

	void Start() {
		Debug.Assert(this.background != null);

		this.backgroundDimensions = ((Vector2) this.background.bounds.extents) * 2f;
		this.backgroundBLCoords = (Vector2) this.background.bounds.min;
		this.cameraHalfDimensions = (Vector2) Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f));
	}

	void Update() {
		// Fraction of the mouse across the screen. Top right = 1,1 and bottom left and 0,0
		Vector2 mouseFrac = (Vector2) Camera.main.ScreenToViewportPoint(Input.mousePosition);

		Vector3 newCameraPosition;
		// Camera position will be always within the picture
		newCameraPosition.x = this.backgroundBLCoords.x + Mathf.Lerp(this.cameraHalfDimensions.x, this.backgroundDimensions.x - this.cameraHalfDimensions.x, mouseFrac.x);
		newCameraPosition.y = this.backgroundBLCoords.y + Mathf.Lerp(this.cameraHalfDimensions.y, this.backgroundDimensions.y - this.cameraHalfDimensions.y, mouseFrac.y);
		newCameraPosition.z = this.transform.position.z;

		// Set the new position to the camera
		this.transform.position = Vector3.Lerp(this.transform.position, newCameraPosition, 0.02f);
	}
}
