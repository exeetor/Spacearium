using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 targetDirection = Vector2.up;
    private bool inertiaDampners = true;
    private bool forwardThrustToggle = false;
    private bool backThrustToggle = false;
    private bool leftThrustToggle = false;
    private bool rightThrustToggle = false;
    private float rotationSpeed = 250.0f;
    [SerializeField]
    private Engine frontEngine;
    [SerializeField]
    private Engine backEngine;
    [SerializeField]
    private Engine leftEngine;
    [SerializeField]
    private Engine rightEngine;
    

    private Rigidbody2D body;

    #region Properties

    public Vector2 TargetDirection
    {
        get{return targetDirection;}
        set{targetDirection = value.normalized;}
    }

    public bool InertiaDampners
    {
        get{return inertiaDampners;}
        set{inertiaDampners = value;}
    }

    public bool ForwardThrustToggle
    {
        get{return forwardThrustToggle;}
        set{forwardThrustToggle = value;}
    }

    public bool RightThrustToggle
    {
        get{return rightThrustToggle;}
        set{rightThrustToggle = value;}
    }

    public bool LeftThrustToggle
    {
        get{return leftThrustToggle;}
        set{leftThrustToggle = value;}
    }

    public bool BackThrustToggle
    {
        get
        {
            return backThrustToggle;
        }

        set
        {
            backThrustToggle = value;
        }
    }

    public Engine FrontEngine
    {
        get
        {
            return frontEngine;
        }

        set
        {
            frontEngine = value;
        }
    }

    public Engine BackEngine
    {
        get
        {
            return backEngine;
        }

        set
        {
            backEngine = value;
        }
    }

    public Engine LeftEngine
    {
        get
        {
            return leftEngine;
        }

        set
        {
            leftEngine = value;
        }
    }

    public Engine RightEngine
    {
        get
        {
            return rightEngine;
        }

        set
        {
            rightEngine = value;
        }
    }

    public float RotationSpeed
    {
        get
        {
            return rotationSpeed;
        }

        set
        {
            rotationSpeed = value;
        }
    }

    #endregion

    void Start ()
    {
		
	}

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

        body.MoveRotation(Mathf.MoveTowardsAngle(body.rotation, angle, Time.deltaTime * RotationSpeed));

        if (BackThrustToggle || ForwardThrustToggle || RightThrustToggle || LeftThrustToggle)
            body.drag = 0.0f;
        else
            body.drag = 0.5f;

        FrontEngine.Toggle = BackThrustToggle;
        BackEngine.Toggle = ForwardThrustToggle;
        RightEngine.Toggle = RightThrustToggle;
        LeftEngine.Toggle = LeftThrustToggle;
        
    }


        
}
