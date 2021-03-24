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
    public List<LightColor> bulbInventory = new List<LightColor>();
    public LightColor activeColor;

    private List<int> code = new List<int>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
            DontDestroyOnLoad(events);
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
    }

    public void ChangeLight(LightColor color)
    {
            activeColor = color;
    }

    public void InstructionsButton()
    {        
        sourcesText.SetActive(false);
        instructionsText.SetActive(true);

    }
    public void StartButton()
    {
        HideStartUI();
        LoadScene("BlackLight Level");
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

}
