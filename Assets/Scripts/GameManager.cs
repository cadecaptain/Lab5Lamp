using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float FadeDuration = 0.5f;
    public GameObject events;
    public GameObject instructionsButton;
    public GameObject startButton;
    public GameObject sourcesButton;
    public GameObject canvas;
    public GameObject fade;


    public GameObject title;
    public GameObject backgroundImage;
    public GameObject sourcesText;
    public GameObject instructionsText;
    public GameObject replayText;
    public GameObject replayButton;

    public List<LightColor> bulbInventory = new List<LightColor>();
    public LightColor activeColor;

    private List<int> code = new List<int>();

    public GameObject hud;
    public GameObject hudBackground;
    public GameObject normalLight;
    public GameObject blackLight;
    public GameObject infraredLight;
    public GameObject greenLight;
    public String MainScene = "Ivy";

    private Color hudBackgroundColor;
    private Color yellowBackground = new Color(165, 165, 0, .25f);
    private Color purpleBackground = new Color(170, 0, 255, .25f);
    private Color redBackground = new Color(255, 0, 0, .25f);
    private Color greenBackground = new Color(0, 180, 0, .25f);
    private List<GameObject> lightList = new List<GameObject>();


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
            DontDestroyOnLoad(events);

            DontDestroyOnLoad(hud);
            DontDestroyOnLoad(hudBackground);
            DontDestroyOnLoad(normalLight);
            DontDestroyOnLoad(blackLight);
            DontDestroyOnLoad(infraredLight);
            DontDestroyOnLoad(greenLight);

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
        ChangeLight(LightColor.Regular);

        hudBackgroundColor = hudBackground.GetComponent<Image>().color;
        lightList.Add(normalLight);
        lightList.Add(blackLight);
        lightList.Add(infraredLight);
        lightList.Add(greenLight);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLightBulb(LightColor color)
    {
        Debug.Log("Adding " + color);
        if (!bulbInventory.Contains(color))
        {
            bulbInventory.Add(color);
        }

        if(color == LightColor.Green)
        {
            greenLight.SetActive(true);

        } else if (color == LightColor.Infrared)
        {
            infraredLight.SetActive(true);

        } else if (color == LightColor.BlackLight)
        {
            blackLight.SetActive(true);
        }

    }

    public void ChangeLight(LightColor color)
    {
        activeColor = color;
        ChooseLight(color);
    }

    public void InstructionsButton()
    {        
        sourcesText.SetActive(false);
        instructionsText.SetActive(true);

    }
    public void StartButton()
    {
        HideStartUI();
        HideWinUI();
        LoadScene(MainScene);
        EnableHud();
    }


    IEnumerator ColorLerp(Color color, float duration, GameObject fadeImage)
    {
        fadeImage.SetActive(true);
            float time = 0;
            Color startValue = fadeImage.GetComponent<Image>().color;

            while (time < duration)
            {
            fadeImage.GetComponent<Image>().color = Color.Lerp(startValue, color, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
        fadeImage.GetComponent<Image>().color = color;
        fadeImage.SetActive(false);

    }

    private void HideStartUI()
    {
        startButton.SetActive(false);
        instructionsButton.SetActive(false);
        sourcesButton.SetActive(false);
        title.SetActive(false);
        instructionsText.SetActive(false);
        sourcesText.SetActive(false);
        backgroundImage.SetActive(false);

    }

    public void SourcesButton()
    {
        instructionsText.SetActive(false);
        sourcesText.SetActive(true);
    }

    public void LoadScene(String SceneName)
    {
        StartCoroutine(ColorLerp(new Color(0, 0, 0, 0), FadeDuration, fade));
        SceneManager.LoadSceneAsync(SceneName);
    }

    public bool CheckInventory(LightColor lightColor)
    {
        return bulbInventory.Contains(lightColor);
    }

    public void CreateCode(int digit)
    {
        code.Add(digit);
    }

    public int[] GetCode()
    {
        int[] returnCode = code.ToArray();
        code.Clear();
        return returnCode;
    }


    public void EnableHud()
    {
        hud.SetActive(true);
        hudBackground.SetActive(true);
        Color hudBackgroundColor = hudBackground.GetComponent<Image>().color;
        hudBackgroundColor = yellowBackground;
        normalLight.SetActive(true);
        Debug.Log("starting hud with yellow background");

    }
    public void DisableHud()
    {
        hud.SetActive(false);
        activeColor = LightColor.Regular;
        bulbInventory = new List<LightColor> { LightColor.Regular };
        ChooseLight(LightColor.Regular);
    }


    public void ChooseLight(LightColor color)
    {
        GameObject activeLight = normalLight;
  
        if (color == LightColor.Regular)
        {
            activeLight = normalLight;
        }
        else if (color == LightColor.BlackLight)
        {
            activeLight = blackLight;
        }
        else if (color == LightColor.Infrared)
        {
            activeLight = infraredLight;
        }
        else if (color == LightColor.Green)
        {
            activeLight = greenLight;
        }


        foreach (GameObject bulb in lightList) {
            if (bulb != activeLight)
            {
                bulb.GetComponent<Image>().color = new Color(255, 255, 255, .25f);
                Debug.Log("translucent: " + bulb);
            } else
            {
                bulb.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                Debug.Log("changing light in UI to: " + bulb);
            }
        }

    }

    public void WinGame()
    {
        Debug.Log("Game won!");
        DisableHud();
        HideStartUI();
        ShowWinUI();
        throw new NotImplementedException("Not implemented");
    }

    private void ShowWinUI()
    {
        backgroundImage.SetActive(true);
        replayText.SetActive(true);
        replayButton.SetActive(true);
    }
    private void HideWinUI()
    {
        backgroundImage.SetActive(false);
        replayText.SetActive(false);
        replayButton.SetActive(false);
    }
}
