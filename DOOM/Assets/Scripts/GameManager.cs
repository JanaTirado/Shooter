using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int vidas = 3;

    public Image corazon1;
    public Image corazon2;
    public Image corazon3;

    public GameObject pantallaMuerte;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pantallaMuerte.SetActive(false);
    }

    public void PerderVida()
    {
        vidas--;

        if (vidas == 2)
        {
            corazon3.enabled = false;
        }

        if (vidas == 1)
        {
            corazon2.enabled = false;
        }

        if (vidas <= 0)
        {
            corazon1.enabled = false;
            GameOver();
        }
    }

    void GameOver()
    {
        pantallaMuerte.SetActive(true);
        Time.timeScale = 0f; // pausa el juego
    }
}