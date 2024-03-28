using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Auto_Select : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public GameObject Text;
    [SerializeField] public RawImage Image;


    public void OnPointerEnter(PointerEventData eventData)
    {
        Image.gameObject.SetActive(true);
        Debug.Log("Entered");
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Image.gameObject.SetActive(false);
        Debug.Log("Exited");

    }
}
