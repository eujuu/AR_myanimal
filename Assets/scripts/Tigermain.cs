using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tigermain : MonoBehaviour{
    public GameObject Animal;
    public float range = 10.0f;
    private Vector3 mousePos;
    float speed = 10.0f;
    // Use this for initialization
    Animator ani;
    float distance = 10;
    public Vector3 m_curPos;
    public Vector3 m_prevPos;
    
   // public PlayPref varyy;
    void Start()
    {
        ani = transform.GetComponentInChildren<Animator>();
        Animal.transform.position = new Vector3((float)1090+ Random.Range(-range, range), (float)540+Random.Range(-range, range),0);
        Animal.transform.localScale = new Vector3(80, 80, 80);
     //   Animal.transform.Rotate(0, 180, 0);
        Animal.SetActive(true);
        
    }
    void OnGUI()
    {
        GUIStyle gui_style = new GUIStyle();
        gui_style.fontSize = 32;
      //  gui_style.normal.textColor = Color.magenta;
        GUI.Label(new Rect(230, 90, 200, 200), PlayPref.name, gui_style);

        GUI.Label(new Rect(480, 90, 200, 200), PlayPref.sex, gui_style);
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    m_prevPos = m_curPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //}
        // while (Input.GetMouseButton(0))
        //{
        //    mousePos = Camera.main.ScreenToWorldPoint(new Vector3( Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        //    // Animal.transform.position = Vector3.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
        //   // Animal.transform.position = new Vector3((mousePos - m_curPos).Normalize);
        //    Debug.Log("x: " + transform.position);


        //}
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDown();
        }
        if (Input.GetMouseButton(0))
        {
            OnMouseDrag();
        }


    }
  
    void OnMouseDown()
    {

        m_curPos = Camera.main.WorldToScreenPoint(Animal.transform.position);
        m_prevPos = Animal.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, m_curPos.z));
    }
    void OnMouseDrag()
    {
    
        Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, m_curPos.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + m_prevPos;
        Animal.transform.position = new Vector3(cursorPosition.x, cursorPosition.y,cursorPosition.z);
    }
 }

