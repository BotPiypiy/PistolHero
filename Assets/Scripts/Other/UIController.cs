using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField]
    GameObject pauseFrame;
    [SerializeField]
    GameObject pauseButton;

    public void OnPauseButtonClick()
    {
        pauseButton.SetActive(false);
        pauseFrame.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnResumeButtonClick()
    {
        pauseButton.SetActive(true);
        pauseFrame.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}
