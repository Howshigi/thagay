using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

{

    public void ResumeGame()

    {

        if (PlayerPrefs.HasKey("x"))

        {

            SceneManager.LoadScene("TestScene"); // หรือ GameScene

        }

        else

        {

            Debug.Log("No Save Data");

        }

    }

    public void NewGame()

    {

        PlayerPrefs.DeleteAll(); // ล้าง checkpoint

        SceneManager.LoadScene("TestScene"); // หรือ GameScene

    }

    public void LoadGame()

    {

        Debug.Log("Load Game");

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