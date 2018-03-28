using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempNPCCntrl : MonoBehaviour {

    public GameObject npcObject;
    public GameObject playerObject;

    // Timing
    float pencilCountdown;
    float paperCountdown;


	// Use this for initialization
	void Start () {
        pencilCountdown = 2f;
        paperCountdown = 4f;
	}
	
	// Update is called once per frame
	void Update () {
        if (npcObject != null)
        {
            if (pencilCountdown <= 0)
            {
                // Fire pencil weapon
                // npcObject.GetComponentInChildren<NPCPencil>().Fire(0.1f, Helpers.Constants.DamageType.Static, playerObject.transform.position);
                pencilCountdown = Random.Range(3f, 10f);
            }
            else if (paperCountdown <= 0)
            {
                npcObject.GetComponentInChildren<NPCPaper>().Fire(0.2f, Helpers.Constants.DamageType.Static);
                paperCountdown = Random.Range(1f, 4f);
            }
            else
            {
                pencilCountdown -= Time.deltaTime;
                paperCountdown -= Time.deltaTime;
            }
        }
	}
}
