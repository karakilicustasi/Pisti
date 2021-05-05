using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField]
    private List<CardController> hand = new List<CardController>();//will be initialized in editor
    private List<Card> cardsAtHand = new List<Card>(); // recently assigned cards are at last index, and the cards awarded from game loop are at the first index. 
                                                       // so, when the game is over, only the awarded cards will be stored in array
    bool cardAssigned = false;
    bool cardDroppedFromHand = false;
    private int points = 0;

    public int CardsAtHandCount(){
        return cardsAtHand.Count;
    }
    public bool isEmpty(){
        for(int i = 0; i<hand.Count;i++){
            if(hand[i].gameObject.activeSelf){
                return false;
            }
        }
        return true;
    }
    public void AssignCards(Card[] cards){
        for(int i = 0; i<cards.Length;i++){
            cardsAtHand.Add(cards[i]);
        }
        cardAssigned = true;
    }
    public void cardDropped(CardController c){//is card dropped to hand controller
        cardsAtHand.Add(c.getCard());
        cardAssigned = true;
        c.setCardDropped(false);
        
    }
    void Update()
    {
        if(cardAssigned){
            int j = cardsAtHand.Count-1;
            for(int i = hand.Count-1; i>=0; i--){
                if(j<0){
                    break;
                }
                hand[i].setCard(cardsAtHand[j]);
                hand[i].gameObject.SetActive(true);
                j--;
            }
            cardAssigned = false;
        }
    }
    public void RemoveCard(Card c){
        cardsAtHand.Remove(c);
    }
    public void printCards(){
        for(int i = 0; i<cardsAtHand.Count;i++){
            Debug.Log(cardsAtHand[i].getValue());
        }
    }
    public List<CardController> getHand(){
        return hand;
    }
    public List<Card> getCardList(){
        return cardsAtHand;
    }

    public void IncreasePoint(int points){
        this.points+=points;
    }
    public void AddAwardedCards(List<Card> awardedCards){
        PistiDetection(awardedCards);//check for pisti
        for(int i = 0; i<awardedCards.Count;i++){
            cardsAtHand.Insert(0,awardedCards[i]);//cards are inserted to the begining of list
        }
    }
    public void ClearCardsAtHand(){
        cardsAtHand.Clear();
    }
    public void PistiDetection(List<Card> cards){
        if(cards.Count==2){
            IncreasePoint(10);
        }
    }
    public int GetPoint(){
        return points;
    }


}
