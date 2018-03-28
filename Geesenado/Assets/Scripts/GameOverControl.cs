using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverControl : MonoBehaviour {

    private NPC[] myNPCList;
    // Use this for initialization
    void Start () {
        myNPCList = (NPC[]) FindObjectsOfType(typeof(NPC));
    }
	
	// Update is called once per frame
	void Update () {
        myNPCList = (NPC[])FindObjectsOfType(typeof(NPC));
        Debug.Log("Num NPCs: " + myNPCList.Length.ToString() );
        if(myNPCList.Length <= 0)
        {
            SceneManager.LoadScene("winScreen");
        }
	}
}
