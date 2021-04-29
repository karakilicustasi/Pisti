using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField]
    private CardController[] hand = new CardController[4];//will be initialized in editor

    public bool isEmpty(){
        for(int i = 0; i<hand.Length;i++){
            if(!hand[i].getCard().isPlayed()){
                return false;
            }
        }
        return false;
    }
    public int getHandLength(){
        return hand.Length;//return the length of hand
    }
    public void AssignCards(Card[] cards){
        for(int i = 0; i<cards.Length;i++){
            hand[i].setCard(cards[i]);
        }
    }
}
