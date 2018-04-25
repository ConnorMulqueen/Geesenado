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
    public void LoadMain()
    {
        SceneManager.LoadScene("mainMenu");
    }
    public void LoadHowToPlay()
    {
        SceneManager.LoadScene("howToPlay");
    }
    public void LoadWeaponSelect()
    {
        SceneManager.LoadScene("WeaponSelect");
    }
    public string GetScore()
    {
        return PlayerPrefs.GetInt("Score").ToString();
    }
}
