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

    public Vector3 targetPosition;

    Transform myTransform;

    public GameObject mesh;

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
        //moveDirectionChange += SetDestination;

        mesh = transform.GetChild(0).gameObject;

        moveSpeed = Random.Range(moveSpeedMin, moveSpeedMax);
    }


    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(myTransform.position.x - targetPosition.x) > 0.1f)
        {
            /*myTransform.position += (targetPosition - myTransform.position).normalized
                * Time.deltaTime * moveSpeed;*/

            myTransform.position += (new Vector3(1.0f, 0, 0) * Time.deltaTime * moveSpeed);
        }
        else
        {
            //gameObject.SetActive(false);
        }
    }

    public void SetDestination(Vector3 destination, bool right)
    {
        targetPosition = destination;
        isGoindRight = right;

        if (isGoindRight)
        {
            //targetPosition.x += moveDistance;
            mesh.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        else
        {
            //targetPosition.x -= moveDistance;
            moveSpeed *= -1;
            mesh.transform.eulerAngles = new Vector3(0, -90, 0);
        }

        Invoke("Deactivate", 5f);
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }


}
