using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{

    public GameObject leftDoor;
    public GameObject rightDoor;

    public float duration = 2f;
    private float moveSpeed = .005f;

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
        Debug.Log("Entered!");
        StartCoroutine(MoveDoor(-1, leftDoor.transform));
        StartCoroutine(MoveDoor(1, rightDoor.transform));
    }

    IEnumerator MoveDoor(int leftOrRight, Transform transform)
    {
        float time = 0;
        Debug.Log("Start CoRoutine");

        while (time < duration)
        {
            transform.position = new Vector3(transform.position.x + (moveSpeed * leftOrRight), transform.position.y, transform.position.z);
            time += Time.deltaTime;
            yield return null;
            Debug.Log("Doing stuff");
        }

    }

}
