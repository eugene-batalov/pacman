using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{

    public static Action<int> ChangeLifes;
    public static Action Dead;
    public static Action<int> ShowLifes;
    public static Action<int> ChangeScores;
    public static Action<int> ShowScores;
    public static Action GameOver;
    public static Action Pause;
    public static Action<bool> PauseOnOff;

    public static GameManager Instance;

    public int StartLifes = 3;
    public int StartScores = 0;

    int _lifes;

    public int Lifes
    {
        get { return _lifes; }
        set { _lifes = value; }
    }
    int _scores;

    public int Scores
    {
        get { return _scores; }
        set { _scores = value; }
    }
    bool _pause;

    void Awake()
    {
        if (Instance != null) Debug.LogError("Should be only one level manager!");
        Instance = this;
        Lifes = StartLifes;
        Scores = StartScores;
        ChangeLifes += MakeChangeLifes;
        ChangeScores += MAkeChangeScores;
        Pause += TogglePause;
    }

    void OnDestroy()
    {
        ChangeLifes = null;
        Dead = null;
        ShowLifes = null;
        ChangeScores = null;
        ShowScores = null;
        GameOver = null;
        Pause = null;
        PauseOnOff = null;
        Instance = null;
    }
    void Start()
    {
        if (ShowLifes != null) ShowLifes(Lifes);
        if (ShowScores != null) ShowScores(Scores);
    }
    void MakeChangeLifes(int delta)
    {
        Lifes += delta;
        if (ShowLifes != null) ShowLifes(Lifes);
        if (Lifes == 0 && GameOver != null) GameOver();
        else if (Dead != null) Dead();
    }

    void MAkeChangeScores(int delta)
    {
        Scores += delta;
        if (ShowScores != null) ShowScores(Scores);
    }

    void TogglePause()
    {
        _pause = !_pause;
        if (PauseOnOff != null) PauseOnOff(_pause);
    }
}
