using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour {
    //Reference: https://www.youtube.com/watch?v=IFTjcPvCZaM
    private GameObject[] characterList;
    private int index;
    private string[] professorNames;
    private void Start()
    {
        professorNames = new string[7]{"Jesse Hartloff", "Carl Alphonce", "Bina Ramamurthy", "Atri Rudra", "Satish", "Victor E. Bull", "Ziarek"};
        characterList = new GameObject[transform.childCount];

        for(int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }
        foreach (GameObject go in characterList)
        {
            go.SetActive(false);
        }

        characterList[0].SetActive(true);
    }
    public void Toggle(bool left)
    {
        characterList[index].SetActive(false);

        if (left)
        {
            index--;
        } else
        {
            index++;
        }

        if (index < 0)
        {
            index = characterList.Length - 1;
        } else if (index > characterList.Length-1)
        {
            index = 0;
        }
        GameObject.Find("ProfessorName").GetComponentInChildren<Text>().text = professorNames[index];
        characterList[index].SetActive(true);
    }
    public void ConfirmButton()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene("sampleScene");
    }

}
