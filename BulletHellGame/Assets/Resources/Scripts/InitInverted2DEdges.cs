using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitInverted2DEdges : MonoBehaviour {

    public int numEdges;
    public float radius;

	// Use this for initialization
	void Start () {
        EdgeCollider2D edgeCollider = GetComponent<EdgeCollider2D>();
        Vector2[] points = new Vector2[numEdges+1];

        for (int i = 0; i <= numEdges; i++)
        {
            float angle = 2 * Mathf.PI * i / numEdges;
            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);

            points[i] = new Vector2(x, y);
        }

        edgeCollider.points = points;
    }
	
}
