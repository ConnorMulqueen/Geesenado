using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("sampleScene");
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
