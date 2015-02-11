using UnityEngine;
using System.Collections;

public class FoodManager : MonoBehaviour {

    public string WhoCanEatMeTag = "Pacman";
    public int Scores = 20;

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == WhoCanEatMeTag)
        {
            if (GameManager.ChangeScores != null) GameManager.ChangeScores(Scores);
            gameObject.SetActive(false);
        }
    }
}
