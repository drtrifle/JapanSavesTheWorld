using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

	public float scaleFactor = 0.01f;

	[Header("Additional Settings")]
	[SerializeField]
	private float jitterWhenHitMultiplier = 0.3f;
	[SerializeField]
	private float jitterWhenHitDuration = 0.5f;

	GameManager gameManager;

	// Use this for initialization
	void Start() {
		gameManager = GameManager.managerInstance;
	}

	// Update is called once per frame
	void Update() {
	}

	//Called By GameManager when player successfuly blocks a missile
	public void ScaleWorld() {
		transform.localScale += new Vector3(scaleFactor, scaleFactor, 0);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "EnemyBullet") {
			gameManager.PlayerFailedToBlockMissile();
			jitterFor(this.jitterWhenHitDuration);
		}
	}

	#region Jitter

	private void jitterFor(float duration) {
		StartCoroutine(jitter(duration));
	}

	private IEnumerator jitter(float duration) {
		float t = 0;
		Vector3 originalPosition = this.transform.localPosition;

		while ((t += Time.deltaTime) < duration) {
			this.transform.localPosition = originalPosition + getJitter();
			yield return null;
		}

		this.transform.localPosition = originalPosition;
	}

	private Vector3 getJitter() {
		return new Vector3(
			Random.Range(-this.jitterWhenHitMultiplier, this.jitterWhenHitMultiplier), 
			Random.Range(-this.jitterWhenHitMultiplier, this.jitterWhenHitMultiplier),
			0
		);
	}

	#endregion
}
