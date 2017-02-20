using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 targetDirection = Vector2.up;
    private float forwardThrust = 0.0f;
    private float backThrust = 0.0f;
    private float leftThrust = 0.0f;
    private float rightThrust = 0.0f;

    private Rigidbody2D body;

    #region Properties

    public Vector2 TargetDirection
    {
        get{return targetDirection;}
        set{targetDirection = value.normalized;}
    }

    public float ForwardThrust
    {
        get{return forwardThrust;}
        set{forwardThrust = value;}
    }

    public float BackThrust
    {
        get{return backThrust;}
        set{backThrust = value;}
    }

    public float LeftThrust
    {
        get{return leftThrust;}
        set{leftThrust = value;}
    }

    public float RightThrust
    {
        get{return rightThrust;}
        set{rightThrust = value;}
    }

    #endregion

    void Start ()
    {
		
	}

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        

    }

    
}
