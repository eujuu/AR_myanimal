/* using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
   public Transform target;
   Camera cam;

   void Start()
   {
       cam = GetComponent<Camera>();
   }

   void Update()
   {
     Vector3 screenPos = cam.WorldToScreenPoint(target.position);
       Debug.Log("target is " + screenPos.x + " pixels from the left");
   }

    if(Input.GetMouseButton (0))  // 마우스가 클릭 되면
       {
           Vector3 mos = Input.mousePosition;
       mos.z = camera.farClipPlane; // 카메라가 보는 방향과, 시야를 가져온다.

           Vector3 dir = camera.ScreenToWorldPoint(mos);
   // 월드의 좌표를 클릭했을 때 화면에 자신이 보고있는 화면에 맞춰 좌표를 바꿔준다.

   RaycastHit hit;
           if(Physics.Raycast(transform.position, dir,out hit,mos.z))
           {
               target.position = hit.point; // 타겟을 레이캐스트가 충돌된 곳으로 옮긴다.
           }
       }
   }

}*/

using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{

    public CharacterController cc;
    public GameObject obj;

    public float moveSpeed = 5f;
    public float turnSpeed = 540f;

    int clickLayer = 8;
    int blockLayer = 9;

    bool isMoveState = false;

    Vector3 hitPosition;

    void Awake()
    {
        cc = GetComponent<CharacterController > ();
        obj = GetComponent<GameObject>();
    }


    // Update is called once per frame
    void Update()
    {

        if (isMoveState)
        {
            //Vector3 targetPos = transform.position + hitPosition;

            Vector3 dir = hitPosition - transform.position;
            Vector3 dirXZ = new Vector3(dir.x, 0f, dir.z);

            //Vector3 targetPos = transform.position + (hitPosition - transform.position);
            Vector3 targetPos = transform.position + dirXZ;

            Vector3 framePos = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            Vector3 moveDir = (framePos - transform.position) + Physics.gravity;

            cc.Move(moveDir);

            float fMove = Time.deltaTime * 5;
            transform.Translate(moveDir * fMove);
            
            Debug.Log("framePos : " + framePos + " targetPos : " + targetPos);
            if (framePos == targetPos)
            {
                isMoveState = false;
                Debug.Log("Stop");
            }
        }
        else
        {

        }

        if (Input.GetMouseButtonUp(0)||Input.GetMouseButton(0)||Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 100f))
            {
                //      Debug.Log("hit point : " + hitInfo.point);

                int l = hitInfo.transform.gameObject.layer;

                if (l == clickLayer)
                {
                    //Debug.Log(" hit object : " + hitInfo.collider.name);
                    hitPosition = hitInfo.point;
                    isMoveState = true;
                }

            }
        }

    }
}