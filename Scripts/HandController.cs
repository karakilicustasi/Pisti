using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField]
    private CardController[] hand = new CardController[4];//will be initialized in editor
    public void AssignCards(Card[] cards){
        for(int i = 0; i<cards.Length;i++){
            hand[i].setCard(cards[i]);
        }
    }
}
