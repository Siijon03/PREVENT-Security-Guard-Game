using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourBlindSprites : MonoBehaviour
{
    public Sprite protanopiaImage;
    private Image protan_Img;

    public Sprite deuteranopiaImage;
    private Image deutano_Img;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("ToggleBool2") == 1)
        {
            protan_Img = GetComponent<Image>();
            protan_Img.sprite = protanopiaImage;
        }
        if (PlayerPrefs.GetInt("ToggleBool3") == 1)
        {
            deutano_Img = GetComponent<Image>();
            deutano_Img.sprite = deuteranopiaImage;
        }
    }
}
