using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnterNameForHighScore : MonoBehaviour {
    InputField inputField;
    Text playerName;

	void Start () {
        inputField = GetComponent<InputField>();
        playerName = inputField.textComponent;
	}

    public void SaveName()
    {
        var s2 = string.Format("hs{0}_name", 0);
        if(!string.IsNullOrEmpty(playerName.text))  PlayerPrefs.SetString(s2, playerName.text);
        Application.LoadLevel(3); // Список рекордов
    }
}
