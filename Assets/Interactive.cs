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
    [SerializeField] public TextMeshProUGUI cost;
    [SerializeField] TextMeshProUGUI ammunation;
    [SerializeField] Image image;
    [SerializeField] string range;
    public bool isPlayed = false;
    StateManager stateManager;
    public void OnDrop(PointerEventData eventData)
    {

        // Eğer tur senin değilse sonlandır
        if (!stateManager.isPlayerTurn) { return; }

        Interactive dropeed = eventData.pointerDrag.gameObject.GetComponent<Interactive>();
        if (dropeed.tag != this.tag && dropeed.isPlayed && isPlayed)
        {

            TextMeshProUGUI damage = dropeed.attack;
            health.text = (int.Parse(health.text) - int.Parse(damage.text)).ToString();
            stateManager.Attack(dropeed);

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
        // Eğer tur senin değilse sonlandır
        if (!stateManager.isPlayerTurn) { return; }

        try
        {
            if (eventData.pointerDrag.gameObject.tag == this.tag && isPlayed)
            {
                image.color = Color.gray;
            }
            else if (eventData.pointerDrag.gameObject.tag != this.tag && isPlayed)
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
        // Eğer tur senin değilse sonlandır
        if (!stateManager.isPlayerTurn) { return; }
        image.color = Color.white;
    }

    void Start()
    {
        stateManager = FindObjectOfType<StateManager>();
    }


}
