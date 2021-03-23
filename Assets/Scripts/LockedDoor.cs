using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{

    public GameObject leftDoor;
    public GameObject rightDoor;

    public float duration = 2f;
    private float moveSpeed = .005f;

    private bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!open)
        {
            StartCoroutine(MoveDoor(-1, leftDoor.transform));
            StartCoroutine(MoveDoor(1, rightDoor.transform));
            open = true;
        }
    }

    IEnumerator MoveDoor(int leftOrRight, Transform transform)
    {
        float time = 0;

        while (time < duration)
        {
            transform.position = new Vector3(transform.position.x + (moveSpeed * leftOrRight), transform.position.y, transform.position.z);
            time += Time.deltaTime;
            yield return null;
        }

    }

}
