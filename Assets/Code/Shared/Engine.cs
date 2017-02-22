using System;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    [SerializeField]
    private float mass;
    [SerializeField]
    [Range(0,10)]
    private float thrust;
    [SerializeField]
    private bool toggle;
    [SerializeField]
    private float MaxThrust;
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float hullPoint;


    #region Properties

    public float Mass
    {
        get
        {
            return mass;
        }
    }

    public float Thrust
    {
        get
        {
            return thrust;
        }

        set
        {
            thrust = value;
        }
    }

    public bool Toggle
    {
        get
        {
            return toggle;
        }

        set
        {
            toggle = value;
        }
    }

    public float Acceleration
    {
        get
        {
            return acceleration;
        }
    }

    public float HullPoint
    {
        get
        {
            return hullPoint;
        }

        set
        {
            hullPoint = value;
        }
    }

    #endregion

    private void Update()
    {
        if (Toggle)
        {
            GetComponentInParent<Rigidbody2D>().AddForce(-transform.right * Thrust);
        }
    }
}
