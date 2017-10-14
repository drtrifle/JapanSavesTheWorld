using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour {

    public float cursorSpeed = 0.1f;

    // Use this for initialization
    void Start() {
        Cursor.visible = false;
    }

    void FixedUpdate() {
        FollowMousePosition();
    }

    //Move towards mouse position
    void FollowMousePosition() {
        Vector3 rawPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3(rawPosition.x, rawPosition.y, 0.0f);
        targetPosition = Vector3.Lerp(transform.position, targetPosition, cursorSpeed);
        gameObject.GetComponent<Rigidbody2D>().MovePosition(targetPosition);
    }

}
