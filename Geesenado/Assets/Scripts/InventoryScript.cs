using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour {
    public GameObject[] panels;
    public GameObject playerObject;
    public Sprite pencil;
    public Sprite paper;
    public Sprite text;
    public Sprite ruler;
    public Sprite note;
    public Sprite blankSprite;
    int currentEquippedIndex;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currentEquippedIndex = playerObject.GetComponent<PlayableCharacter>().curEquippedIndex;
        for (int i = 1; i < 6; i++)
        {
            if (playerObject.GetComponent<PlayableCharacter>().inventory[i] != null)
            {
                Sprite currentSprite = null;
                if (playerObject.GetComponent<PlayableCharacter>().inventory[i] is IWeapon)
                {
                    if (((IPlayerWeapon)playerObject.GetComponent<PlayableCharacter>().inventory[i]).Name == "Pencil")
                    {
                        currentSprite = pencil;
                    }
                    if (((IPlayerWeapon)playerObject.GetComponent<PlayableCharacter>().inventory[i]).Name == "Paper")
                    {
                        currentSprite = paper;
                    }
                    if (((IPlayerWeapon)playerObject.GetComponent<PlayableCharacter>().inventory[i]).Name == "Textbook")
                    {
                        currentSprite = text;
                    }
                    if (((IPlayerWeapon)playerObject.GetComponent<PlayableCharacter>().inventory[i]).Name == "Notebook")
                    {
                        currentSprite = note;
                    }
                    if (((IPlayerWeapon)playerObject.GetComponent<PlayableCharacter>().inventory[i]).Name == "Ruler")
                    {
                        currentSprite = ruler;
                    }
                }

                panels[i-1].GetComponent<Image>().sprite = currentSprite;
                panels[i - 1].GetComponent<Image>().type = Image.Type.Simple;
                panels[i - 1].GetComponent<Image>().preserveAspect = true;
            }
            else
            {
                // No item was found in this slot
                panels[i - 1].GetComponent<Image>().color = Color.white;
                panels[i - 1].GetComponent<Image>().sprite = blankSprite;
                panels[i - 1].GetComponent<Image>().type = Image.Type.Sliced;
                panels[i - 1].GetComponent<Image>().preserveAspect = false;
                if (currentEquippedIndex == i) { currentEquippedIndex = 0; }
            }
        }
        ClearHighlights();
        HighlightIndex(currentEquippedIndex);
	}

    void HighlightIndex(int index)
    {
        if (index > 0)
        {
            panels[index - 1].GetComponent<Image>().color = Color.yellow;
        }
    }

    void ClearHighlights()
    {
        foreach (GameObject panel in panels)
        {
            panel.GetComponent<Image>().color = Color.white;
        }
    }
}
