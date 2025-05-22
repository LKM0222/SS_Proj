using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IPointerUpHandler, IDragHandler, IPointerDownHandler
{
    [SerializeField] private RectTransform joystick;
    [SerializeField] private RectTransform lever;

    [SerializeField, Range(10f, 150f)] private float leverRange;


    [SerializeField] private Vector2 inputVector;
    [SerializeField] private bool isInput;

    // [SerializeField] PlayerTest player;

    // LifeCycle
    void Update()
    {
        if (isInput)
        {
            InputControlVector();
        }
    }

    // interface
    public void OnPointerDown(PointerEventData eventData)
    {
        joystick.position = eventData.position;
        joystick.gameObject.SetActive(true);
        ContolJoystickLever(eventData);
        isInput = true;
    }
    public void OnDrag(PointerEventData eventData) // 드래그 중
    {
        ContolJoystickLever(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        lever.anchoredPosition = Vector2.zero;
        joystick.gameObject.SetActive(false);
        isInput = false;
    }


    // Method
    public void ContolJoystickLever(PointerEventData eventData)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(joystick, eventData.position, eventData.pressEventCamera, out localPoint);

        Vector2 clamped = Vector2.ClampMagnitude(localPoint, leverRange);
        lever.anchoredPosition = clamped;
        inputVector = clamped / leverRange;
    }

    private void InputControlVector()
    {
        //입력값 전달.
        // Debug.Log(inputVector);
        // player.Move(inputVector);
    }
}