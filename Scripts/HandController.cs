using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField]
    private List<CardController> hand = new List<CardController>();//will be initialized in editor
    private List<Card> cardsAtHand = new List<Card>();
    bool cardAssigned = false;
    public void AssignCards(Card[] cards){
        for(int i = 0; i<cards.Length;i++){
            cardsAtHand.Add(cards[i]);
        }
        cardAssigned = true;
    }
    public void cardDropped(CardController c){
        Debug.Log("CardDropped");
        cardsAtHand.Add(c.getCard());
        cardAssigned = true;
        c.setCardDropped(false);
        
    }
    void Update()
    {
        if(cardAssigned){
            int j = cardsAtHand.Count-1;
            for(int i = hand.Count-1; i>=0; i--){
                hand[i].setCard(cardsAtHand[j]);
                j--;
            }
            cardAssigned = false;
        }
    }

}
