using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SpawnInformation
{
    public GameObject preFab;
    public float chance;
}

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
    [SerializeField]
    private SpawnInformation[] spawnPrefab;

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
            GameObject destAstroid0 = Instantiate(destroyedAstroidPrefab0, new Vector3(transform.position.x - 0.6f, transform.position.y + 0.6f), Quaternion.identity);
            GameObject destAstroid1 = Instantiate(destroyedAstroidPrefab1, new Vector3(transform.position.x + 0.6f, transform.position.y + 0.6f), Quaternion.identity);
            GameObject destAstroid2 = Instantiate(destroyedAstroidPrefab2, new Vector3(transform.position.x - 0.6f, transform.position.y - 0.6f), Quaternion.identity);
            GameObject destAstroid3 = Instantiate(destroyedAstroidPrefab3, new Vector3(transform.position.x + 0.6f, transform.position.y - 0.6f), Quaternion.identity);
            destAstroid0.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.3f, 0.3f) * 5.0f;
            destAstroid1.GetComponent<Rigidbody2D>().velocity = new Vector2( 0.3f, 0.3f) * 5.0f;
            destAstroid2.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.3f, -0.3f) * 5.0f;
            destAstroid3.GetComponent<Rigidbody2D>().velocity = new Vector2( 0.3f, -0.3f) * 5.0f;

        }
    }

    void Update () 
	{
		
	}
}
