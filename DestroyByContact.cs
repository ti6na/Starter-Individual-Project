using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public AudioSource musicSource;
    public AudioClip musicClipOne;
    public Text gameOverText;
    public Text restartText;
    private bool gameOver;
    private bool restart;


    private void Start()
    {
        gameOver = false;
        restart = false;
        gameOverText.text = "";
    
    }

    void Update ()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("DumplingDude");
            }
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player") ;
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(collision.collider.gameObject);
            musicSource.clip = musicClipOne;
            musicSource.Play();
            gameOver = true;
            gameOverText.text = "Game Over!";
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
        restartText.text = "Press 'R' to Restart";
        restart = true;
            }
}
