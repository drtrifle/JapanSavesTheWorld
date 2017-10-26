using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour {

    public Text missleBlockedText;
    public Image healthBarImage;

    int numMissilesBlocked = 0;

    [SerializeField]
    float totalHealth;
    [SerializeField]
    float remainingHealth;

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

    //Decreases the amount of health remaining for the UI element;
    public void DecrementHealthBar()
    {
        remainingHealth--;
        healthBarImage.fillAmount = (remainingHealth / totalHealth) * 1f;
    }
}
