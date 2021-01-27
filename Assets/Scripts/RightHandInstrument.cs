using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandInstrument : MonoBehaviour
{
    bool[] playable = new bool[] { true, true, true, true };
    OVRHand hand;

    AudioSource g4;
    AudioSource a4;
    AudioSource b4;
    AudioSource c5;

    void Start()
    {
        g4 = GameObject.Find("G4").GetComponent<AudioSource>();
        a4 = GameObject.Find("A4").GetComponent<AudioSource>();
        b4 = GameObject.Find("B4").GetComponent<AudioSource>();
        c5 = GameObject.Find("C5").GetComponent<AudioSource>();
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
            c5.Play();
            playable[0] = false;
        }
        if (indexFingerPinchStrength < 0.5)
            playable[0] = true;
        #endregion

        #region middle finger
        if (middlePinchStrength == 1 & playable[1] == true)
        {
            b4.Play();
            playable[1] = false;
        }
        if (middlePinchStrength < 0.5)
            playable[1] = true;
        #endregion

        #region ring finger
        if (ringFingerPinchStrength == 1 & playable[2] == true)
        {
            a4.Play();
            playable[2] = false;
        }
        if (ringFingerPinchStrength < 0.5)
            playable[2] = true;
        #endregion

        #region pinky finger   
        if (pinkyFingerPinchStrength == 1 & playable[3] == true)
        {
            g4.Play();
            playable[3] = false;
        }
        if (pinkyFingerPinchStrength < 0.5)
            playable[3] = true;
        #endregion
    }
}
