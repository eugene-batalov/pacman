using UnityEngine;
using System.Collections;

public class KeyboardControl : MonoBehaviour {

    public KeyCode Up = KeyCode.UpArrow;
    public KeyCode Down = KeyCode.DownArrow;
    public KeyCode Right = KeyCode.RightArrow;
    public KeyCode Left = KeyCode.LeftArrow;
    public KeyCode Pause = KeyCode.Space;

	void Update () {
        if (Input.GetKeyDown(Up)) SendMessage("SetDirection", Vector2.up);
        if (Input.GetKeyDown(Down)) SendMessage("SetDirection", -Vector2.up);
        if (Input.GetKeyDown(Right)) SendMessage("SetDirection", Vector2.right);
        if (Input.GetKeyDown(Left)) SendMessage("SetDirection", -Vector2.right);
        if (Input.GetKeyDown(Pause) && GameManager.Pause != null) GameManager.Pause();
	}
}
