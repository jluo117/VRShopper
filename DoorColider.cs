using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorColider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Crash Time");
        Application.LoadLevel("SampleScene");
    }
}
