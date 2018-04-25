using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsManager : MonoBehaviour
{

    public int spawnCount = 50;
    public GameObject pickupObjectPrefab;
    public GameObject extraCreditPickup;
    public Sprite pencil;
    public Sprite paper;
    public Sprite textbook;
    public Sprite notebook;
    public Sprite ruler;

    // Use this for initialization
    void Start()
    {
        Random rand = new Random();
        for (int i = 0; i < spawnCount; i++)
        {
            var pickup = (GameObject) Instantiate(
                pickupObjectPrefab,
                new Vector3(Random.Range(0, 260), Random.Range(0, 100)),
                transform.rotation
            );
            
            ChooseWeapon(pickup.GetComponent<WeaponPickupDecider>());
        }

        for (int i = 0; i < 30; i++)
        {
            var pickup = (GameObject)Instantiate(
                extraCreditPickup,
                new Vector3(Random.Range(0, 260), Random.Range(0, 100)),
                transform.rotation
            );
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChooseWeapon(WeaponPickupDecider item)
    {
        int weaponIndex = Random.Range(0, 5);
        switch (weaponIndex)
        {
            case 0:
                // Pencil
                item.Choice = "Pencil";
                item.Sprite = pencil;
                break;
            case 1:
                // Paper
                item.Choice = "Paper";
                item.Sprite = paper;
                break;
            case 2:
                // Textbook
                item.Choice = "Textbook";
                item.Sprite = textbook;
                break;
            case 3:
                // Ruler
                item.Choice = "Ruler";
                item.Sprite = ruler;
                break;
            case 4:
                // Notebook
                item.Choice = "Notebook";
                item.Sprite = notebook;
                break;
        }
    }
}