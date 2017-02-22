using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 targetDirection = Vector2.up;
    private bool inertiaDampners = true;
    private float forwardThrust = 0.0f;
    private bool forwardThrustToggle = false;
    private float backThrust = 0.0f;
    private bool backThrustToggle = false;
    private float leftThrust = 0.0f;
    private bool leftThrustToggle = false;
    private float rightThrust = 0.0f;
    private bool rightThrustToggle = false;
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

    #endregion

    void Start ()
    {
		
	}

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.mass = body.mass + backEngine.Mass + frontEngine.Mass + leftEngine.Mass + rightEngine.Mass;
    }

    void FixedUpdate()
    {
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        body.rotation = angle;

        //calculate force
        //calculateThrust();
        FrontEngine.Toggle = BackThrustToggle;
        BackEngine.Toggle = ForwardThrustToggle;
        RightEngine.Toggle = RightThrustToggle;
        LeftEngine.Toggle = LeftThrustToggle;
        //calcForce(angle);
        
    }



    //void calculateThrust()
    //{
    //    if (ForwardThrustToggle)
    //    {
    //        if(ForwardThrust < 5)
    //            ForwardThrust = ForwardThrust + ForwardEngine/body.mass;
    //    }
    //    else if (ForwardThrust > 0)
    //    {
    //        ForwardThrust = ForwardThrust - 1f;
    //        if (forwardThrust < 0)
    //            ForwardThrust = 0;
    //    }

    //    if (BackThrustToggle)
    //    {
    //        if (BackThrust < 2)
    //        {
    //            BackThrust = BackThrust + 1.0f/body.mass;
    //        }
    //    }
    //    else if (BackThrust > 0)
    //    {
    //        BackThrust = BackThrust - 0.5f;
    //        if (BackThrust < 0)
    //            BackThrust = 0;
    //    }
    //    if (RightThrustToggle)
    //    {
    //        if (RightThrust < 1)
    //        {
    //            RightThrust = RightThrust + 0.5f;
    //        }
    //    }
    //    else if (RightThrust > 0)
    //    {
    //        RightThrust = RightThrust - 0.25f;
    //        if (RightThrust < 0)
    //            RightThrust = 0;
    //    }
    //    if (LeftThrustToggle)
    //    {
    //        if (LeftThrust < 1)
    //        {
    //            LeftThrust = LeftThrust + 0.5f;
    //        }
    //    }
    //    else if (LeftThrust > 0)
    //    {
    //        LeftThrust = LeftThrust - 0.25f;
    //        if (LeftThrust < 0)
    //            LeftThrust = 0;
    //    }
    //}

    void calcForce(float angle)
    {
        Vector2 forceVector = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));
        Vector2 forceBack = new Vector2(-forceVector.x, -forceVector.y);
        Vector2 forceRight = new Vector2(Mathf.Cos(Mathf.Deg2Rad * (angle - 90)), Mathf.Sin(Mathf.Deg2Rad * (angle - 90)));
        //Vector2 forceRight = new Vector2(forceVector.y, forceVector.x);
        Vector2 forceLeft = new Vector2(-forceRight.x, -forceRight.y);

        body.AddForce(forceVector * ForwardThrust);
        body.AddForce(forceRight * RightThrust);
        body.AddForce(forceLeft * LeftThrust);
        body.AddForce(forceBack * BackThrust);
    }
        
}
