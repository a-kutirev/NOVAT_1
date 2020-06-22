using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollbarHandleSize : MonoBehaviour
{

    public Scrollbar scrollbar;
    public float size = 150f;

    // Start is called before the first frame update
    public void Start()
    {
        scrollbar.value = 0f;
        //OnValueChangeSize();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("1");
    }

    public void OnValueChangeSize()
    {
        //gameObject.GetComponent<SceneController>().ResetTimer();
        scrollbar.size = size;
    }
    private void LateUpdate()
    {
        enabled = false;
        OnValueChangeSize();
    }

    public void MoveUp()
    {
        scrollbar.value -= 0.001f;
    }
    public void MoveDown()
    {
        scrollbar.value += 0.001f;
    }
}
