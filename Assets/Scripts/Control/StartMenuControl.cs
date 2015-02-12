using UnityEngine;
using System.Collections;

public class StartMenuControl : MonoBehaviour {
    public void LoadLevel(bool load)
    {
        if (PlayerPrefs.HasKey("Load Game")) PlayerPrefs.SetInt("Load Game", load? 1 : 0);
       Application.LoadLevel(1);
    }

}
