using UnityEngine;
using System.Collections;

public class StartMenuControl : MonoBehaviour {

	void Start () 
    {
	}
	
	void Update () 
    {
	}

    public void LoadLevel()
    {
       Application.LoadLevel(1);
    }

}
