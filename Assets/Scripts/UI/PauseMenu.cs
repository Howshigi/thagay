using UnityEngine;

using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour

{

    public GameObject pauseMenu;

    public GameObject player;

    void Start()

    {

        pauseMenu.SetActive(false);

    }

    void Update()

    {

        if (Input.GetKeyDown(KeyCode.Escape))

        {

            pauseMenu.SetActive(true);

            Time.timeScale = 0;

        }

    }

    public void ResumeGame()

    {

        pauseMenu.SetActive(false);

        Time.timeScale = 1;

    }

    public void ReturnCheckpoint()

    {

        Debug.Log("Return Clicked");

        Time.timeScale = 1;

        if (PlayerPrefs.HasKey("x"))

        {

            float x = PlayerPrefs.GetFloat("x");

            float y = PlayerPrefs.GetFloat("y");

            float z = PlayerPrefs.GetFloat("z");

            Vector3 checkpointPos = new Vector3(x, y, z);

            // ?? รองรับทั้ง CharacterController และ Rigidbody

            CharacterController cc = player.GetComponent<CharacterController>();

            if (cc != null)

            {

                cc.enabled = false;

                player.transform.position = checkpointPos;

                cc.enabled = true;

            }

            else if (player.GetComponent<Rigidbody>() != null)

            {

                player.GetComponent<Rigidbody>().position = checkpointPos;

            }

            else

            {

                player.transform.position = checkpointPos;

            }

            Debug.Log("Teleport to: " + checkpointPos);

        }

        else

        {

            Debug.Log("No Checkpoint Saved!");

        }

        pauseMenu.SetActive(false);

    }

    public void ExitToMainMenu()

    {

        Time.timeScale = 1;

        SceneManager.LoadScene("MainMenu");

    }

    public void ExitGame()

    {

        Application.Quit();

    }

}
