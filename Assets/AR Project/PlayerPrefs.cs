using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefs : MonoBehaviour {
    
    //protected string animalName;
   // protected string sex;

    
    public void SetNickname(InputField nickname)
    {
        Debug.Log("입력하신 이름은 " + nickname.text + "입니다.");
        PlayPref.name = nickname.text;
    }

    public void WomanChecked()
    {
        Debug.Log("암컷을 선택하셨습니다.");
        PlayPref.sex = "암컷";
    }
    public void ManChecked()
    {
        Debug.Log("수컷을 선택하셨습니다.");
        PlayPref.sex = "수컷";
    }

    void Start()
    {

    }
    void Update()
    {
    }
}
