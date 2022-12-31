using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnemyLine : MonoBehaviour, IDropHandler
{
    private int maxCard = 3;
    StateManager stateManager;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.tag != "Enemy") { return; }
        Interactive inter = eventData.pointerDrag.GetComponent<Interactive>();
        DropCardEnemyLine(inter);

    }
    public void DropCardEnemyLine(Interactive inter) 
    {
       
        if (this.gameObject.transform.childCount >= maxCard) { return; }

        //Kartın ücretinin oynamasına engel olup olmadığını kontrol eder
        if (inter.isPlayed == false)
        {
            if (!stateManager.PlayEnemyCard(inter)) { return; }
            inter.isPlayed = true;
        }
        inter.CardLine = 0;
        inter.transform.parent = this.transform;
    }




    private void Start()
    {
        stateManager = FindObjectOfType<StateManager>();
    }
}
