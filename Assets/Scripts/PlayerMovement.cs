using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform graphicsTransform;
    AudioSource audio;
    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public LightColor activeLight;
    public GameObject regularLight;
    public GameObject blackLight;
    public GameObject infraredLight;
    public GameObject greenLight;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1)
        {
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(graphicsTransform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            graphicsTransform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("User pressed key 1");
            lightRegular();
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("User pressed key 2");
            lightBlackLight();
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("User pressed key 3");
            lightInfrared();
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("User pressed key 4");
            lightGreen();
            
        }

    }

    void lightRegular()
    {
        
        blackLight.SetActive(false);
        infraredLight.SetActive(false);
        greenLight.SetActive(false);
        regularLight.SetActive(true);
        audio.Play();
        GameManager.Instance.ChangeLight(LightColor.Regular);
        
    }

    void lightBlackLight()
    {
        if (GameManager.Instance.CheckInventory(LightColor.BlackLight))
        {
            infraredLight.SetActive(false);
            greenLight.SetActive(false);
            regularLight.SetActive(false);
            blackLight.SetActive(true);
            audio.Play();
            GameManager.Instance.ChangeLight(LightColor.BlackLight);
        }

    }

    void lightInfrared()
    {
        if (GameManager.Instance.CheckInventory(LightColor.Infrared))
        {
            blackLight.SetActive(false);
            infraredLight.SetActive(true);
            greenLight.SetActive(false);
            regularLight.SetActive(false);
            audio.Play();
            GameManager.Instance.ChangeLight(LightColor.Infrared);
        }
    }

    void lightGreen()
    {
        if (GameManager.Instance.CheckInventory(LightColor.Green))
        {
            blackLight.SetActive(false);
            infraredLight.SetActive(false);
            regularLight.SetActive(false);
            greenLight.SetActive(true);
            audio.Play();
            GameManager.Instance.ChangeLight(LightColor.Green);
        }
    }
}
