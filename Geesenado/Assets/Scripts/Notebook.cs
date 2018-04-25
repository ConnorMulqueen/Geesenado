using Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour, IPlayerWeapon {

    private int ammo;
    private int MAX_AMMO;
    public GameObject paperPrefab;
    public GameObject playerObject;
    private int MAX_FIREPOWER = 10;
    private bool begin = false;
    private float countdown = 0;
    private float fireCountdown = 0;
    private Vector2 pausePosition;
    public AudioClip dropSound;
    public AudioClip spraySound;

    public string Name { get { return "Notebook";  } }

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
        get { return 0.3f; }
        set { if (value > 0.3f) Damage = 0.3f; }
    }

    /**
    * <summary>Unused</summary>
    */
    public float DealDamage { get; set; }

    /** <summary>Damage starts at .1 and weapon must be charged to do full damage.</summary>
     */
    public void Fire(float damagePoints = .1f, Constants.DamageType damageType = Constants.DamageType.Static)
    {
        Debug.Log("Notebook Fired");
        DealDamage = Damage;

        if (ammo > 0 && countdown <= 0)
        {
            pausePosition = playerObject.GetComponent<Rigidbody2D>().position;
            begin = true;
            fireCountdown = 100;
            this.GetComponent<Rigidbody2D>().position = pausePosition;
            this.GetComponent<PolygonCollider2D>().enabled = true;
            this.GetComponent<SpriteRenderer>().enabled = true;
            countdown = 3;
            GetComponent<AudioSource>().clip = dropSound;
            GetComponent<AudioSource>().Play();
        }
    }

    // Use this for initialization
    void Start () {
        ammo = 5;
        MAX_AMMO = 10;
        begin = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (begin)
        {
            this.GetComponent<Rigidbody2D>().position = pausePosition;
            this.GetComponent<PolygonCollider2D>().enabled = true;
            this.GetComponent<SpriteRenderer>().enabled = true;

            if (Mathf.Floor(fireCountdown) % 2 == 0 && fireCountdown > 0)
            {
                SpawnPaper();
                fireCountdown = 100;
            }

            if (countdown <= 0)
            {
                begin = false;
            }
        }
        else
        {
            this.GetComponent<PolygonCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<Rigidbody2D>().position = playerObject.GetComponent<Rigidbody2D>().position;
        }
        fireCountdown -= 1f * Time.deltaTime;
        countdown -= 1f * Time.deltaTime;
    }


    private void SpawnPaper()
    {
        Debug.Log("Spraying Paper");
        // Create the paper prefab
        var paper1 = (GameObject)Instantiate( paperPrefab, transform.position, transform.rotation );
        var paper2 = (GameObject)Instantiate( paperPrefab, transform.position, transform.rotation );
        var paper3 = (GameObject)Instantiate( paperPrefab, transform.position, transform.rotation );
        var paper4 = (GameObject)Instantiate( paperPrefab, transform.position, transform.rotation );

        Physics2D.IgnoreCollision(paper1.GetComponent<CircleCollider2D>(), GetComponent<PolygonCollider2D>());
        Physics2D.IgnoreCollision(paper2.GetComponent<CircleCollider2D>(), GetComponent<PolygonCollider2D>());
        Physics2D.IgnoreCollision(paper3.GetComponent<CircleCollider2D>(), GetComponent<PolygonCollider2D>());
        Physics2D.IgnoreCollision(paper4.GetComponent<CircleCollider2D>(), GetComponent<PolygonCollider2D>());

        GetComponent<AudioSource>().clip = spraySound;
        GetComponent<AudioSource>().Play();

        // Compute the velocity to fire the paper prefab
        paper1.GetComponent<Rigidbody2D>().velocity = this.transform.up * MAX_FIREPOWER + new Vector3(5,5, 0) ;
        paper2.GetComponent<Rigidbody2D>().velocity = this.transform.right * MAX_FIREPOWER + new Vector3(5, -5, 0);
        paper3.GetComponent<Rigidbody2D>().velocity = -this.transform.up * MAX_FIREPOWER + new Vector3(-5, 5, 0);
        paper4.GetComponent<Rigidbody2D>().velocity = -this.transform.right * MAX_FIREPOWER + new Vector3(-5, -5, 0);

        float dealDamage = .3f;
        paper1.GetComponent<PaperPrefabDamage>().DealDamage = dealDamage;
        paper2.GetComponent<PaperPrefabDamage>().DealDamage = dealDamage;
        paper3.GetComponent<PaperPrefabDamage>().DealDamage = dealDamage;
        paper4.GetComponent<PaperPrefabDamage>().DealDamage = dealDamage;

        Destroy(paper1, .75f);
        Destroy(paper2, .75f);
        Destroy(paper3, .75f);
        Destroy(paper4, .75f);
    }

    private void OnDestroy()
    {
        SpawnPaper();
    }

}
