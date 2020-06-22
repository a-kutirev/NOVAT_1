using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadRibbon()
    {
        SceneManager.LoadScene("Ribbon");
    }

    public void LoadMainScreen()
    {
        SceneManager.LoadScene("MainScreen");
    }

    public void LoadFotogallery()
    {
        SceneManager.LoadScene("FotoMain");
    }

    public void LoadGallery()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        Controller.SelectedGallery = int.Parse(buttonName.Split('#')[1]);
        SceneManager.LoadScene("Gallery");
    }
}
