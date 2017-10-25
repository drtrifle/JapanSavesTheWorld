using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour {

    public Text missleBlockedText;

    int numMissilesBlocked = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Increases the missle blocked count for the UI element 
    public void IncrementMissleBlockedText() {
        numMissilesBlocked++;
        missleBlockedText.text = "Missiles Blocked: " + numMissilesBlocked;
    }
}
