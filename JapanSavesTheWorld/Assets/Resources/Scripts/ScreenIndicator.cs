﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenIndicator : MonoBehaviour {

    private Transform target;

    private Vector3 v_diff;

    private float atan2;

    void Update()

    {
        //Checks if the enemy exists so you dont get any errors

        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {

            target = GameObject.FindGameObjectWithTag("Enemy").transform;

            //Rotate towards the enemy

            v_diff = (target.position - transform.position);

            atan2 = Mathf.Atan2(v_diff.y, v_diff.x);

            transform.rotation = Quaternion.Euler(0f, 0f, atan2 * Mathf.Rad2Deg - 90);
            //Move Towards the target

            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 1000);
            //Clamp to the screen view

            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

            pos.x = Mathf.Clamp01(pos.x);

            pos.y = Mathf.Clamp01(pos.y);

            transform.position = Camera.main.ViewportToWorldPoint(pos);

        }

    }
}
