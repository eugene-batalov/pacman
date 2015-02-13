using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HighScores : MonoBehaviour {
    public static HighScores Instance;
    public int MaxMembers = 1000;

    List<KeyValuePair<int, string>> _highScores;

    public List<KeyValuePair<int, string>> HighScoresList
    {
        get { return _highScores; }
        set { _highScores = value; }
    }

    void Awake()
    {
        Instance = this;
        HighScoresList = new List<KeyValuePair<int, string>>();
        Read();
    }

    void OnDestroy()
    {
        Instance = null;
    }

	void Start () 
    {
        Write();
	}

    void Read()
    {
        var s1 = string.Format("hs{0}_score", 0); 
        var s2 = string.Format("hs{0}_name", 0);
        if (PlayerPrefs.HasKey(s2)) // если есть новая запись с именем - под номером 0 (пишется при заполнении имени и нажатии кнопки ОК в экране High Scorer), импортируем и удаляем ключ
        {
            HighScoresList.Add(new KeyValuePair<int, string>(PlayerPrefs.GetInt(s1), PlayerPrefs.GetString(s2)));
            PlayerPrefs.DeleteKey(s1);
            PlayerPrefs.DeleteKey(s2);
        }
        for (var i = 1; i <= MaxMembers; i++)
        {
            s1 = string.Format("hs{0}_score", i);
            s2 = string.Format("hs{0}_name", i);
            if (PlayerPrefs.HasKey(s1)) HighScoresList.Add(new KeyValuePair<int, string>(PlayerPrefs.GetInt(s1), PlayerPrefs.GetString(s2)));
            else break;
        }
        HighScoresList.Sort((a,b) => b.Key - a.Key);
    }
    void Write()
    {
        var i = 1;
        foreach(var highScore in HighScoresList)
        {
            if (i > MaxMembers) break;
            var s1 = string.Format("hs{0}_score", i);
            var s2 = string.Format("hs{0}_name", i);
            PlayerPrefs.SetInt(s1, highScore.Key);
            PlayerPrefs.SetString(s2, highScore.Value);
            i++;
        }
    }
}
