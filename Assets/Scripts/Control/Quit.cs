using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour {

	public void QuitApp () 
    {
        LevelManager.Instance.Save();
        Application.Quit();
	}

}
