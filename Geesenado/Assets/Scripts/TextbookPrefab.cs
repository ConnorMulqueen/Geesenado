using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextbookPrefab : MonoBehaviour {

    public float damage;
    public float rotateSpeed;

	// Use this for initialization
	void Start () {
        damage = .1f;
	}
	
	// Update is called once per frame
	void Update () {
        // Now hopefully adds spin
        transform.Rotate(0,0,rotateSpeed);
    }
}
