using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Interactive : MonoBehaviour, IDropHandler,IPointerEnterHandler,IPointerExitHandler
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI health;
    [SerializeField] TextMeshProUGUI attack;
    [SerializeField] TextMeshProUGUI cost;
    [SerializeField] Image image;
    public void OnDrop(PointerEventData eventData)
    {
        Interactive dropeed = eventData.pointerDrag.gameObject.GetComponent<Interactive>();
        if (dropeed.tag != this.tag)
        {
            TextMeshProUGUI damage = dropeed.attack;
            health.text = (int.Parse(health.text) - int.Parse(damage.text)).ToString();

            if (int.Parse(health.text) < 1)
            {
                Destroy(this.gameObject);
            }

        }
        else
        {
            print("Aynı taraf");
        }

        
    }

    [System.Obsolete]
    public void OnPointerEnter(PointerEventData eventData)
    {


        try
        {
            if (eventData.pointerDrag.gameObject.tag == this.tag)
            {
                image.color = Color.gray;
            }
            else if (eventData.pointerDrag.gameObject.tag != this.tag)
            {
                image.color = Color.red;
            }
        }
        catch (NullReferenceException)
        {

        }
        
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.white;
    }

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
