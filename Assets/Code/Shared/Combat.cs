using System;
using System.Collections.Generic;
using UnityEngine;

class Combat : MonoBehaviour
{
    private bool toggleMainWeapon = false;
    [SerializeField]
    private Turret turret;

    #region Properties
    public bool ToggleMainWeapon
    {
        get
        {
            return toggleMainWeapon;
        }

        set
        {
            toggleMainWeapon = value;
        }
    }
    #endregion

    void Start()
    {

    }

    private void Awake()
    {

    }

    void FixedUpdate()
    {
        turret.Toggle = toggleMainWeapon;
    }
}

