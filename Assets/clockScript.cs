using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockScript : MonoBehaviour
{

    public int hour = 0;
    public int minutes = 0;   
    public int seconds = 0;
    public bool realTime = true;

    public bool smoothClock=false;

    public bool SecoundHand = true;
    public bool minutesHand = true; 
    public bool hourseHand = true;

    public GameObject pointerSeconds;
    public GameObject pointerMinutes;
    public GameObject pointerHours;

    public float clockSpeed = 1.0f;      
   
    void Start()
    { 
        if (realTime)
        {
            hour = System.DateTime.Now.Hour;
            minutes = System.DateTime.Now.Minute;
            seconds = System.DateTime.Now.Second;
        }
    }
    void Update()
    {       
       

        findAngleOfHand();   
    }
  void findAngleOfHand()
  {
        float rotationSeconds = 0.0f;
        float rotationMinutes = 0.0f;
        float rotationHours = 0.0f;
         if (SecoundHand)
         {
           rotationSeconds = -(System.DateTime.Now.Second / 60.0f) * 360.0f ;
          
         }
         if(minutesHand)
         {
           rotationMinutes = -(System.DateTime.Now.Minute / 60.0f) * 360.0f;
         
         }
         if(hourseHand)
         {
            rotationHours = -((System.DateTime.Now.Hour % 12) * 30f + (System.DateTime.Now.Minute / 60.0f) * 30f);


            //rotationHours = -(System.DateTime.Now.Hour / 12.0f) * 360.0f;
            //rotationHours = -((360.0f / 12.0f) * System.DateTime.Now.Hour) + ((360.0f / (60.0f * 12.0f)) * System.DateTime.Now.Minute);
            //rotationHours = -((System.DateTime.Now.Hour / 12.0f) * 360.0f + (360.0f / (60.0f * 12.0f)) * System.DateTime.Now.Minute);
            //rotationHours = -(System.DateTime.Now.Hour / 12.0f) * 360.0f;
           // Debug.Log(rotationHours);
          
         }
        if (!smoothClock)
        {
            pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
            pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
            pointerHours.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationHours);
            
        }
        else if (smoothClock)
        {
              RotateClockHand(pointerSeconds, rotationSeconds);
              RotateClockHand(pointerMinutes, rotationMinutes);
              RotateClockHand(pointerHours, rotationHours);
        }
    }
     void RotateClockHand(GameObject hand, float targetRotation)
      {
          Quaternion currentRotation = hand.transform.localRotation;
          Quaternion targetRotationQuat = Quaternion.Euler(0.0f, 0.0f, targetRotation);
          hand.transform.localRotation = Quaternion.Lerp(currentRotation, targetRotationQuat, Time.deltaTime * 0.97f);
      }
   
}
