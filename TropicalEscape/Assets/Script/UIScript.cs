using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool leftArrow = false;
    public bool rightArrow = false;
    public bool jumpButton = false;
    public bool dashButton = false;
    // Start is called before the first frame update
    private void Start()
    {
        AddPhysics2DRaycaster();
    }

    // Update is called once per frame
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        if (eventData.pointerCurrentRaycast.gameObject.name == "LeftArrow")
        {
            leftArrow = true;
        }
        else if (eventData.pointerCurrentRaycast.gameObject.name == "RightArrow")
        {
            rightArrow = true;
        }

        if (eventData.pointerCurrentRaycast.gameObject.name == "JumpButton")
        {
            jumpButton = true;
        }
        else if (eventData.pointerCurrentRaycast.gameObject.name == "DashButton")
        {
            dashButton = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Released: " + eventData.pointerCurrentRaycast.gameObject.name);
        switch (eventData.pointerCurrentRaycast.gameObject.name)
        {
            case "LeftArrow":
                leftArrow = false;
                break;
            case "RightArrow":
                rightArrow = false;
                break;
            case "JumpButton":
                jumpButton = false;
                break;
            case "DashButton":
                dashButton = false;
                break;
        }
    }

    private void AddPhysics2DRaycaster()
    {
        Physics2DRaycaster raycaster = FindObjectOfType<Physics2DRaycaster>();
        if (raycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }
}