using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHealthBar : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Vector3 scale = this.transform.localScale;
        scale = new Vector3(this.GetComponentInParent<NPC>()._health, .5f, 1);
        transform.localScale = scale;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 scale = this.transform.localScale;
        scale = new Vector3(this.GetComponentInParent<NPC>()._health, .5f, 1);
        transform.localScale = scale;
    }
}
