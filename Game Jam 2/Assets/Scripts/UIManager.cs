using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private GameObject controlPannel;
    private GameObject win;
    private GameObject lose;
    private GameObject Button1;
    private GameObject Button2;
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            controlPannel = GameObject.Find("Controls");
            controlPannel.SetActive(false);
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            win = GameObject.Find("Win");
            lose = GameObject.Find("Lose");
            Button1 = GameObject.Find("Button");
            Button2 = GameObject.Find("Button (1)");
            Button1.SetActive(false);
            Button2.SetActive(false);
            win.SetActive(false);
            lose.SetActive(false);
        }
    }

    public void LoadGame(int scene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }

    public void ActivateControlPannel()
    {
        controlPannel.SetActive(true);
    }

    public void DeActivateControlPannel()
    {
        controlPannel.SetActive(false);
    }

    public void Win()
    {
        win.SetActive(true);
        Button1.SetActive(true);
        Button2.SetActive(true);
    }

    public void Lose()
    {
        lose.SetActive(true);
        Button1.SetActive(true);
        Button2.SetActive(true);
    }



    public void Exit()
    {
        Application.Quit();
    }
}
