using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrash : MonoBehaviour
{
    float Timer = 19;

    private float velocity; 
    // Start is called before the first frame update
    void Start()
    {
        Timer = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            Debug.Log("spped");
            velocity += 0.2f;
        }
        transform.Translate(Vector3.right * velocity * Time.deltaTime);
        
        Timer = Timer - Time.deltaTime;
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
            this.transform.position = new Vector3(65f, 6f, 150f);
            velocity = 0f;
        
    }

    
}
