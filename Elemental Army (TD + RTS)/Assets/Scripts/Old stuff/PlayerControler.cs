using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {
    public static PlayerControler instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than 1 PlayerControler in the scene!");
        }
        instance = this;
    }

    public float moveSpeed;
    public static Vector3 targetPos;

    private Vector3 startPos;
    private Vector3 directionVector;
    private Vector3 dist;
    private bool canMove;

    private void Start()
    {
        canMove = true;
        startPos = transform.position;
        //targetPos = startPos;
    }

    private void FixedUpdate()
    {
        float step = moveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse1))//right click
        {
            if (canMove)
            {
                SetPlayerDestination();
            }
            else
            {
                Debug.Log("Player can't move!!!");
            }
        }
        //calculate distance to target
        dist = targetPos - transform.position;
        // move character
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        if (dist.magnitude < .1f)
        {
            transform.position = targetPos;
        }
    }

    public float GetDistanceToTarget()
    {
        return dist.magnitude;
    }

    public void SetPlayerDestination()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            targetPos = hit.point;
            Debug.Log("Temp calling of lives left updated here!!!");
            //UIUpdater.instance.UpdateLives();
        }
        directionVector = targetPos - transform.position;
        directionVector.y = 0;
        if (directionVector.magnitude > 1)
            directionVector = directionVector.normalized;
    }
}
