using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private Deck deck;

    
    [SerializeField]
    HandController playerHand; //hand controller for player
    
    [SerializeField]
    HandController opponentHand; //hand controller for opponent
    
    [SerializeField]
    HandController neutral; //drop area
    [SerializeField]
    DropZone drop; //drop functions and collider controls

    bool gameOver = false;//sets true when game is over
    
    void Start()
    {
        deck = new Deck();//initialize the deck
        DealHand(neutral,"neutral");//deal hands
        DealHand(playerHand,"player");
        DealHand(opponentHand,"opponent");
        PrintDeckCount();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(drop.getTurn()<48){//if its the first turn or if its the end of the first session
            if(opponentHand.isEmpty()&&playerHand.isEmpty()){
                DealHand(playerHand, "player");
                DealHand(opponentHand, "opponent");
            }
            if(drop.getTurn()%2==0){//player turn
                
            }
            else{//computer turn
                Debug.Log("Opponent");
                ComputerMove();
                
            }
            
        }
        else{//game over
            if(!gameOver){
                AssignPoints(playerHand);//assign the points
                AssignPoints(opponentHand);
                gameOver = true;
            }
        }
    }
    public void DealHand(HandController hand,string hand_){
        Card[] cards;
        cards = deck.DealCards(hand_);//deal the cards
        hand.AssignCards(cards);//assign the cards to hand
    }
    private void PrintDeckCount(){
        Debug.Log(deck.getDeckCount());
    }
    private void EndGameCalculation(){
        
    }
    private void AssignPoints(HandController hand){
        for(int i = 0; i<hand.getCardList().Count;i++){
            if(hand.getCardList()[i].getValue()==0){
                hand.IncreasePoint(1);
            }
            else if(hand.getCardList()[i].getValue()==1&&hand.getCardList()[i].getType()==3){//2 spades
                hand.IncreasePoint(2);
            }
            else if(hand.getCardList()[i].getValue()==9&&hand.getCardList()[i].getType()==2){//10 diamond
                hand.IncreasePoint(3);
            }
            else if(hand.getCardList()[i].getValue()==10){
                hand.IncreasePoint(1);
            }
        }
    }
    private void ComputerMove(){
        List<CardController> computerCards = opponentHand.getHand();
        List<CardController> cardOnTable = neutral.getHand();
        bool found = false;
        int random = 0;
        
        if(neutral.getHand()[0].gameObject.activeSelf){//if there is a card in mid table
            for(int i = 0; i<computerCards.Count;i++){
                if((computerCards[i].gameObject.activeSelf)&&(computerCards[i].getCard().getValue() == cardOnTable[0].getCard().getValue()||computerCards[i].getCard().getValue()==10)){
                    drop.ComputerDrop(opponentHand,computerCards[i]);
                    opponentHand.AddAwardedCards(neutral.getCardList());
                    neutral.ClearCardsAtHand();
                    cardOnTable[0].gameObject.SetActive(false);
                    found = true;
                    break;
                }
            }
            if(!found){//if there is not an identical card on table, put a card down randomly
                random = Random.Range(0,4);
                if(computerCards[random].gameObject.activeSelf){
                    drop.ComputerDrop(opponentHand,computerCards[random]);
                    //found = true;
                }    
            }
        }
        else{//if there isnt a card on table
            for(int i = 0;i<computerCards.Count;i++){
                if(computerCards[i].gameObject.activeSelf){
                    drop.ComputerDrop(opponentHand,computerCards[i]);
                    neutral.getHand()[0].gameObject.SetActive(true);
                    break;
                }
            }
        }
    }
}
