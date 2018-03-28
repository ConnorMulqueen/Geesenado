using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextbookPrefab : MonoBehaviour, IDealsDamage {

    public float rotateSpeed;

    public float DealDamage { get; set; }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        // Now hopefully adds spin
        transform.Rotate(0,0,rotateSpeed);
    }
}
