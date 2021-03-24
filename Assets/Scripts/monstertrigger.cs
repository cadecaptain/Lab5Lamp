using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monstertrigger : MonoBehaviour
{
    AudioSource audio;
    public string whichlevel;


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Debug.Log("hey");
            audio.Play();
            
            Invoke("wait", 1.2f);
            


        }

    }
    void wait()
    {
        GameManager.Instance.LoadScene(whichlevel);
    }
}
