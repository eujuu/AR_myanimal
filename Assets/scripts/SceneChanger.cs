using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour {
    public string scene_name;
    public void ChangeGameScene()
    {
        SceneManager.LoadScene(scene_name);
    }
}
