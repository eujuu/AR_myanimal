using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
public class TrackingObject : MonoBehaviour, ITrackableEventHandler {
    private TrackableBehaviour mTrackableBehaviour;
    public bool is_detected_ = false;
    public TextMesh obj_text_mesh;
    // Use this for initialization
    void Start () {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
            // 상태가 변하는 것에 대해 인지
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        { // 새로운 상태가 DETECTED 또는 TRAKED 되면 is_detected를 true로 아니면 false로 하여 현재의 트래킹 상태를 알 수 있도록 함
            is_detected_ = true;

        }
        else
        {
            is_detected_ = false;
        }
    }
}
