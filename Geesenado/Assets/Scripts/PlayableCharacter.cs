using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayableCharacter : Character
{
    public IHoldable[] inventory;
    public float maxHealth = 4.0f;
    public float currentHealth;
    public Slider healthbar;
    private bool inStorm = false;

    new void Start()
    {

        inventory = new IHoldable[6];
        base.Start();
        PlayerPrefs.SetInt("Score", 0);
        Debug.Log("The Player's chosen char is " + PlayerPrefs.GetInt("CharacterSelected"));

        Color myColor = new Color();
        switch (PlayerPrefs.GetInt("CharacterSelected"))
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

        healthbar.value = maxHealth;

    }

    new void Update()
    {
        movement();
        currentHealth = base.getHealth();
        healthbar.value = calcHealth();

        if (Input.GetMouseButtonDown(0))
        {
            if (inventory[0] is IWeapon)
            {
                ((IWeapon)inventory[0]).Fire();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (inventory[1] != (null))
            {
                inventory[0] = inventory[1];
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (inventory[2] != (null))
            {
                inventory[0] = inventory[2];
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (inventory[3] != (null))
            {
                inventory[0] = inventory[3];
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (inventory[4] != (null))
            {
                inventory[0] = inventory[4];
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (inventory[5] != (null))
            {
                inventory[0] = inventory[5];
            }

        }

        if (inStorm)
        {
            float stormDmg = 0.1f * Time.deltaTime * 1.0f;
            _health -= stormDmg;
        }

        if (_health <= 0f)
        {
            SceneManager.LoadScene("gameOver");
        }
    }

    new public void movement()
    {

    }
    float calcHealth()
    {

        return currentHealth / maxHealth;
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
        if (collision.gameObject.tag == "Geesenado")
        {
            _health -= 0.1f;
        }
        if(collision.gameObject.tag == "ExtraCredit")
        {
            _health += .5f;
            Destroy(collision.gameObject);
        }
    }
    public bool addItem(IHoldable item)
    {
        int counter = 0;
        bool final = false;

        for (int i = 1; i < inventory.Length; i++)
        {
            if (inventory[i] != null)
            {
                if (inventory[i].Equals(item))
                {
                    final = false;
                    break;
                }

                if (counter == inventory.Length - 1)
                {
                    ReplaceInventory(item);
                    final = true;
                }
                else
                {
                    counter++;
                }
            }
            else
            {
                inventory[i] = item;
                final = true; ;
                break;
            }
        }

        return final;

    }
    void ReplaceInventory(IHoldable item)
    {
        IHoldable repalce = inventory[0];
        for (int i = 1; i < inventory.Length; i++)
        {
            if (inventory[i].Equals(repalce))
            {
                inventory[i] = item;
                inventory[0] = item;
            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Geesenado")
        {
            Debug.Log("YOU ARE IN THE STORM! RUN!!");
            float stormDmg = 0.1f * Time.deltaTime * 1.0f;
            _health -= stormDmg;
            inStorm = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Geesenado")
        {
            Debug.Log("YOU Left the storm");
            inStorm = false;
        }
    }
}
