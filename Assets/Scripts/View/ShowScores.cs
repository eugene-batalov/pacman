using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowScores : MonoBehaviour 
{
    Text text;

	void Awake () 
    {
        text = GetComponent<Text>();
        if (text == null) Debug.LogError("need Text Component!");
        else GameManager.ShowScores += (scores) => text.text = string.Format("Scores: {0}", scores);
	}
}
