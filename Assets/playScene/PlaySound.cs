using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlaySound : MonoBehaviour, ITrackableEventHandler {


    private TrackableBehaviour mtrackableBehaviour;
	// Use this for initialization
	void Start () {
        mtrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mtrackableBehaviour)
        {
            mtrackableBehaviour.RegisterTrackableEventHandler(this);
        }
	}
	
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if ( newStatus == TrackableBehaviour.Status.DETECTED || 
            newStatus == TrackableBehaviour.Status.TRACKED || 
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            GetComponent<AudioSource>().Play();
        else
            GetComponent<AudioSource>().Stop();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
