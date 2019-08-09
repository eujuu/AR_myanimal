using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class trackingBall : MonoBehaviour
{
    public Transform target;
    public Slider timeBarSlider;
    public GameObject playOverButton;
    private bool isPlayOver = false;
    
    private float relativeHeigth = 3.0f;
    private float zDistance = -1.0f;
    private float xDistance = 0.0f;
    public float dampSpeed = 5;

    Vector3 previousPos, newPos;

    void Start()
    {
        timeBarSlider.value = 1;
        playOverButton.SetActive(false);
    }

    void Update()
    {
        newPos = target.position + new Vector3(xDistance, relativeHeigth, -zDistance);
        if (!isPlayOver && previousPos != newPos)
        {
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 10f, 0, 0);
            if (timeBarSlider.value > 0)
                timeBarSlider.value -= 0.0033f;
            else
            { 
                isPlayOver = true;
                playOverButton.SetActive(true);
                }
        }
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * dampSpeed);
        previousPos = newPos;
    }
}