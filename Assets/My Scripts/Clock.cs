using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] GameObject secondHand;
    [SerializeField] GameObject minuteHand;
    [SerializeField] GameObject hourHand;
    [SerializeField] AudioSource audioSource;
    DateTime currentTime;
    Vector3 startingSecondRotation = new Vector3(0,0,-90);
    Vector3 startingMinuteRotation = new Vector3(0, 0, -90);
    Vector3 startingHourRotation = new Vector3(0, 0, -90);

    private void Start()
    {
        currentTime = DateTime.Now;

        float percentForSeconds = currentTime.Second / 60.0f;
        float percentForMinutes = currentTime.Minute / 60.0f;
        float percentForHours = currentTime.Hour < 13 ? currentTime.Hour / 12.0f : (currentTime.Hour - 12) / 12.0f;

        secondHand.transform.localRotation = Quaternion.Euler(new Vector3(360 * percentForSeconds + 90, startingSecondRotation.y, startingSecondRotation.z));
        minuteHand.transform.localRotation = Quaternion.Euler(new Vector3(360 * percentForMinutes + 90, startingMinuteRotation.y, startingMinuteRotation.z));
        hourHand.transform.localRotation = Quaternion.Euler(new Vector3(360 * percentForHours + 90, startingHourRotation.y, startingHourRotation.z));
    }

    private void Update()
    {
        DateTime checker = DateTime.Now;
        if (currentTime.Second != checker.Second)
        {
            currentTime = DateTime.Now;

            //currently it is set such that 12 = 90 and 9 = 0
            float percentForSeconds = currentTime.Second / 60.0f;
            float percentForMinutes = currentTime.Minute / 60.0f;
            float percentForHours = currentTime.Hour < 13? currentTime.Hour / 12.0f : (currentTime.Hour - 12)/12.0f;

            secondHand.transform.localRotation = Quaternion.Euler(new Vector3(360 * percentForSeconds + 90, startingSecondRotation.y, startingSecondRotation.z));
            minuteHand.transform.localRotation = Quaternion.Euler(new Vector3(360 * percentForMinutes + 90, startingMinuteRotation.y, startingMinuteRotation.z));
            hourHand.transform.localRotation = Quaternion.Euler(new Vector3(360 * percentForHours + 90, startingHourRotation.y, startingHourRotation.z));
            PlaySound();
            Debug.Log(currentTime);
        }
    }

    private void PlaySound()
    {
        audioSource.Play();
    }
}
