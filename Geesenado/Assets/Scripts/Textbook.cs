using Helpers;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/** <summary>An object that handles and spawns the player textbook prefab.</summary>*/
public class Textbook : MonoBehaviour, IPlayerWeapon {

    public GameObject playerObject;
    public Rigidbody2D textbookBody;
    public GameObject textbookPrefab;

    // Local
    private readonly int MAX_AMMO = 10;
    private readonly float MAX_DAMMAGE = 0.5f;
    private readonly float MAX_CHARGE = 100f;
    private readonly float MAX_FIREPOWER = 15f;
    private float chargeRate = 15f;
    private float chargePercent;
    private bool beginCharge;
    private int ammo;

    public string Name { get { return "Textbook"; } }

    public int Ammo
    {
        get { return ammo; }

        set
        {
            if (value > this.MAX_AMMO) ammo = MAX_AMMO;
            else ammo = value;
        }
    }

    public int MaxAmmo
    {
        get { return this.MAX_AMMO; }
        set { if (value > MAX_AMMO) MaxAmmo = 5; }
    }

    public float Damage
    {
        get { return 0.5f * chargePercent; }
        set { if (value > 0.5f) Damage = 0.5f; }
    }

    /**
    * <summary>Unused</summary>
    */
    public float DealDamage { get; set; }

    /** <summary>Damage starts at .1 and weapon must be charged to do full damage.</summary>
     */
    public void Fire(float damagePoints = .1f, Constants.DamageType damageType = Constants.DamageType.Static)
    {
        if (Ammo > 0)
        {
            if (beginCharge == false)
            {
                Debug.Log("Textbook charging");
                beginCharge = true;
                chargePercent = 1f;
            }
            else
            {
                beginCharge = false;
                Debug.Log("Textbook firing with charge: " + chargePercent.ToString());

                var textbook = (GameObject)Instantiate(
                    textbookPrefab,
                    transform.position,
                    playerObject.transform.rotation
                );

                // This is how we set the damage of the prefabs
                textbook.GetComponent<TextbookPrefab>().DealDamage = this.Damage;
                textbook.GetComponent<TextbookPrefab>().rotateSpeed = chargePercent / 10;
                textbook.GetComponent<Rigidbody2D>().velocity = 
                    playerObject.GetComponent<Rigidbody2D>().transform.up * (MAX_FIREPOWER * (chargePercent / 100)) + 
                    new Vector3(playerObject.GetComponent<Rigidbody2D>().velocity.x,playerObject.GetComponent<Rigidbody2D>().velocity.y);

                textbook.GetComponent<TextbookPrefab>().DealDamage = Damage;

                Destroy(textbook, .75f);
                this.Ammo--;
            }
        }
    }

    // Use this for initialization
    void Start () {
        Ammo = 10;
	}
	
	// Update is called once per frame
	void Update () {
        if (beginCharge)
        {
            chargePercent += chargeRate * Time.deltaTime;
            GetComponent<Transform>().localScale = new Vector3(2, 2, 1);
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<SpriteRenderer>().color = Color.Lerp(Color.red, Color.green, ((MAX_CHARGE - chargePercent) / MAX_CHARGE));
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }

        transform.position = playerObject.GetComponent<Rigidbody2D>().position;
    }
}
