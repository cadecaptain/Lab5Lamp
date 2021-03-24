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
            if (color == LightColor.Green)
            {
                transform.GetComponent<SkinnedMeshRenderer>().enabled = true;
            }
            else
            {
                transform.GetComponent<MeshRenderer>().enabled = true;
            }
        }
        else
        {
            if (color == LightColor.Green)
            {
                transform.GetComponent<SkinnedMeshRenderer>().enabled = false;
            }
            else
            {
                transform.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}