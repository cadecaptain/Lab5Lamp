using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{

    Animator animator;

    public float duration = 5f;
    public float distance;
    public GameObject pos;
    private double firstpos;
    private int flip;
    private float turn = 2;
    private float end = 0;
    

    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        firstpos = GameObject.FindGameObjectWithTag("Monster").transform.position.x;
        flip = 0;


    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(Mathf.PingPong(Time.time * duration, distance), transform.position.y, transform.position.z);
        if (GameObject.FindGameObjectWithTag("Monster").transform.position.x >= (firstpos + (distance - .2)) && (flip == 0))
        {
            Debug.Log("hey");
            
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.y += 180;
            transform.rotation = Quaternion.Euler(rotationVector);
            flip = 1;
            
        }
       
        if (GameObject.FindGameObjectWithTag("Monster").transform.position.x <= (firstpos + .2) && (flip == 1))
        {
            Debug.Log("hey");
            
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.y -= 180;
            transform.rotation = Quaternion.Euler(rotationVector);
            flip = 0;
        };
        
    }
    
}
