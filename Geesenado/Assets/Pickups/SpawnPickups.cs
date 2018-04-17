using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickups : MonoBehaviour {

    public List<Transform> myWeapons;
    public float maxPositionX = 250;
    public float minPositionX = -300;
    public float maxPositionY = 16;
    public float minPositionY = -30;

    void Start () {
        
        SpawnWeapons();
	}


    //Either transforms already spawned weapons, or instantiates weapons in a random range, currently, it is set instantiate weapons in random positions
    void SpawnWeapons()
    {

        for (int i=0; i<myWeapons.Count; i++)
        {
            Vector3 newPos = new Vector3(Random.Range(maxPositionX, minPositionX), Random.Range(maxPositionY, minPositionY), 0);
           // myWeapons[i].position = newPos; // Use this if you want to have your objects already placed out on the map.
            Instantiate(myWeapons[i], newPos, Quaternion.identity);

        }
    }
}
