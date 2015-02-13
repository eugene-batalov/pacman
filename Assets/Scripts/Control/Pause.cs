using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	public void MakePaused () 
    {
        if(GameManager.Pause != null)  GameManager.Pause();
	}
}
