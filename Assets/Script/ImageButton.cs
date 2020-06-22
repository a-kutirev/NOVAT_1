using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.

public class ImageButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GalleryController controller;

    private Vector2 startPos;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (startPos == eventData.position)
            ShowImage();
        else
            startPos = new Vector2(0, 0);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        startPos = eventData.position;
    }

    public void ShowImage()
    {
        controller.ShowImage(int.Parse(gameObject.name));
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
