using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using FMODUnity;

public class EasyRhythmAudioManagerCustom : MonoBehaviour
{

   /*
    // FMOD
    public EventReference event90, event120v1, event120v2, event140, eventLobby, eventDie, eventIntro, eventNone; // Game Music Event
    public EasyEvent myAudioEvent; // EasyEvent is the object that will play the FMOD audio event, and provide our callbacks and other related info

    // You can pass an array of IEasyListeners through to the FMOD event, but we have to serialize them as objects.
    // You have to drag the COMPONENT that implements the IEasyListener into the object, or it won't work properly
    [RequireInterface(typeof(IEasyListener))]
    public Object[] myEventListeners;

    public void changeMusic(string state)
    {
        if(myAudioEvent != null)
            myAudioEvent.stop();
        switch (state)
        {
            case "weapon_01":
                myAudioEvent = new EasyEvent(event90.Path, myEventListeners);
                break;
            case "weapon_02":
                myAudioEvent = new EasyEvent(event120v1.Path, myEventListeners);
                break;
            case "weapon_03":
                myAudioEvent = new EasyEvent(event120v2.Path, myEventListeners);
                break;
            case "weapon_04":
                myAudioEvent = new EasyEvent(event140.Path, myEventListeners);
                break;
            case "died":
                myAudioEvent = new EasyEvent(eventDie.Path, myEventListeners);
                break;
            case "lobby":
                myAudioEvent = new EasyEvent(eventLobby.Path, myEventListeners);
                break;
            case "intro":
                myAudioEvent = new EasyEvent(eventIntro.Path, myEventListeners);
                break;
            case "none":
                myAudioEvent = new EasyEvent(eventNone.Path, myEventListeners);
                break;
            default:
                break;
        }
        myAudioEvent.start();
    }
    */
}