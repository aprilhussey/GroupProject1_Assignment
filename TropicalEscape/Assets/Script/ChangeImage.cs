using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Sprite newButtonImage;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Change 'PLAY' button sprite when clicked.
    public void ChangeButtonImage()
    {
        button.image.sprite = newButtonImage;
    }
}
