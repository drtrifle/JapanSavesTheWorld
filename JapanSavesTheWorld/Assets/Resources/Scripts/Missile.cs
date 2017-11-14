using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

	[Header("References (Auto)")]
	[SerializeField]
	private Rigidbody2D rb;
	[SerializeField]
	private Collider2D cd;
	[SerializeField]
	private Animator animator;

	void Awake() {
		this.rb = this.GetComponent<Rigidbody2D>();
		this.cd = this.GetComponent<Collider2D>();
		this.animator = this.GetComponent<Animator>();
	}

	public void Initialize() {
		Debug.Log(this.gameObject.name + " initialized");
		this.gameObject.SetActive(true);

		this.rb.bodyType = RigidbodyType2D.Dynamic;
		this.cd.enabled = true;

		this.alreadyHit = false;
	}

    // Update is called once per frame
    void FixedUpdate() {
		this.rb.AddForce(transform.right);
    }

	void OnCollisionEnter2D(Collision2D collider) {
		if (!this.alreadyHit && (collider.gameObject.CompareTag("World") || collider.gameObject.CompareTag("Player"))) {
			this.alreadyHit = true;

			this.rb.bodyType = RigidbodyType2D.Static;
			this.cd.enabled = false;

			this.transform.position += this.transform.right * Random.Range(0.0f, 0.5f);

			// Explode animation
			this.animator.Play("Explosion");
		}
    }

	private bool alreadyHit = false;

	private void disable() {
		Debug.Log("Disable");
		this.gameObject.SetActive(false);
	}
}
