using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCleanerController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().MakeDead();
        }
        else
            Destroy(collision.gameObject);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void StopGame()
    {
        Application.Quit();
    }
}
