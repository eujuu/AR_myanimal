using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {
    public string scene_name;
    static string name;
    public void ChangeGameScene()
    {

        
        SceneManager.LoadScene(scene_name);

    }
    // Use this for initialization
    void Start () {
        name = "아롱";
	//	PlayerPrefs.SetString("name", name);
      //  PlayerPrefs.
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
