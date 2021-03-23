using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{

    Animator animator;

    public float duration = 5f;
    public float distance;
    public GameObject pos;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * duration, distance), transform.position.y, transform.position.z);
        if (GameObject.FindGameObjectWithTag("Monster").transform.position.x == distance - .1)
        {
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.y += 180;
            transform.rotation = Quaternion.Euler(rotationVector);
            
        }
    }
    
    
}
