using UnityEngine;
using System.Collections;

public class GoBack : MonoBehaviour {
    public void GoBackButtonPush()
    {
        Application.LoadLevel(0); // начальное меню
    }
}
