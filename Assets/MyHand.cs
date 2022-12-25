using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MyHand : MonoBehaviour, IDropHandler
{
    public GameObject firstParent;
    int maxCard = 4;
    public void OnDrop(PointerEventData eventData)
    {
        print(eventData.pointerDrag.name + "OnDrag Zone: " + gameObject.name);

        
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d.original_parent == this.gameObject.transform.parent)
        {

             
        }
        
        //d.original_parent = this.transform;


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
