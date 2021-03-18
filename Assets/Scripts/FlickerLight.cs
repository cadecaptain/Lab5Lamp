using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    // Start is called before the first frame update
    private float timePassed = 0f;
    private bool started = false;

    public float duration = 3f;
    public float flickerDuration = 0.5f;
    public float timeBeforeRestarting;
    public GameObject light;
    private Coroutine flashingCoroutine = null;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed < duration && !started)
        {
            Debug.Log("Starting!");
            started = true;
            flashingCoroutine = StartCoroutine(Flashing());
        }else if(timePassed >= duration)
        {
            StartCoroutine(Pause());
        }
    }
    IEnumerator Pause()
    {
        if(flashingCoroutine != null)
        {
            StopCoroutine(flashingCoroutine);
            started = false;
        }
        yield return new WaitForSeconds(timeBeforeRestarting);
        timePassed = 0;
    }
    IEnumerator Flashing ()
    {
        while (true)
        {
            yield return new WaitForSeconds(flickerDuration);
            //Debug.Log("Flashing")
            light.SetActive(!light.activeInHierarchy);
        }
    }
}
