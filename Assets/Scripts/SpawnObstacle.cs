using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class SpawnObstacle : MonoBehaviour
{
    Player player;

    Transform playerTransform;

    [SerializeField] private float spawnCarDelay;

    Vector3 spawnPosition1 => player.transform.position + new Vector3(-spawnDistance, 0, 0);
    Vector3 spawnPosition2 => player.transform.position + new Vector3(+spawnDistance, 0, 0);

    public float spawnDistance;
    public ObjectPool ObjectPool;

    private void Awake()
    {
        ObjectPool = GetComponent<ObjectPool>();
    }

    private void Initialize()
    {
        player = GameManager.Instance.player;
        playerTransform = player.transform;

        StartCoroutine(SpawnCar());
    }

    // Start is called before the first frame update
    void Start()
    {
        //GameManager.Instance.GameInit += Initialize;
        Invoke("Initialize", 1f);
    }

    IEnumerator SpawnCar()
    {
        float[] zOffsets = { -4, -2, 2, 4, 6, 8 }; // Z축 오프셋 배열


        yield return new WaitForSeconds(0.5f);

        while (true)
        {
            foreach (float zOffset in zOffsets)
            {
                GameObject obj = ObjectPool.SpawnFromPool("CarObstacle");

                bool isRight = (Random.Range(0, 2) == 0);

                if (isRight)
                {
                    obj.transform.position = spawnPosition1 + new Vector3(0, 0, zOffset);
                    obj.GetComponent<ObstacleController>().SetDestination(spawnPosition2, true);
                }
                else
                {
                    obj.transform.position = spawnPosition2 + new Vector3(0, 0, zOffset);
                    obj.GetComponent<ObstacleController>().SetDestination(spawnPosition1, false);
                }

                //리트라이시 플레이어와 가깝게 생성되는 현상
                if (Vector3.Distance(obj.transform.position, playerTransform.position) < 0.1f)
                {
                    obj.SetActive(false);
                }
            }

            yield return new WaitForSeconds(spawnCarDelay);
        }
    }
}
