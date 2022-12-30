using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public bool isPlayerTurn = true;

    public TextMeshProUGUI playerGold;

    public void EndPlayerTurn()
    {
        if (isPlayerTurn) { isPlayerTurn = false; }
        else { return; }
        playerGold.text = (int.Parse(playerGold.text) + 4 ).ToString();
    }
    public void EndEnemyTurn()
    {
        if (isPlayerTurn) { return; }
        else { isPlayerTurn = true; }
        //playerGold.text = (int.Parse(playerGold.text) + 4).ToString();
    }

    public void Attack(Interactive attacker)
    {
        if (int.Parse(playerGold.text) < int.Parse(attacker.cost.text)) 
        {
            //TODO : Saldırmak için yeterli cephane yok uyarısı
            return;
        }
        playerGold.text = (int.Parse(playerGold.text) - int.Parse(attacker.cost.text)).ToString();
    }


    public void PlayCard(Interactive playedCard)
    {
        if (isPlayerTurn && !playedCard.isPlayed)
        {
            //Kartın ücretinin oynamasına engel olup olmadığını kontrol eder

            {
                if (int.Parse(playerGold.text) < int.Parse(playedCard.cost.text))
                {
                    //TODO : Hareket etmek için yeterli cephane yok uyarısı
                    return;
                }
                playedCard.isPlayed= true;
                playerGold.text = (int.Parse(playerGold.text) - int.Parse(playedCard.cost.text)).ToString();
            }
        }
    }

    private void Start()
    {
        
    }
}
