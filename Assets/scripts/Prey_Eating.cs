using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Prey_Eating : MonoBehaviour {

    public GameObject EndEat;
    // public Animator anim;
    // Use this for initialization
    void Start () {
        // anim = transform.GetComponent<Animator>();
    //   EndEat.SetActive(false);
       // anim = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 1000;
        Debug.DrawRay(transform.position, forward, Color.green);
        if (Physics.Raycast(transform.position, forward, out hit))
        {
            Debug.Log("hit");
         //   EndEat.SetActive(true);
          //  anim.SetBool("IsNormal", true);
        }

    }

  
}
