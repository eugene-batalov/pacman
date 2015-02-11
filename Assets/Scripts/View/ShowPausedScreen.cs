using UnityEngine;
using System.Collections;

public class ShowPausedScreen : MonoBehaviour {

    void Awake()
    {
        GameManager.PauseOnOff += (OnOff) => gameObject.SetActive(OnOff);
        gameObject.SetActive(false);
    }
}
