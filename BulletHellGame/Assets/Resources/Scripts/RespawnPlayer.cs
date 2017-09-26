using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour {

    void OnTriggerExit2D(Collider2D other)
    {
        //If player somehow manages to leave the boundary
        //Spawn at center
        if (other.CompareTag("Player"))
        {
            other.transform.position = Vector3.zero;
        }
    }

}
