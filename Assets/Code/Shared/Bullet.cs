using System;
using System.Collections.Generic;
using UnityEngine;

class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float timeToLive;

    private Rigidbody2D body;

    #region Properties

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public float Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }

    public float TimeToLive
    {
        get
        {
            return timeToLive;
        }

        set
        {
            timeToLive = value;
        }
    }



    #endregion

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {

    }

    void FixedUpdate()
    {
        body.velocity = transform.right * speed;
        Destroy(gameObject, TimeToLive);
    }
}

