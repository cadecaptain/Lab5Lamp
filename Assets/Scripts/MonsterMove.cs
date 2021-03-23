using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{

    Animator animator;

    public float duration = 5f;
    public float distance;
    public GameObject pos;
    private float firstpos;
    private int flip;
    
    private float addx;
    AudioSource audio;




    // Start is called before the first frame update
    void Start()
    {
       
        firstpos = transform.position.x;
        flip = 0;


    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("hey");
            audio.Play();
        }
    }
    //https://www.youtube.com/watch?v=nG68yEB73SQ&t=437s
    // Update is called once per frame
    void Update()
    {
        addx = Mathf.PingPong(Time.time * duration, distance);
        transform.position = new Vector3(firstpos+addx, transform.position.y, transform.position.z);
        if (transform.position.x >= (firstpos + (distance - .3)) && (flip == 0))
        {
           
            
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.y += 180;
            transform.rotation = Quaternion.Euler(rotationVector);
            flip = 1;
            
        }
       
        if (transform.position.x <= (firstpos + .3) && (flip == 1))
        {
            
            
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.y -= 180;
            transform.rotation = Quaternion.Euler(rotationVector);
            flip = 0;
        }

        

    }
    
}
