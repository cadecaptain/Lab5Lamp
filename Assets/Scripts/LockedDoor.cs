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
    private int[] code = new int[6] { 0, 0, 0, 1, 1, 2 };

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
        audio.Play();
        if (!open)
        {
            if (ArrayCompare(GameManager.Instance.GetCode(), code))
            {
                StartCoroutine(MoveDoor(-1, leftDoor.transform));
                StartCoroutine(MoveDoor(1, rightDoor.transform));
                open = true;
            }
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

    private bool ArrayCompare(int[] code1, int[] code2)
    {
        for (int i = 0; i < code1.Length; i++)
        {
            if (code1[i] != code2[i])
            {
                return false;
            }
        }
        if (code1.Length == 6)
        {
            return true;
        }
        return false;
    }

}
