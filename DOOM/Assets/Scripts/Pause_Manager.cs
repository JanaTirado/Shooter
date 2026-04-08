using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause_manager : MonoBehaviour
{
    public GameObject panel;
    private bool isPause;

    void Start()
    {
        Time.timeScale= 1.0f;
        isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        GamePause();
    }

    public void GamePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
            panel.SetActive(isPause);
            if(isPause)
            {
                Time.timeScale = 0;
            }

            else
            {
                Time.timeScale = 1;
            }
        }
    }
}
