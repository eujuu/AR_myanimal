using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public GameObject Tiger;
    public GameObject content;


    public void TigerSetActive()
    {
        Tiger.SetActive(!Tiger.active);
        content.SetActive(!content.active);
    }

    // Use this for initialization
    void Start()
    {
        Tiger.SetActive(false);
        content.SetActive(false);
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
