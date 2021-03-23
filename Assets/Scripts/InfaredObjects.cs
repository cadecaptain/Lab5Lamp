using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfaredObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            transform.GetComponent<MeshRenderer>().enabled = true;
        } if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            transform.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
