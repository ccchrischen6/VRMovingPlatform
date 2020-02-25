using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControaler : MonoBehaviour
{
    //the position of target
    public Transform target;
    private float speed = 20;
    //create a varible determing whether the camera moves
    private bool isMoving = false;
    public Transform[] targets;
    /** the variable to move through the targets array */
    private int nextIndex = 0;


    void HandleMovment()
    {
        if (!isMoving) return;

        // calculate the distance from target
        float distance = Vector3.Distance(transform.position, targets[nextIndex].position);

        if(distance > 0)
        {
            //define the step moves per deltaTime
            float step = speed * Time.deltaTime;
            //move the current position to target position by step
            transform.position = Vector3.MoveTowards(transform.position, targets[nextIndex].position, step);
        }

        // if we have arrive the target, we will update the current target to next target
        else
        {
            nextIndex++;
            if (nextIndex == targets.Length) nextIndex = 0;
            
        }
    }

    void HandleInput()
    {
        //check for fire axis
        if (Input.GetButtonDown("Fire1"))
        {
            isMoving = !isMoving;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check for player input

        HandleInput();

        //call function to handle movement
        HandleMovment();
    }
}
