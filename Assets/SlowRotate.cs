﻿using UnityEngine;
using System.Collections;

public class SlowRotate : MonoBehaviour {
    public Vector3 rotateAmount = new Vector3(0f, 0f, .4f);
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotateAmount);
	}
}
