using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowLifes : MonoBehaviour {
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        if (text == null) Debug.LogError("need Text Component!");
        else GameManager.ShowLifes += SetText;
    }

    private void SetText(int lifes)
    {
        if (text != null) text.text = string.Format("Lifes: {0}", lifes);
    }

    void OnDestroy()
    {
        GameManager.ShowLifes -= SetText;
    }
}
