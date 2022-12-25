using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnemyLine : MonoBehaviour, IDropHandler
{
    [SerializeField]
    TextMeshProUGUI text;
    public void OnDrop(PointerEventData eventData)
    {
        text.text = "hello";
        


    }

}
