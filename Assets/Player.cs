using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 12f;
    [SerializeField] float xRange = 4.5f;

    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 12f;
    [SerializeField] float yRange = 2.8f;

    [SerializeField] float yawMult = 6f;
    [SerializeField] float pitchMult = -5f;

    float xThrow, yThrow;

    [SerializeField] float controlPitchMult = -20f;
    [SerializeField] float controlYawMult = 15f;
    [SerializeField] float controlRollFactor = -20f;

    bool isControlEnabled = true;

    [SerializeField] GameObject[] Guns;

    // Update is called once per frame
    void Update()
    {
        if(isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
        
        
    }

    private void ProcessFiring()
    {
        if (Input.GetAxisRaw("Fire1") != 0)
        {
            ActivateGuns();
        }
        else
        {
            DeactivateGuns();
        }
    }

    private void ActivateGuns()
    {
        foreach (GameObject gun in Guns)
        {
            gun.SetActive(true);
        }
    }

    private void DeactivateGuns()
    {
        foreach (GameObject gun in Guns)
        {
            gun.SetActive(false);
        }
    }



    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * pitchMult + yThrow * controlPitchMult;
        float yaw = transform.localPosition.x * yawMult + xThrow * controlYawMult;        
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        //xposition
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * Time.deltaTime * xSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);


        //yposition
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * Time.deltaTime * ySpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void OnPlayerDeath() //called by string reference!!
    {
        print("controls frozen");
        isControlEnabled = false;
    }
}
