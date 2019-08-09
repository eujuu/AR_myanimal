using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickCharacter : MonoBehaviour {
        public GameObject Tiger;


    public void TigerSetActive()
    {
        Tiger.SetActive(true);

    }

    // Use this for initialization
    void Start()
    {
        Tiger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            //TigerSetActive();
            Debug.Log("버튼이 눌렸습니다.");

        }
    }


}
