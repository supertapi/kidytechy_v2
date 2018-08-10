using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using DentedPixel;

public class OnTrackBoatScript : MonoBehaviour, ITrackableEventHandler {

    GameObject boatObj;
    GameObject bolaObj;
    GameObject boyObj;
    GameObject dogObj;
    GameObject start2Obj;
    Animator anim;

    private TrackableBehaviour mTrackableBehaviour;
    public static int st = 0;
    

    // Use this for initialization
    void Start()
    {
        boatObj = GameObject.Find("boat");
        bolaObj = GameObject.Find("Bola");
        boyObj = GameObject.Find("boy");
        dogObj = GameObject.Find("dog");
        start2Obj = GameObject.Find("Estrella.002");
        anim = boyObj.GetComponent<Animator>();
        boatObj.SetActive(false);

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == null)
            throw new System.ArgumentNullException("newStatus");

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            st = 1;
            boatObj.SetActive(true);
            //LeanTween.moveZ(boatObj, (float)2.515, 0.5f);
            Invoke("boyJump", 0);
            Invoke("moveBoat", 2);
            Invoke("putBoyDogOnTopOfBoat", 3);
            Invoke("goByBoat", 4);
            bolaObj.SetActive(false);
        }

        print();

    }
    
    //makes the boy jump
    public void boyJump()
    {
        anim.Play("jump1");
    }

    //moves the boat
    public void moveBoat()
    {
        LeanTween.move(boatObj, bolaObj.transform, 2.5f).setEase(LeanTweenType.easeOutQuad);
    }

    //event that is launched qhen the as is detected
    public void OnTrackableStateChanged(TrackableBehaviour.Status newStatus)
    {
        OnTrackableStateChanged(default(TrackableBehaviour.Status), newStatus);
    }

    public void putBoyDogOnTopOfBoat()
    {
        LeanTween.move(boyObj, boatObj.transform, 1.0f).setEase(LeanTweenType.easeOutQuad);
        LeanTween.move(dogObj, boatObj.transform, 1.0f).setEase(LeanTweenType.easeOutQuad);
    }

    public void goByBoat()
    {
        LeanTween.move(boyObj, start2Obj.transform, 1.0f).setEase(LeanTweenType.easeOutQuad);
        LeanTween.move(dogObj, start2Obj.transform, 1.0f).setEase(LeanTweenType.easeOutQuad);
        LeanTween.move(boatObj, start2Obj.transform, 1.0f).setEase(LeanTweenType.easeOutQuad);
    }

    static void print()
    {
        Debug.Log("st :" + st);
        print("st :" + st);
    }
}
