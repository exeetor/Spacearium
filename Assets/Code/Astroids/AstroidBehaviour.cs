using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidBehaviour : MonoBehaviour 
{
    [SerializeField]
    private int hP = 3;

    private Rigidbody2D body;
    private SpriteRenderer sprite;
    [SerializeField]
    private Sprite[] astroidSprites;
    [SerializeField]
    private GameObject destroyedAstroidPrefab0;
    [SerializeField]
    private GameObject destroyedAstroidPrefab1;
    [SerializeField]
    private GameObject destroyedAstroidPrefab2;
    [SerializeField]
    private GameObject destroyedAstroidPrefab3;

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

    void Start () 
	{
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        body.AddTorque(15,ForceMode2D.Force);
        sprite.sprite = astroidSprites[3];
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        HP -= 1;
        sprite.sprite = astroidSprites[HP];
        if (HP == 0)
        {
            Destroy(gameObject);
            Instantiate(destroyedAstroidPrefab0, transform.position, transform.rotation);
            Instantiate(destroyedAstroidPrefab1, transform.position, transform.rotation);
            Instantiate(destroyedAstroidPrefab2, transform.position, transform.rotation);
            Instantiate(destroyedAstroidPrefab3, transform.position, transform.rotation);
        }
    }

    void Update () 
	{
		
	}
}
