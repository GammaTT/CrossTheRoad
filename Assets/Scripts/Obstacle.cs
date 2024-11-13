using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public ObstacleController obstacleController;

    private void Awake()
    {
        obstacleController = GetComponent<ObstacleController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            GameManager.Instance.GameOver();
            gameObject.SetActive(false);
        }
    }
}
