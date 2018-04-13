using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempPlayerPickupHandler : MonoBehaviour
{

    public GameObject player;
    public GameObject pencilObj;
    public GameObject paperObj;
    public GameObject textObj;
    public GameObject rulerObj;
    public GameObject notebookObj;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Pickup")
        {
            string pickupType = collision.gameObject.GetComponent<WeaponPickupDecider>().Choice;
            Debug.Log("Player Hit a Pickup: " + pickupType);

            if (pickupType == "Pencil")
            {
                Debug.Log("Player touched pencil pickup");

                var pencil = (GameObject)Instantiate(
                 pencilObj,
                 player.transform.position,
                 player.transform.rotation
                );

                // Setup the player the pencil should  reference
                pencil.GetComponent<Pencil>().playerBody = player.GetComponent<Rigidbody2D>();

                var result = player.GetComponent<PlayableCharacter>().addItem(pencil.GetComponent<Pencil>());

                if (result)
                {
                    Destroy(collision.gameObject);
                }

            }
            if (pickupType == "Paper")
            {
                Debug.Log("Player touched Paper pickup");

                var paper = (GameObject)Instantiate(
                 paperObj,
                 player.transform.position,
                 player.transform.rotation
                );

                paper.GetComponent<Paper>().playerObject = player;

                var result = player.GetComponent<PlayableCharacter>().addItem(paper.GetComponent<Paper>());

                if (result)
                {
                    Destroy(collision.gameObject);
                }
            }
            if (pickupType == "Textbook")
            {
                Debug.Log("Player touched Textbook pickup");
                var text = (GameObject)Instantiate(
                 textObj,
                 player.transform.position,
                 player.transform.rotation
                );

                text.GetComponent<Textbook>().playerObject = player;

                var result = player.GetComponent<PlayableCharacter>().addItem(text.GetComponent<Textbook>());

                if (result)
                {
                    Destroy(collision.gameObject);
                }
            }
            if (pickupType == "Ruler")
            {
                Debug.Log("Player touched ruler pickup");
                var ruler = (GameObject)Instantiate(
                 rulerObj,
                player.transform.position,
                 player.transform.rotation
                );

                ruler.GetComponent<Ruler>().playerBody = player.GetComponent<Rigidbody2D>();

                var result = player.GetComponent<PlayableCharacter>().addItem(ruler.GetComponent<Ruler>());

                if (result)
                {
                    Destroy(collision.gameObject);
                }
            }
            if (pickupType == "Notebook")
            {
                Debug.Log("Player touched pencil pickup");
                var notebook = (GameObject)Instantiate(
                 notebookObj,
                 player.transform.position,
                 player.transform.rotation
                );

                notebook.GetComponent<Notebook>().playerObject = player;

                var result = player.GetComponent<PlayableCharacter>().addItem(notebook.GetComponent<Notebook>());

                if (result)
                {
                    Destroy(collision.gameObject);
                }
            }

            Destroy(collision.gameObject);
        }

    }
}