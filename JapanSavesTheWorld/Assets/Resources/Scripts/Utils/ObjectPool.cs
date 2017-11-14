using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

	[Header("Prefab")]
	[SerializeField]
	private GameObject prefab = null;

	[Header("Starting number of prefab")]
	[SerializeField]
	private int prefabStartingNum = 0;

	[Header("Maximum number of prefab")]
	[SerializeField]
	private int prefabMaxNum = 0;

	private LinkedList<GameObject> prefabs;

	void Awake() {
		Debug.Assert(this.prefab != null);
		Debug.Assert(this.prefabStartingNum > 0);
		Debug.Assert(this.prefabMaxNum > 0);
		Debug.Assert(this.prefabStartingNum < this.prefabMaxNum);

		this.prefabs = new LinkedList<GameObject>();
	}

	#region Setup

	private GameObject instantiated;

	// Use this for initialization
	void Start () {
		createPool();
	}

	private void createPool() {
		for (int i = 0; i < this.prefabStartingNum; i++) {
			createAndAddToPool();
		}
	}

	private void createAndAddToPool() {
		this.instantiated = Instantiate(prefab, this.transform) as GameObject;
		setSettings(this.instantiated);

		this.prefabs.AddLast(this.instantiated);
	}

	private void setSettings(GameObject gameObject) {
		this.instantiated.name = this.prefab.name + " " + this.prefabs.Count;
		gameObject.SetActive(false);
	}

	#endregion

	#region Pool Management

	public GameObject getUnusedObject() {
		foreach (GameObject prefab in this.prefabs) {
			if (!prefab.activeInHierarchy) {
				return prefab;
			}
		}

		if (this.prefabs.Count >= this.prefabMaxNum) {
			Debug.LogError("Maximumn number of " + this.prefab.name + " reached");
			return null;
		}

		createAndAddToPool();
		return this.prefabs.Last.Value;
	}

	public void resetPool() {
		foreach (GameObject prefab in this.prefabs) {
			if (prefab.activeInHierarchy) {
				prefab.SetActive(false);
			}
		}
	}

	#endregion
}
