using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    // Use this for initialization
    public float expiryTime = 0f;

    void Start () {
        Destroy(gameObject, expiryTime);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
