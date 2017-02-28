using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidBehaviour : MonoBehaviour 
{
    private Rigidbody2D body;

    void Start () 
	{
        body = GetComponent<Rigidbody2D>();
        body.AddTorque(15,ForceMode2D.Force);
	}
	
	void Update () 
	{
		
	}
}
