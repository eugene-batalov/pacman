using UnityEngine;
using System.Collections;

public class VirtualJoystick : MonoBehaviour {
    private Vector2 movement = Vector2.zero;
    private Vector2 prevMovement = Vector2.zero;

    private Vector2 padBackgroundPosition = Vector2.zero;
    private Vector2 padControllerPosition = Vector2.zero;
    private const float padRadius = 50.0f;

    public void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.touches[0];
            Vector2 touchPosition = new Vector2(touch.position.x, Screen.height - touch.position.y);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    this.padBackgroundPosition = touchPosition;
                    this.padControllerPosition = touchPosition;
                    break;

                case TouchPhase.Moved:
                    this.padControllerPosition = touchPosition;
                    float padsDistance = Vector2.Distance(this.padBackgroundPosition, this.padControllerPosition);
                    if (padsDistance > padRadius)
                    {
                        float t = padRadius / padsDistance;
                        this.padBackgroundPosition = Vector2.Lerp(this.padControllerPosition, this.padBackgroundPosition, t);
                    }
                    break;

                case TouchPhase.Stationary:
                    break;

                case TouchPhase.Canceled:
                    this.padBackgroundPosition = this.padControllerPosition;
                    break;

                case TouchPhase.Ended:
                    this.padBackgroundPosition = this.padControllerPosition;
                    break;
            }
        }

        Vector2 direction = (this.padControllerPosition - this.padBackgroundPosition);
        float distance = Vector2.Distance(this.padControllerPosition, this.padBackgroundPosition);

        if (padRadius / distance > 3.5f) this.movement = Vector2.zero;
        else
        {
            this.movement = direction.normalized;
            if (padRadius / distance > 1.5f) this.movement /= 2.0f;
        }

        if ((prevMovement - movement).sqrMagnitude > 0.05f && ((this.padControllerPosition.x * 2) < Screen.width))
        {
            if (movement.x > 0.3f) SendMessage("SetDirection", Vector2.right);
            if (movement.x < -0.3f) SendMessage("SetDirection", -Vector2.right);
            if (movement.y > 0.3f) SendMessage("SetDirection", -Vector2.up);
            if (movement.y < -0.3f) SendMessage("SetDirection", Vector2.up);
            prevMovement = movement;
        }
    }
}
