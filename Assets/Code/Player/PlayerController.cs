using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    private Movement movement;
    private Combat combat;
	
	void Start ()
    {
        movement = GetComponent<Movement>();
        combat = GetComponent<Combat>();
	}
	
	void Update ()
    {
        Vector3 mousePosMove = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePosMove.x = mousePosMove.x - objectPos.x;
        mousePosMove.y = mousePosMove.y - objectPos.y;

        movement.TargetDirection = mousePosMove;

        movement.ForwardThrustToggle = Input.GetKey(KeyCode.W);
        movement.BackThrustToggle = Input.GetKey(KeyCode.S);
        movement.RightThrustToggle = Input.GetKey(KeyCode.D);
        movement.LeftThrustToggle = Input.GetKey(KeyCode.A);

        combat.ToggleMainWeapon = Input.GetMouseButton(0);
        
    }
}
