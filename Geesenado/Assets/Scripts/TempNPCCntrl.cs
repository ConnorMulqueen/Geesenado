using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempNPCCntrl : MonoBehaviour {

    public GameObject npcObject;
    public GameObject playerObject;

    // Timing
    float countdown;


	// Use this for initialization
	void Start () {
        countdown = 10f;
	}
	
	// Update is called once per frame
	void Update () {
        if(countdown <= 0)
        {
            // Fire a weapon
            npcObject.GetComponentInChildren<NPCPencil>().Fire(0.1f, Helpers.Constants.DamageType.Static, playerObject.transform.position);
            countdown = Random.Range(3f, 10f);
        }
        else
        {
            countdown -= Time.deltaTime;
        }
        


	}
}
