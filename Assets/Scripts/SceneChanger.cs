using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public string whichScene;


    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.LoadScene(whichScene);
    }
}
