using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public Text _myText;
	// Use this for initialization
	void Start()
    {
        _myText.text = PlayerPrefs.GetInt("Score").ToString();
    }
	
	// Update is called once per frame
	void Update()
    {

    }
} 