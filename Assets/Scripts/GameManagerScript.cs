using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;
    [SerializeField] private GameObject restartButton;

    private void Start()
    {
        restartButton.SetActive(false);
        instance = this;
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        restartButton.SetActive(true);
        Time.timeScale = 0;
    }
    public void Restart()
    {
        restartButton.SetActive(false);
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
