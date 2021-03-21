using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject events;
    public GameObject instructionsButton;
    public GameObject startButton;
    public GameObject sourcesButton;
    public GameObject canvas;

    public GameObject title;
    public GameObject backgroundImage;
    public GameObject sourcesText;
    public GameObject instructionsText;
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

    public void InstructionsButton()
    {

       
        
        instructionsButton.SetActive(false);
        sourcesButton.SetActive(true);
        sourcesText.GetComponent<TextMeshProUGUI>().text = "";
        instructionsText.GetComponent<TextMeshProUGUI>().text = "Find your bulb";


    }
    public void StartButton()
    {

        //StartCoroutine(ColorLerp(new Color(1, 1, 1, 0), 2,backgroundImage));
        startButton.SetActive(false);
        instructionsButton.SetActive(false);
        sourcesButton.SetActive(false);
        title.SetActive(false);
        instructionsText.GetComponent<TextMeshProUGUI>().text = "";
        sourcesText.GetComponent<TextMeshProUGUI>().text = "";

       
    }
    public void SourcesButton()
    {

        instructionsButton.SetActive(true);
        sourcesButton.SetActive(false);
        instructionsText.GetComponent<TextMeshProUGUI>().text = "";
        sourcesText.GetComponent<TextMeshProUGUI>().text = "There will be some here";
    }

    }
