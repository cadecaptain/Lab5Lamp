using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject events;

    public List<LightColor> bulbInventory = new List<LightColor>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        AddLightBulb(LightColor.Regular);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLightBulb(LightColor color)
    {
        if (!bulbInventory.Contains(color))
        {
            bulbInventory.Add(color);
        }
    }
}
