using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monstertrigger : MonoBehaviour
{
    AudioSource audio;
    
    
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
            for (int i = 0; i < 4; i++)
            {
                this.gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
            }
            Destroy(gameObject, audio.clip.length);
            

        }
    }
}
