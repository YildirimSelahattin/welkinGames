using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private Scene _scene;
    [SerializeField] private int SceneIndex;

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            SceneManager.LoadScene(_scene.buildIndex+1);
        }
    }

    public void StartLevel()
    {
        Score.totalScore = 0;
        LivesController.health = 100;
        SceneManager.LoadScene("Level_1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start");
    }
}
