using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player player;
    public ObjectPool ObjectPool {  get; private set; }

    public GameObject gameOverUI;

    Score score;

    public float gameTime;

    private void Awake()
    {
        Instance = this;
        score = GetComponent<Score>();
        ObjectPool = GetComponentInChildren<ObjectPool>();

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();

        score.player = player;

        player.controller.MoveAction += score.AddAndSetScore;

        gameTime = 0f;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;
    }

    public void GameOver()
    {
        //Time.timeScale = 
        gameOverUI.SetActive(true);
    }

    public void Retry()
    {
        gameTime = 0f;
        SceneManager.LoadScene("SampleScene");
        gameOverUI.SetActive(false);
    }
}
