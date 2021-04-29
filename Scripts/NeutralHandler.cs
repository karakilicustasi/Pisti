using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralHandler : MonoBehaviour
{
    [SerializeField] 
    CardController openCard;
    [SerializeField] 
    List<CardController> cardLot;

    public void AssignLot(Card[] cards){
        for(int i = 0; i<cards.Length;i++){
            //cardLot.Add(cards[i]);
        }
        openCard = cardLot[0];
    }
}
