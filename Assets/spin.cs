﻿using UnityEngine;
using System.Collections;

public class spin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.down*5 * Time.deltaTime);
    }
}
