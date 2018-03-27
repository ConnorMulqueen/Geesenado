using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class PlayableCharacter : Character {
    public Pencil pencil;
    public Paper paper;

    
    new void Start()
    {
        base.Start();
        Debug.Log("The Player's chosen char is " + PlayerPrefs.GetInt("CharacterSelected"));

        Color myColor = new Color();
        switch(PlayerPrefs.GetInt("CharacterSelected"))
        {
            case 0:
                ColorUtility.TryParseHtmlString("#58369F", out myColor);
                break;
            case 1:
                ColorUtility.TryParseHtmlString("#32A72D", out myColor);
                break;
            case 2:
                ColorUtility.TryParseHtmlString("#9E3636", out myColor);      
                break;
        }
        GetComponent<Renderer>().material.SetColor("_EmissionColor", myColor);


    }

    new void Update()
    {
        movement();
    }

    new public void movement()
    {
        
    }
}
