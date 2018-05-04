using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StudentEnrolledCounter : MonoBehaviour {

    public Text _myText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _myText.text = "Students enrolled: " + GameObject.FindGameObjectsWithTag("NPC").Length;
    }
}
