using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPads : MonoBehaviour
{
    // 0 = red
    // 1 = blue
    // 2 = green
    public int color;
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        audio.Play();
        GameManager.Instance.CreateCode(color);
        Debug.Log("Added " + color + " to the code");
    }
}
