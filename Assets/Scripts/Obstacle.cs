using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public ObstacleController obstacleController;

    [SerializeField] private ObstacleData data;

    public GameObject Car;
    public BoxCollider boxCollider;

    private void Awake()
    {
        obstacleController = GetComponent<ObstacleController>();

        boxCollider = GetComponentInChildren<BoxCollider>();
    }

    private void Start()
    {
        GameObject carMesh = Instantiate(data.carPrefabs[Random.Range(0, data.carPrefabs.Count)], Car.transform);

        BoxCollider carMeshBox = carMesh.GetComponent<BoxCollider>();

        carMeshBox.size = data.boxColliderSize;
        carMeshBox.center = data.boxColliderCenter;
        carMeshBox.isTrigger = data.boxColliderIsTrigger;
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
