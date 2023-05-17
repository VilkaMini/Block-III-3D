using UnityEngine;

public class JoyStickController : MonoBehaviour
{
    // Directions
    public float vertical;
    public float horizontal;

    // Joystick objects / required objects
    public RectTransform joystickTransform;
    public RectTransform stick;
    private Vector3 startPos;
    public Camera cam;

    // Variables
    private Touch joystickTouch;

    public bool dragging = false;

    // On Awake check position of stick
    private void Awake()
    {
        startPos = stick.position;
    }

    private void Update()
    {
        // if there is a touch 
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                Vector2 touchPosition = touch.position;
                Vector2 localPoint;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickTransform, touchPosition, null, out localPoint);

                // Check if touch in joystick rectangle
                if (joystickTransform.rect.Contains(localPoint))
                {
                    joystickTouch = touch;
                    dragging = true;
                    stick.position = touchPosition;
                    CalculateNormalizedDirection();
                }
                else{dragging = false;}
            }
        }
        // If the touch exists
        if (dragging)
        {
            Vector2 touchPosition = joystickTouch.position;

            if (joystickTouch.phase == TouchPhase.Moved)
            {
                stick.position = touchPosition;
                CalculateNormalizedDirection();
                
            }
            if (joystickTouch.phase == TouchPhase.Ended)
            {
                dragging = false;
                stick.position = startPos;
            }
        }
        else
        {
            stick.position = startPos;
            vertical = 0.0f;
            horizontal = 0.0f;
        }
    }

    private void CalculateNormalizedDirection()
    {
        var heading = stick.position - startPos;
        vertical = (heading / heading.magnitude).y;
        horizontal = (heading / heading.magnitude).x;
    }
}
