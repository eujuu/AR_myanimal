using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Feeding : MonoBehaviour
{    
    public Slider trainBarSlider;  
    public GameObject trainOverButton;
    private bool isTrainOver = false;
    public Animator animator;
    private GameObject go;
    void Start()
    {
        trainBarSlider.value = 0;
        animator.SetBool("RunBool", false);
        animator.SetBool("SoundBool", false);
        animator.SetBool("WalkBool", false);
        animator.SetBool("HitBool", false);
        
        trainOverButton.SetActive(false);

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTrainOver)
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 10f, 0, 0);
    }

    public void RunButtonDown()
    {
        animator.SetBool("HitBool", false);
        animator.SetBool("SoundBool", false);
        animator.SetBool("WalkBool", false);
        animator.SetBool("RunBool", true);
        Debug.Log("달리기 버튼이 눌렸습니다.");
        if (trainBarSlider.value < 0.9)
        {
            trainBarSlider.value += .11f;
        }
        else
        {
            trainOverButton.SetActive(true);
        }
    }

    public void HitButtonDown()
    {
        animator.SetBool("WalkBool", false);
        animator.SetBool("RunBool", false);
        animator.SetBool("SoundBool", false);
        animator.SetBool("HitBool", true);

        Debug.Log("때리기 버튼이 눌렸습니다.");
        if (trainBarSlider.value < 0.9)
        {
            trainBarSlider.value += .11f; 
        }
        else
        {
            trainOverButton.SetActive(true);
        }
    }

    public void  SoundButtonDown()
    {
        animator.SetBool("HitBool", false);
        animator.SetBool("WalkBool", false);
        animator.SetBool("RunBool", false);
        animator.SetBool("SoundBool", true);
        Debug.Log("포효하기 버튼이 눌렸습니다.");
        if (trainBarSlider.value < 0.9)
        {
            trainBarSlider.value += .11f;
        }
        else
        {
            trainOverButton.SetActive(true);
        }
    }

    public void WalkButtonDown()
    {
        animator.SetBool("RunBool", false);
        animator.SetBool("HitBool", false);
        animator.SetBool("SoundBool", false);
        animator.SetBool("WalkBool", true);
        Debug.Log("걷기 버튼이 눌렸습니다.");
        if (trainBarSlider.value < 0.9)
        {
            trainBarSlider.value += .11f;
        }
        else
        {
            trainOverButton.SetActive(true);
        }
    }
}