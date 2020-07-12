using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject[] screens;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back()
    {
        foreach(GameObject obj in screens)
        {
            obj.SetActive(false);
        }
    }

    public void Controls()
    {
        screens[0].SetActive(true);
    }

    public void Play()
    {
        screens[2].SetActive(true);
    }

    public void Credits()
    {

        screens[1].SetActive(true);
    }

    public void Begin()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
