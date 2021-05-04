using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private Deck deck;
    //deck
    //card array of card controllers for user and oppenent
    //instantiate those cards from the editor
    //try to manipulate them through this class 
    
    [SerializeField]
    HandController playerHand;
    
    [SerializeField]
    HandController enemyHand;
    
    [SerializeField]
    HandController neutral;
    [SerializeField]
    DropZone drop;
    
    void Start()
    {
        deck = new Deck();
        DealHand(neutral,"neutral");
        DealHand(playerHand,"player");
        DealHand(enemyHand,"opponent");
        printDeckCount();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(drop.getTurn()<48){//if its the first turn or if its the end of the first session
            if(enemyHand.isEmpty()&&playerHand.isEmpty()){
                DealHand(playerHand, "player");
                DealHand(enemyHand, "opponent");
            }
            if(drop.getTurn()%2==0){//player turn

            }
            else{//computer turn
                Debug.Log("Opponent");
                ComputerMove();
            }
            
        }
        else{
            Debug.Log("Game Over");
        }
        
        
        //check if hands are empty
        //check if a card is double clicked
    }
    public void DealHand(HandController hand,string hand_){
        Card[] cards;
        //deck.ShuffleDeck();//shuffle the deck before dealing
        cards = deck.DealCards(hand_);//deal the cards
        hand.AssignCards(cards);//assign the cards to hand
    }
    private void printDeckCount(){
        Debug.Log(deck.getDeckCount());
    }
    private void ComputerMove(){
        List<CardController> computerCards = enemyHand.getCardList();
        List<CardController> cardOnTable = neutral.getCardList();
        bool found = false;
        int random = 0;
        for(int i = 0;i<computerCards.Count;i++){
            if(computerCards[i].getCard().getValue() == cardOnTable[0].getCard().getValue()&&computerCards[i].gameObject.activeSelf){
                drop.ComputerDrop(enemyHand,computerCards[i]);
                found = true;
                break;
            }
        }        
        if(found == false){
            random = Random.Range(0,4);
            if(computerCards[random].gameObject.activeSelf){
                drop.ComputerDrop(enemyHand,computerCards[random]);
                found = true;
            }
        }
    }
}
