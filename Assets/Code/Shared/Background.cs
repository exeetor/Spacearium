using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    Material mat;
    [Range(1,200)]
    public float parallax = 1f;

	// Use this for initialization
	void Start () {
        mat = GetComponent<MeshRenderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        mat.mainTextureOffset = transform.position / parallax;
    }
}
