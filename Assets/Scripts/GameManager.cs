using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player player;
    public Action GameInit;
    public ObjectPool ObjectPool {  get; private set; }

    public GameObject gameOverUI;

    private void Awake()
    {
        Instance = this;
        ObjectPool = GetComponentInChildren<ObjectPool>();

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();

        GameInit?.Invoke();
    }

    public void GameOver()
    {
        //Time.timeScale = 
        gameOverUI.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
        gameOverUI.SetActive(false);
    }
}
