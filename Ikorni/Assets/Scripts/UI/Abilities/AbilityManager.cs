using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    public Image cooldownImage;
    public Image iconImage;
    public Sprite[] cooldownAnimation;
    public GameObject[] abilities = new GameObject[3];

    void Start()
    {
        Array.Reverse(cooldownAnimation);
    }
    public void StartAnimation(float secondsPerFrame)
    {
        cooldownImage.enabled = true;
        StartCoroutine(DisplayCooldown(secondsPerFrame));
    }

    private IEnumerator DisplayCooldown(float secondsPerFrame)
    {
        for (int i = 0; i < cooldownAnimation.Length; i++)
        {
            cooldownImage.sprite = cooldownAnimation[i];
            yield return new WaitForSeconds(secondsPerFrame);
        }
        cooldownImage.enabled = false;
    }
}
