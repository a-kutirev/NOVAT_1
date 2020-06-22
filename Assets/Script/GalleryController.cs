using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GalleryController : MonoBehaviour
{
    public VideoPlayer player;
    public HorizontalLayoutGroup layoutGroup;
    public GameObject ImagePrefab;
    public RectTransform panel;
    public GameObject scrollView;
    public RawImage MainImage;
    public Text text;

    private string[] mainFileList;
    private string[] smallFileList;

    // Start is called before the first frame update
    void Start()
    {
        player.url = Application.streamingAssetsPath + "//Video//GalleryVideo.mp4";

        mainFileList = Directory.GetFiles(Application.streamingAssetsPath + "//Foto_" + Controller.SelectedGallery.ToString() + "//", "*.jpg");
        smallFileList = Directory.GetFiles(Application.streamingAssetsPath + "//Foto_" + Controller.SelectedGallery.ToString() + "//Small//", "*.jpg");

        float width = 0;
        text.text = "";
        player.Play();

        for (int i = 0; i < smallFileList.Length; i++)
        {
            GameObject go = Instantiate(ImagePrefab);
            go.transform.SetParent(panel.transform);
            go.name = i.ToString();
            go.GetComponent<ImageButton>().controller = this;
            Image im = go.GetComponent<Image>();
            SetImage(im, i);

            width += im.overrideSprite.textureRect.width;           
        }

        width += 10 * (smallFileList.Length - 1);

        panel.sizeDelta = new Vector2(width, panel.sizeDelta.y);

        scrollView.GetComponent<ScrollRect>().normalizedPosition = new Vector2(0, 0);        

        ShowImage(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowImage(int index)
    {
        WWW www = new WWW(mainFileList[index]);
        MainImage.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(www.texture.width, www.texture.height);
        //ShadowPanel.sizeDelta = new Vector2(www.texture.width, www.texture.height);
        MainImage.texture = www.texture;
        text.text = Path.GetFileNameWithoutExtension(mainFileList[index]).Split('#')[1];
    }

    private void SetImage(Image im, int index)
    {
        //Converts desired path into byte array
        byte[] pngBytes = System.IO.File.ReadAllBytes(smallFileList[index]);

        //Creates texture and loads byte array data to create image
        Texture2D tex = new Texture2D(1, 1);
        tex.LoadImage(pngBytes);

        //Creates a new Sprite based on the Texture2D
        Sprite fromTex = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);

        //Assigns the UI sprite
        im.sprite = fromTex;
        im.SetNativeSize();
    }
}
