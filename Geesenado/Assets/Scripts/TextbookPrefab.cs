using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextbookPrefab : MonoBehaviour, IDealsDamage {

    public float rotateSpeed;
    public AudioClip throwSound;
    public AudioClip hitSound;

    public float DealDamage { get; set; }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        // Now hopefully adds spin
        transform.Rotate(0,0,rotateSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<AudioSource>().clip = hitSound;
        GetComponent<AudioSource>().Play();
    }

    public void PlayThrowSound()
    {
        GetComponent<AudioSource>().clip = throwSound;
        GetComponent<AudioSource>().Play();
    }
}
