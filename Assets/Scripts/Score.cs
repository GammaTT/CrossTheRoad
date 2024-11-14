using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Player player;

    [SerializeField] TextMeshProUGUI scoreText;

    int score = 0;

    public void AddAndSetScore()
    {
        score += 20;
        scoreText.text = $"Score : {score}";
    }
}
