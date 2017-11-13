using UnityEngine;
using System.Collections;

public class Orbit2D : MonoBehaviour {

	[Header("References")]
	[SerializeField]
	private GameObject centerObject;

	[Header("Settings")]
	[SerializeField]
	public float rotationSpeed = 10.0f;

	private Vector3 desiredPosition;
	private float radius = 2.0f;

	void Start () {
		radius = ((Vector2) this.transform.position - (Vector2) centerObject.transform.position).magnitude;
	}

	void Update () {
		transform.RotateAround (this.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
		transform.position = 
			RotatePointAroundPivot(transform.position,
				centerObject.transform.position,
				Quaternion.Euler(0, 0, rotationSpeed * Time.deltaTime));
	}

	public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle) {
		return angle * (point - pivot) + pivot;
	}


}