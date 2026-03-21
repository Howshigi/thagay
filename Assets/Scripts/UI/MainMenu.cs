using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

{

    public void ResumeGame()

    {

        Debug.Log("Resume Game");

    }

    public void LoadGame()

    {

        Debug.Log("Load Game");

    }

    public void NewGame()

    {

        SceneManager.LoadScene("GameScene");

    }

    public void ChapterSelection()

    {

        Debug.Log("Chapter Selection");

    }

    public void Settings()

    {

        Debug.Log("Settings");

    }

    public void Extras()

    {

        Debug.Log("Extras");

    }

    public void ExitGame()

    {

        Application.Quit();

        Debug.Log("Exit Game");

    }

}

