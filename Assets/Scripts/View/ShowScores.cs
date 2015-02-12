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
        else GameManager.ShowScores += SetText;
	}

    private void SetText(int scores)
    {
        if (text != null) text.text = string.Format("Scores: {0}", scores);
    }

    void OnDestroy()
    {
        GameManager.ShowLifes -= SetText;
    }
}
