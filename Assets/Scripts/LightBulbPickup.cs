using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulbPickup : MonoBehaviour
{
    // Start is called before the first frame update
    public LightColor lightColor = LightColor.Regular;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AddLightBulbToInventory();
            Destroy(gameObject);
        }
    }

    private void AddLightBulbToInventory()
    {
        Debug.Log("Lightbulb picked up!");
        GameManager.Instance.AddLightBulb(lightColor);
    }

}
