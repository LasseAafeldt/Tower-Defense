﻿using UnityEngine;
using UnityEngine.AI;

public class ClickPlayerController : MonoBehaviour {

    public Camera cam;

    public NavMeshAgent agent;

	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
		
	}
}
