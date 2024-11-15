using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    public void SetGameManagerToPlayer()
    {
        GameManager.Instance.player = this;
    }
}
