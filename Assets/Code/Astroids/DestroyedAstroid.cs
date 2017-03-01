using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedAstroid : MonoBehaviour 
{
    [SerializeField]
    private int hP = 1;
    [SerializeField]
    private float minRotate = 20.0f;
    [SerializeField]
    private float maxRotate = 20.0f;


    private Rigidbody2D body;

    #region Properties

    public int HP
    {
        get
        {
            return hP;
        }

        set
        {
            hP = value;
        }
    }

    #endregion

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.AddTorque(Random.Range(minRotate, maxRotate), ForceMode2D.Force);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //HP -= 1;
        //if (HP == 0)
        //{
        //    Destroy(gameObject);
        //}
    }

    void Update()
    {

    }
}
