using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeartScript : MonoBehaviour {
    public PlayableCharacter _player;
    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;
    public Image image5;

    void Start()
    {
       
    }

    void Update () {
        Color tempColor1 = image1.color;
        Color tempColor2 = image2.color;
        Color tempColor3 = image3.color;
        Color tempColor4 = image4.color;
        Color tempColor5 = image5.color;

        if (_player.getHealth() <= 40)
        {
            tempColor1.a = 1f;
            image1.color = tempColor1;
        }
        if (_player.getHealth() <= 30)
        {
            tempColor2.a = 1f;
            image2.color = tempColor2;
        }
        if (_player.getHealth() <= 20)
        {
            tempColor3.a = 1f;
            image3.color = tempColor3;
        }
        if (_player.getHealth() <= 10)
        {
            tempColor4.a = 1f;
            image4.color = tempColor4;
        }
        if (_player.getHealth() <= 0)
        {
            tempColor5.a = 1f;
            image5.color = tempColor5;
            SceneManager.LoadScene("mainMenu");

        }
    }
    
}
