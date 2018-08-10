using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class OnTrackBeach : MonoBehaviour, ITrackableEventHandler
{
    GameObject boatObj;

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        
        boatObj.SetActive(false);
    }

    // Use this for initialization
    void Start () {
        boatObj = new GameObject("boat");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
