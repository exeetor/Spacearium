﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    private Movement movement;
	
	void Start ()
    {
        movement = GetComponent<Movement>();
	}
	
	void Update ()
    {
        Vector3 mousePosMove = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePosMove.x = mousePosMove.x - objectPos.x;
        mousePosMove.y = mousePosMove.y - objectPos.y;

        movement.TargetDirection = mousePosMove;

        
    }
}
