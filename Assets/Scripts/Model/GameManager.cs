using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour {

    public static Action <int> ChangeLifes;
    public static Action<int> ShowLifes;
    public static Action<int> ChangeScores;
    public static Action<int> ShowScores;
    public static Action GameOver;
    public static Action Pause;
    public static Action <bool> PauseOnOff;

    public int StartLifes = 3;
    public int StartScores = 0;

    int _lifes;
    int _scores;
    bool _pause;

    void Awake()
    {
        _lifes = StartLifes;
        _scores = StartScores;
        ChangeLifes += MakeChangeLifes;
        ChangeScores += MAkeChangeScores;
        Pause += TogglePause;
    }
    void Start()
    {
        if (ShowLifes != null) ShowLifes(_lifes);
        if (ShowScores != null) ShowScores(_scores);
    }
    void MakeChangeLifes(int delta)
    {
        _lifes += delta;
        if (ShowLifes != null) ShowLifes(_lifes);
        if (_lifes == 0 && GameOver != null) GameOver();
    }
    
    void MAkeChangeScores(int delta)
    {
        _scores += delta;
        if (ShowScores != null) ShowScores(_scores);
    }

    void TogglePause()
    {
        _pause = !_pause;
        if (PauseOnOff != null) PauseOnOff(_pause);
    }
}
