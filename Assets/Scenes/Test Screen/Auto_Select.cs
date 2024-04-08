using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Auto_Select : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public GameObject Text;
    [SerializeField] public RawImage Image;
    [SerializeField] public RawImage ReminderSheet_Image;


    void Start()
    {
        Image.gameObject.SetActive(false);
        ReminderSheet_Image.gameObject.SetActive(false);

        if (Image == null)
        {
            Debug.Log("Image was not assigned to object.");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Image.gameObject.SetActive(true);
        Image.gameObject.SetActive(true);

        Debug.Log("Entered");
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Image.gameObject.SetActive(false);
        Image.gameObject.SetActive(false);
        Debug.Log("Exited");

    }
}
