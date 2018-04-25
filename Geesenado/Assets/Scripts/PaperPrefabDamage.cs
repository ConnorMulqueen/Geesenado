using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**<summary>The script that handles damage for the prefab</summary> */
public class PaperPrefabDamage : MonoBehaviour, IDealsDamage
{
    public AudioClip throwSound;
    public AudioClip hitSound;
    private bool inView = false;

    public float DealDamage { get; set; }

    private void Start()
    {
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (inView)
        {
            GetComponent<AudioSource>().clip = hitSound;
            GetComponent<AudioSource>().Play();
        }
    }

    private void OnBecameVisible()
    {
        inView = true;
    }

    private void OnBecameInvisible()
    {
        inView = false;
    }

    public void PlayThrowSound()
    {
        GetComponent<AudioSource>().clip = throwSound;
        GetComponent<AudioSource>().Play();
    }
}