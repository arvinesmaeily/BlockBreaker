using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameSession : MonoBehaviour
{

    [Range(0f,2f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool AutoPlay;

    [SerializeField] int currentScore;

    SceneLoader sl;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;

        if (gameStatusCount > 1)
        {
         
            gameObject.SetActive(false);
            Destroy(gameObject);

        }
        
        else
        {
            DontDestroyOnLoad(gameObject);

        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    public bool isAutoPlayEnabled()
    {
        return AutoPlay;
    }


    // Update is called once per frame
    private void Update()
    {
        Time.timeScale = gameSpeed;
    }
    
    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
