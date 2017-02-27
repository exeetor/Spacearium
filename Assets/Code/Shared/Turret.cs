﻿using System;
using System.Collections.Generic;
using UnityEngine;

class Turret : MonoBehaviour
{
    public GameObject bulletPrefab;
    [SerializeField]
    private float rateOfFire;
    [SerializeField]
    private float mass;

    private bool toggle;
    private float firetime;

    #region Properties
    public float RateOfFire
    {
        get
        {
            return rateOfFire;
        }

        set
        {
            rateOfFire = value;
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

    public float Mass
    {
        get
        {
            return mass;
        }

        set
        {
            mass = value;
        }
    }


    #endregion

    void Start()
    {
        firetime = 0;
        GetComponentInParent<Rigidbody2D>().mass += mass;
    }

    private void Awake()
    {

    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        firetime = firetime - Time.deltaTime;
        if (firetime < 0 && Toggle)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            firetime = RateOfFire;
        }
    }
}
