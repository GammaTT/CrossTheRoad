using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    Player player;

    Transform playerTransform;

    [SerializeField] private float spawnCarDelay;

    Vector3[] spawnPosition = new Vector3[2];

    Vector3 SpawnPosition1;
    Vector3 SpawnPosition2;

    public float spawnDistance;
    public ObjectPool ObjectPool;

    private void Awake()
    {
        ObjectPool = GetComponent<ObjectPool>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = player.transform;

        spawnPosition[0] = playerTransform.position + new Vector3(-spawnDistance, 0, 0);
        spawnPosition[1] = playerTransform.position + new Vector3(spawnDistance, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnCar()
    {
        while (true)
        {
            GameObject obj = ObjectPool.SpawnFromPool("CarObstacle");

            int rand = Random.Range(0, spawnPosition.Length);

            obj.transform.position = spawnPosition[rand];

            //0 이면 왼쪽에서 오른쪽
            //1이면 오른쪽에서 왼쪽

            yield return new WaitForSeconds(spawnCarDelay);
        }
    }
}
