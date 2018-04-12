using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class PlayableCharacter : Character {
    public Pencil pencil;
    public Paper paper;
    private WeaponController weaponController;
    
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

        //Getting the weaponController for weaponPickup
        weaponController = GameObject.Find("WeaponController").GetComponent<WeaponController>();

    }

    new void Update()
    {
        movement();
    }

    new public void movement()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "NPCWeaponTag")
        {
            float dmg = collision.gameObject.GetComponent<IDealsDamage>().DealDamage;
            _health -= dmg;
            Debug.Log("Player Health: " + _health);
            if (_health <= 0f)
            {
                SceneManager.LoadScene("gameOver");
            }
        }
    }

    /**
        * <summary> If player collides with object that is of type pickUp, if it is 
        * not in our list of holdables then we pick it up and add it to the list weapons </summary>
        * 
        */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        //We check to see if the object has the tag pickup, and if it is not in the list of player weapons already then we add it to the list.
        if (other.CompareTag("Pickup"))
        {
            bool pickedUp = weaponController.GetComponent<WeaponController>().Pickup(other.GetComponent<WeaponPickupDecider>().Choice);
            Debug.Log(pickedUp);
            other.SetActive(!pickedUp);

        }

    }
}
