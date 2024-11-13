using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player player;
    public ObjectPool ObjectPool {  get; private set; }
    private void Awake()
    {
        Instance = this;
        ObjectPool = GetComponentInChildren<ObjectPool>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
