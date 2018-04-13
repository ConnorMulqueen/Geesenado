using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goose : MonoBehaviour {
    public GameObject geesenado;

	// Use this for initialization
	void Start () {
        GetComponent<DistanceJoint2D>().connectedAnchor = geesenado.GetComponent<CircleCollider2D>().offset;
        GetComponent<DistanceJoint2D>().distance = geesenado.GetComponent<CircleCollider2D>().radius;
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<DistanceJoint2D>().distance = geesenado.GetComponent<CircleCollider2D>().radius;
        Debug.Log("Dis: " + GetComponent<DistanceJoint2D>().distance.ToString());
    }
}
