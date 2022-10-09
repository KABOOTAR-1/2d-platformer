using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject panel;
    bool pan=false;
  
    void Start()
    {
        panel.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pan = !pan;
            panel.SetActive(pan);
        }

        if (panel.activeSelf == true)
        {
            Time.timeScale = 0;
        }
        else
            Time.timeScale = 1;
    }

    public void Resume()
    {
        panel.SetActive(false);
        pan = false;
    }

    public void Restart()
    {
       Scene sc=SceneManager.GetActiveScene();
        SceneManager.LoadScene(sc.name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
