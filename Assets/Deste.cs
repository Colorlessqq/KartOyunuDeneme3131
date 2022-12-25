using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deste : MonoBehaviour
{
    [SerializeField]
    public GameObject[] myDeck;
    [SerializeField]
    private GameObject spawnLine;  

    public void ReturnCardToHand()
    {
        int x = Random.Range(0, 3);
        GameObject newCard = Instantiate(myDeck[x]);
        newCard.tag = "Player";
        newCard.transform.SetParent(spawnLine.transform);

    }
    public void ReturnCardToEnemeyHand()
    {
        int x = Random.Range(0, 3);
        GameObject newCard = Instantiate(myDeck[x]);
        newCard.transform.SetParent(spawnLine.transform);
        newCard.tag = "Enemy";

    }

}
