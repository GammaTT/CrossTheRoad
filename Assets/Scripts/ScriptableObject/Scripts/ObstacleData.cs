using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleData", menuName = "ObstacleData/Default/CarObstacle")]
public class ObstacleData : ScriptableObject
{
    public float minSpeed;
    public float maxSpeed;

    public GameObject originPrefab;
    public List<GameObject> carPrefabs;

    public Vector3 boxColliderSize;
    public Vector3 boxColliderCenter;
    public bool boxColliderIsTrigger;
}
