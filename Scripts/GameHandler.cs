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
    void Start()
    {
        deck = new Deck();
        DealHand(neutral);
        DealHand(playerHand);
        DealHand(enemyHand);
        printDeckCount();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //check if the hands are empty
    }
    public void DealHand(HandController hand){
        Card[] cards;
        deck.ShuffleDeck();//shuffle the deck before dealing
        cards = deck.DealCards();//deal the cards
        hand.AssignCards(cards);//assign the cards to hand
    }
    public void initializeNeutral(){
        
    }
    private void printDeckCount(){
        Debug.Log(deck.getDeckCount());
    }
}
