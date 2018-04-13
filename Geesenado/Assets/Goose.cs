using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goose : MonoBehaviour {
    public GameObject geesenado;
    public GameObject playerObj;

	// Use this for initialization
	void Start () {
        GetComponent<DistanceJoint2D>().connectedAnchor = geesenado.GetComponent<CircleCollider2D>().offset;
        GetComponent<DistanceJoint2D>().distance = geesenado.GetComponent<CircleCollider2D>().radius;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        GetComponent<DistanceJoint2D>().distance = geesenado.GetComponent<CircleCollider2D>().radius;
        GetComponent<Rigidbody2D>().position = Vector2.MoveTowards(GetComponent<Rigidbody2D>().position, playerObj.GetComponent<Rigidbody2D>().position, 3 * Time.deltaTime);
    }
}
