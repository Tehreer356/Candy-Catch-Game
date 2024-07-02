using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject livesHolder;
    public GameObject gameOverPanel;
    public int score;
    public AudioClip gameOverClip;
    AudioSource audioSource;
    public TextMeshProUGUI scoreText;
    bool gameOver = false;
    int lives=3;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncrementScore() 
    {
        if (!gameOver)
        {
            score++;
            scoreText.text = score.ToString();
        }
        
    }
    public void DecreaseLives()
    {
        if (lives > 0) 
        {
            lives--;
            livesHolder.transform.GetChild(lives).gameObject.SetActive(false);
        }
        if (lives <= 0) 
        {
            gameOver = true;
            GameOver();
        }
       
        
        
    }
    public void GameOver() 
    {
        SpawnManager.instance.StopSpawningCandies();
        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
        gameOverPanel.SetActive(true);
        print("Game Over");
        audioSource.PlayOneShot(gameOverClip,1.0f);
    }
}
