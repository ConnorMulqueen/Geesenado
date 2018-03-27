using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    private GameObject PauseCanvas; 
    private bool isShowing;
 
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            isShowing = !isShowing;
            PauseCanvas.SetActive(isShowing);
        }
    }
}
