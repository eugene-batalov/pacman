using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ContentScroller : MonoBehaviour {
    public string HighScoresSlotTag = "HighScoreSlot";
    RectTransform _rt;

    Vector2 _startPosition; // Для отсечки свободной прокрутки на наограниченное расстояние
    Vector2 _endPosition;

    public GameObject prefab; // префаб слота записи о рекордах

    GameObject[] slots;

	void Start () 
    {
        _rt = GetComponent<RectTransform>();
        _startPosition = _rt.position;

        var slotsGameObject = GameObject.FindGameObjectWithTag(HighScoresSlotTag);
        Rect sample_size = slotsGameObject.GetComponent<RectTransform>().rect;
        slots = new GameObject[HighScores.Instance.HighScoresList.Count];
        slots[0] = slotsGameObject;

        _endPosition = new Vector2(_startPosition.x, _startPosition.y + Mathf.Max(0, sample_size.height * HighScores.Instance.HighScoresList.Count - _rt.rect.height)); // органичить прокрутку ниже последнего

        for (var i = 1; i < HighScores.Instance.HighScoresList.Count; i++)
        {
            slots[i] = (GameObject)Instantiate(prefab);
            slots[i].transform.SetParent(transform);
            slots[i].transform.localScale = Vector3.one;
            slots[i].transform.GetComponent<RectTransform>().rect.Set(0, 0, sample_size.width, sample_size.height);
            slots[i].transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -(i+1) * sample_size.height);
        }
        for (var i = 0; i < HighScores.Instance.HighScoresList.Count; i++)
        { 
            foreach(var text in slots[i].GetComponentsInChildren<Text>())
            {
                if(text.name == "Number") text.text = string.Format("{0}.", i+1);
                if (text.name == "Name") text.text = string.Format("{0}", HighScores.Instance.HighScoresList[i].Value);
                if (text.name == "Score") text.text = string.Format("{0}", HighScores.Instance.HighScoresList[i].Key);
            }
        }
	}
	
	void Update () 
    {
        if (_rt.anchoredPosition.y < 0) _rt.position = _startPosition; // органичить прокрутку в начале списка
        if (_rt.anchoredPosition.y > _endPosition.y) _rt.position = _endPosition; // в конце списка
	}
}
