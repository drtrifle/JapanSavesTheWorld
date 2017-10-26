using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public World worldScript;

    public UIManager uiManager;

    #region Singleton Setup

    static GameManager _instance;
    public static GameManager managerInstance {
        get {
            if (_instance == null) {
                GameObject manager = new GameObject("[GameManager]");
                _instance = manager.AddComponent<GameManager>();
                DontDestroyOnLoad(manager);
            }
            return _instance;
        }
    }

    void Awake() {
        if (_instance == null) {
            //If I am the first instance, make me the Singleton
            _instance = this;
            DontDestroyOnLoad(this);
        } else {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

    #endregion

    public void PlayerSuccessfullyBlockedMissile() {
        worldScript.ScaleWorld();
        uiManager.IncrementMissleBlockedText();
    }

    public void PlayerFailedToBlockMissile()
    {
        uiManager.DecrementHealthBar();
    }
}
