﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.GetComponent<OVRGrabbable>().isGrabbed)
        {
            Debug.Log("Grab");
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
            {
                Application.LoadLevel("SampleScene");
            }
        }
	}
}
