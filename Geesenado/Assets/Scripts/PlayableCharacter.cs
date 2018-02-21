using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class PlayableCharacter : Character {
    public Pencil pencil;
    public Paper paper;
    new void Start()
    {
        base.Start();
    }

    new void Update()
    {
        movement();

        // Setting Mouse Left Click for Pencil attack
        if (Input.GetButtonDown("Fire1") || Input.GetMouseButton(0))
        {
            pencil.Fire();
        }

        // Setting Space Bar for Paper attack
        if (Input.GetKeyDown(KeyCode.Space))
        {
            paper.Fire();
        }

    }

    new public void movement()
    {
        
    }
}
