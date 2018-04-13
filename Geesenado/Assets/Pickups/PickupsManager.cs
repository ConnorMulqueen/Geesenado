using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsManager : MonoBehaviour
{

    public int spawnCount = 50;
    public GameObject pickupObjectPrefab;

    // Use this for initialization
    void Start()
    {
        Random rand = new Random();
        for (int i = 0; i < spawnCount; i++)
        {
            var pickup = (GameObject)Instantiate(
                pickupObjectPrefab,
                new Vector3(Random.Range(0, 260), Random.Range(0, 100)),
                transform.rotation
            );
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}