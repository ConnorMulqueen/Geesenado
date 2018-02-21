using UnityEngine;
using System.Collections;

public class PlayableCharacter : Character {

    new void Start()
    {
        base.Start();
    }

    new void Update()
    {
        movement();
    }

    new public void movement()
    {
        
    }
}
