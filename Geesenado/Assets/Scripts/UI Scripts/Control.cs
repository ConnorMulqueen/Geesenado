using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("CharacterSelect");
    }
    public void Quitter()
    {
        Application.Quit();
    }
    public void Options()
    {
        SceneManager.LoadScene("comingSoon");
    }
}
