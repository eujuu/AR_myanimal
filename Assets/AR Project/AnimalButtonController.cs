using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalButtonController : MonoBehaviour
{

    public GameObject Tiger;
    public GameObject Bear;
    public GameObject TigerContent;
    public GameObject BearContent;

    public void BearSetActive()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {
            if (Bear.active == true)
            {
                Bear.SetActive(false);
                BearContent.SetActive(false);
            }
            else if (Bear.active == false)
            {
                Bear.SetActive(true);
                BearContent.SetActive(true);
            }
            Tiger.SetActive(false);
            TigerContent.SetActive(false);
            Debug.Log("곰 버튼이 눌렸습니다.");
        }
    }

    public void TigerSetActive()
    {
        Bear.SetActive(false);
        BearContent.SetActive(false);
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {
            if (Tiger.active == true)
            {
                Tiger.SetActive(false);
                TigerContent.SetActive(false);

            }
            else if (Tiger.active == false)
            {
                Tiger.SetActive(true);
                TigerContent.SetActive(true);
            }
            Bear.SetActive(false);
            BearContent.SetActive(false);
            Debug.Log("호랑이 버튼이 눌렸습니다.");
        }
    }

    // Use this for initialization
    void Start()
    {
        Tiger.SetActive(false);
        Bear.SetActive(false);
        BearContent.SetActive(false);
        TigerContent.SetActive(false);
    } 

    // Update is called once per frame
    void Update()
    {
    }
}
