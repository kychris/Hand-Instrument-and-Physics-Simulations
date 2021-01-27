using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MyGestureRecognizer : MonoBehaviour
{
    [Tooltip("Event that runs when we recognize a gesture")]
    public UnityEvent OnGestureRecognized;

    [Tooltip("Choose a GestureSO asset file to recognize")]
    public GestureSO GestureToRecognize;

    [Tooltip("Choose a hand to recognize")]
    public OVRSkeleton skeleton;

    [Tooltip("Minimum time between each recognition to avoid repetitive recognition")]
    public float timeBetweenRecognition = 2f;


    List<OVRBone> fingerBones;
    OVRHand hand;
    float recognitionThreshold = .04f;
    float lastRecognition;

    // Start is called before the first frame update
    void Start()
    {
        fingerBones = new List<OVRBone>(skeleton.Bones);
        hand = skeleton.gameObject.GetComponent<OVRHand>();
        lastRecognition = timeBetweenRecognition;
    }

    // Update is called once per frame
    void Update()
    {
        lastRecognition += Time.deltaTime;
        if (lastRecognition < timeBetweenRecognition)
            return;

        if (IsRecognized())
        {
            OnGestureRecognized?.Invoke();
            lastRecognition = 0f;
        }
    }

    bool IsRecognized()
    {
        for (int i = 0; i < fingerBones.Count; i++)
        {
            // Get current finger position relative to root
            Vector3 currentData = skeleton.transform.InverseTransformPoint(fingerBones[i].Transform.position);
            float distance = Vector3.Distance(GestureToRecognize.fingerPositions[i], currentData);
            if (distance > recognitionThreshold)
            {
                return false;
            }
        }

        return true;
    }
}



/*

pros and cons of recognizing in one place vs multiple components

multiple components
* modulized, easy to use
* need to use time based interval to prevent repetitive recognition

one place
* repetitive recognition can be easily avoided, however is bad for things like instrument
* gestures all in one place, convenient, but not super modulized 

*/

