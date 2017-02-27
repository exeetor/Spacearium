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

    void Start()
    {
        GetComponentInParent<Rigidbody2D>().mass += Mass;
    }

    private void Update()
    {
        if (Toggle)
        {
            GetComponentInParent<Rigidbody2D>().AddForce(-transform.right * Thrust);
            GetComponentInParent<Rigidbody2D>().drag = 0;
        }
        else
            GetComponentInParent<Rigidbody2D>().drag = 0.5f;
    }
}
