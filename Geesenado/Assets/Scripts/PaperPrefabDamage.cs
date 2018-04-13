using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**<summary>The script that handles damage for the prefab</summary> */
public class PaperPrefabDamage : MonoBehaviour, IDealsDamage
{
    public float DealDamage { get; set; }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Paper Collided");
        //this.GetComponent<CircleCollider2D>().enabled = false;
    }

}