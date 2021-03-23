using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objects2 : MonoBehaviour
{
    public LightColor color;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.activeColor == color)
        {
            transform.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            transform.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}