using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightBulbPickup : MonoBehaviour
{
    // Start is called before the first frame update
    public LightColor lightColor = LightColor.Regular;
    public Light light;
    AudioSource audio;
   
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lightColor == LightColor.Regular)
        {
            Debug.Log("Regular!");
            light.color = new Color(0xFF, 0xF4, 0xD6);
        }
        else if (lightColor == LightColor.BlackLight)
        {
            Debug.Log("Black!");
            light.color = new Color(0xE1, 0xAC, 0xFF);
        }
        else if (lightColor == LightColor.Infrared)
        {
            //Debug.Log("Infrared");

            light.color = new Color(0xFF, 0xB4, 0x8F);
        }
        else if (lightColor == LightColor.Green)
        {
            Debug.Log("Green");
            light.color = new Color(0x9C, 0xFF, 0x86);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AddLightBulbToInventory();
            audio.Play();
            Destroy(gameObject);
        }
    }

    private void AddLightBulbToInventory()
    {
        Debug.Log("Lightbulb picked up!");
        GameManager.Instance.AddLightBulb(lightColor);
    }

}
