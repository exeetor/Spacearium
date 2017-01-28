using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public float Speed;
    private Vector3 targetPosition;
	// Use this for initialization
	void Start ()
    {
	}
    

    // Update is called once per frame
    void Update ()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5f;
        Vector3 mousePosMove = mousePos;
        

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePosMove.x = mousePosMove.x - objectPos.x;
        mousePosMove.y = mousePosMove.y - objectPos.y;


        float angle = Mathf.Atan2(mousePosMove.y, mousePosMove.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle+90));

        if (Input.GetKey(KeyCode.W))
        {
            if (Speed < 15)
            {
                Speed = Speed + 3f;
            }            
            targetPosition = Camera.main.ScreenToWorldPoint(mousePos);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Speed = Speed - 2f;
            targetPosition = Camera.main.ScreenToWorldPoint(mousePos);
        }

        

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * Speed);
        
        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        //GetComponent<Transform>().position += move * speed * Time.deltaTime;
    }
}
