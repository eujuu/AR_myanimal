//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using Vuforia;
//public class mainscreen : MonoBehaviour {
//    public GameObject Tiger;
//    private Vector3 currPosition;
//    private Vector3 Tigerpos;
//    public Transform startMaker;
//    public Transform endMaker;

//    private int waypointIndex = 0;
//    private float speed = 200f;
//    public Transform target;
//    public Slider exp;
//    public float currentSpeed = 0;
//    public float acceleration = 4f;
//    public float step;
//    public float startTime;
//    public float length;

//    private float relativeHeigh = 1.0f;
//    private float zDistance = -1.0f;
//    private float xDistance = 1.0f;
//    public float dampSpeed = 2;
//    void Start()
//    {
//        startTime = Time.time;

//     //   step = speed * Time.deltaTime;

//    }

//    void Update()
//    {
////     if (target.is_detected_)
//    //    {
//         //   Vector3 newPos = target.position + new V
//            currPosition = target.transform.localPosition;
//            currPosition.z = 0;

//                Debug.Log("tracking...");
//                Debug.Log(Tiger.transform.position);
//                length = Vector3.Distance(Tiger.transform.localPosition, currPosition);
//                Tigerpos = Tiger.transform.localPosition;
//                step += (1.05f - step) * 4 * Time.deltaTime;
//              //  step = (Time.time - startTime) * speed;
//              //  float journey = 10 * step / length;
//                //   step += Time.deltaTime * speed;
//                Tiger.transform.position = Vector3.Lerp(Tigerpos, currPosition, step);

//    //    }

//    }

//    //private IEnumerator MyCoroutine(TrackingObject target)
//    //{
//    //    float step = speed * Time.deltaTime;
//    //    while (Vector3.Distance(Tiger.transform.position, target.position), 0.05f)){
//    //        Tiger.transform.position = Vector3.Lerp(Tiger.transform.position, target.transform.position, step);
//    //        yield return null;
//    //    }
//    //    yield return new WaitForSeconds(3f);
//    //}
//    void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.tag == "rice")
//        {
//            Destroy(other.gameObject);
//            Debug.Log("tiger");
//        }
//    }
//}


using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class mainscreen : MonoBehaviour
{
    Animator anim;
    public TrackingObject is_target;
    public Transform target; // 따라갈 타겟의 트랜스 폼
  //  public GameObject Tiger;
    private float relativeHeigth = 1.0f; // 높이 즉 y값
    private float zDistance = -1.0f;// z값 나는 사실 필요 없었다.
    private float xDistance = 1.0f; // x값
    public float dampSpeed = 1;  // 따라가는 속도 짧으면 타겟과 같이 움직인다.
    public float length;
    public Vector3 origin;
    public GUIStyle gui_style;
    public bool isit = false;
    public string scene_name;
    public GameObject EndEat;
    int x = 80, y = 80, z = 80;
    void Start()
    {
        
        EndEat.SetActive(!EndEat.active);
        anim = transform.GetComponent<Animator>();
        anim.SetBool("IsNormal", true);
      
        origin = transform.position;


    }
    void OnGUI()
    {
        gui_style.fontSize = 100;
        gui_style.normal.textColor = Color.blue;

          
    }
    void Update()
    {
        
        if (is_target.is_detected_)
        {
            anim.SetBool("IsNormal", false);
            RaycastHit hit;
            Vector3 forward = transform.TransformDirection(Vector3.up) * 1000;
            Vector3 backward = transform.TransformDirection(Vector3.down) * 1000;
            Debug.DrawRay(transform.position, forward, Color.green);
            Debug.DrawRay(transform.position, backward, Color.blue);

    
            var targetRotation = Quaternion.LookRotation(target.position-transform.position  , Vector3.up);
            var forceRot = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * dampSpeed);

            transform.rotation = forceRot;
        
            float pos = transform.position.x * (float)0.03;
            transform.localScale = new Vector3(pos, pos, pos);
        
            transform.Translate(transform.forward * 2, Space.World);
            if (Physics.Raycast(transform.position, forward, out hit) || Physics.Raycast(transform.position, backward, out hit))
            {
                Debug.Log("rayhit");
           
                EndEat.SetActive(true);
               
                anim.SetBool("IsNormal", true);
                transform.localPosition = new Vector3(origin.x, origin.y, origin.z);
                transform.Rotate(0, 180, 0);
                
            }
           
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "rice")
        {
            Debug.Log("tiger");
           // Destroy(other.gameObject);
            transform.Rotate(0, 180, 0);
            
        }
    }
    //public void EndEatSetActive()
    //{
    //    EndEat.SetActive(!EndEat.active);
    //}
    public void ChangeGameScene()
    {
        SceneManager.LoadScene(scene_name);
    }



}


