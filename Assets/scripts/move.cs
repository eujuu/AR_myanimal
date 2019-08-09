using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

	// Use this for initialization
	void Start () {
        foreach(Transform child in transform)
        child.position += Vector3.up * 10.0f;
	}
	

}
