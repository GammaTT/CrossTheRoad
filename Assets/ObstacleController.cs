using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private float moveSpeedMin;
    [SerializeField] private float moveSpeedMax;
    [SerializeField] private float moveSpeed;

    [SerializeField] private float moveDistance = 15f;
    [SerializeField] bool isGoindRight = false;

    Action moveDirectionChange;

    Vector3 targetPosition;

    Transform myTransform;

    [Header("Debug")]
    public GameObject des;

    public bool IsGoindRight
    {
        set
        {
            isGoindRight = value;
            moveDirectionChange?.Invoke();
        }
        get
        {
            return isGoindRight;
        }
    }

    private void Awake()
    {
        myTransform = transform;
        moveDirectionChange += SetDestination;

        moveSpeed = Random.Range(moveSpeedMin, moveSpeedMax);
    }

    // Start is called before the first frame update
    void Start()
    {
        IsGoindRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector3.Distance(myTransform.position, targetPosition) > 0.1f))
        {
            myTransform.position += (targetPosition - myTransform.position).normalized
                * Time.deltaTime * moveSpeed;
        }
        else
        {
            IsGoindRight = !IsGoindRight;
        }
    }

    //테스트를 위함
    private void OnValidate()
    {
        moveDirectionChange?.Invoke();
    }

    public void SetDestination()
    {
        targetPosition = transform.position;


        if (isGoindRight)
        {
            targetPosition.x += moveDistance;
        }
        else
        {
            targetPosition.x -= moveDistance;
        }

        des.transform.position = targetPosition;
    }


}
