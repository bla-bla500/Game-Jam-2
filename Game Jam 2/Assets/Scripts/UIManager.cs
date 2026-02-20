using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameObject controlPannel;
    void Start()
    {
        controlPannel = GameObject.Find("Controls");
        controlPannel.SetActive(false);
    }

    void Update()
    {
        
    }
    public void Exit()
    {
        Application.Quit();
    }
}
