using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LeftHandInstrument : MonoBehaviour
{
    bool[] playable = new bool[] { true, true, true, true };
    OVRHand hand;
    OVRHand test;

    AudioSource c4;
    AudioSource d4;
    AudioSource e4;
    AudioSource f4;


    void Start()
    {
        c4 = GameObject.Find("C4").GetComponent<AudioSource>();
        d4 = GameObject.Find("D4").GetComponent<AudioSource>();
        e4 = GameObject.Find("E4").GetComponent<AudioSource>();
        f4 = GameObject.Find("F4").GetComponent<AudioSource>();
        hand = GetComponent<OVRHand>();
    }

    // Update is called once per frame
    void Update()
    {
        float indexFingerPinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
        float middlePinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Middle);
        float ringFingerPinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Ring);
        float pinkyFingerPinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Pinky);

        #region index finger
        if (indexFingerPinchStrength == 1 & playable[0] == true)
        {
            c4.Play();
            playable[0] = false;
        }
        if (indexFingerPinchStrength < 0.5)
            playable[0] = true;
        #endregion

        #region middle finger
        if (middlePinchStrength == 1 & playable[1] == true)
        {
            d4.Play();
            playable[1] = false;
        }
        if (middlePinchStrength < 0.5)
            playable[1] = true;
        #endregion

        #region ring finger
        if (ringFingerPinchStrength == 1 & playable[2] == true)
        {
            e4.Play();
            playable[2] = false;
        }
        if (ringFingerPinchStrength < 0.5)
            playable[2] = true;
        #endregion

        #region pinky finger   
        if (pinkyFingerPinchStrength == 1 & playable[3] == true)
        {
            f4.Play();
            playable[3] = false;
        }
        if (pinkyFingerPinchStrength < 0.5)
            playable[3] = true;
        #endregion
    }
}
