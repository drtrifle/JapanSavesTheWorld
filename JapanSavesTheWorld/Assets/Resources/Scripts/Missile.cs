using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

	[Header("References (Auto)")]
	[SerializeField]
	private Rigidbody2D rb;
	[SerializeField]
	private BoxCollider2D bc;
	[SerializeField]
	private Animator animator;

	void Awake() {
		this.rb = this.GetComponent<Rigidbody2D>();
		this.bc = this.GetComponent<BoxCollider2D>();
		this.animator = this.GetComponent<Animator>();
	}

	void Initialize() {
		this.rb.bodyType = RigidbodyType2D.Dynamic;
		this.bc.enabled = true;

		this.alreadyHit = false;
	}

    // Update is called once per frame
    void FixedUpdate() {
		this.rb.AddForce(transform.right);
    }

	void OnCollisionEnter2D(Collision2D collider) {
		if (!this.alreadyHit && (collider.gameObject.CompareTag("World") || collider.gameObject.CompareTag("Player"))) {
			StartCoroutine(hitSequence());
		}
    }

	private bool alreadyHit = false;

	private IEnumerator hitSequence() {
		this.alreadyHit = true;

		this.rb.bodyType = RigidbodyType2D.Static;
		this.bc.enabled = false;

		// Explode animation
		this.animator.Play("Explosion");
		yield return new WaitForSeconds(getAnimationLength(this.animator));
		this.gameObject.SetActive(false);
	}

	public static float getAnimationLength(Animator animator) {
		return animator.GetCurrentAnimatorStateInfo(0).length + animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
	}
}
