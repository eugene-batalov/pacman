using UnityEngine;
using System.Collections;

public class ShowLoadGame : MonoBehaviour 
{
	void Start () 
    {
        if (!PlayerPrefs.HasKey("Load Game")) gameObject.SetActive(false);
	}
}
