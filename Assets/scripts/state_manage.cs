using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class state_manage : MonoBehaviour {

    // Use this for initialization
    void OnGUI()
    {
        GUIStyle gui_style = new GUIStyle();
        gui_style.fontSize = 30;
        gui_style.fontStyle = FontStyle.Normal;
        gui_style.normal.textColor = Color.black;
        GUI.Box(new Rect(180, 140, 20, 20), "건강: ", gui_style);
        GUI.Box(new Rect(180, 220, 20, 20), "피로: ", gui_style);
        GUI.Box(new Rect(180, 300, 20, 20), "배부름: ", gui_style);
        GUI.Box(new Rect(180, 380, 20, 20), "청결: ", gui_style);
        GUI.Box(new Rect(500, 140, 20, 20), "스트레스: ", gui_style);
        GUI.Box(new Rect(500, 220, 20, 20), "순종: ", gui_style);
        GUI.Box(new Rect(500, 300, 20, 20), "친밀: ", gui_style);
      
    }
}
