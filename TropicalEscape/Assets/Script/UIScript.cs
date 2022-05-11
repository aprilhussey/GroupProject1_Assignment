using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIScript : MonoBehaviour, IPointerDownHandler
{
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

        }
        else if (eventData.pointerCurrentRaycast.gameObject.name == "RightArrow")
        {

        }
        if (eventData.pointerCurrentRaycast.gameObject.name == "JumpButton")
        {

        }
        else if (eventData.pointerCurrentRaycast.gameObject.name == "DashButton")
        {
            
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