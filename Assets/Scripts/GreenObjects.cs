using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4) && GameManager.Instance.CheckInventory(LightColor.Green))
        {
            transform.GetComponent<MeshRenderer>().enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) || (Input.GetKeyDown(KeyCode.Alpha2) && GameManager.Instance.CheckInventory(LightColor.BlackLight)) || (Input.GetKeyDown(KeyCode.Alpha3) && GameManager.Instance.CheckInventory(LightColor.Infrared)))
        {
            transform.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}