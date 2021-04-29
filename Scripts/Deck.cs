using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck
{
    private List<Card> deck;
    // Start is called before the first frame update
    
    public Deck()
    {
        deck = new List<Card>();
        FillDeck();
        Debug.Log("Deck has been initialized");
    }

    // Update is called once per frame
    private void FillDeck(){//fill the deck lisst //and get card textures from card database
        for(int i = 0; i<4;i++){
            for(int j = 0; j<13;j++){
                deck.Add(new Card(i,j));
            }
        }
    }
    public void ShuffleDeck(){
        
        int size = deck.Count;
        while(size>1){
            size--;
            int randomCard = Random.Range(0,size+1);
            Card c = deck[randomCard];
            deck[randomCard]=deck[size];
            deck[size]=c;

        }
    }
    public Card[] DealCards(){
        Card[] newHand = new Card[4];
        if(deck.Count>=4){
            for(int i = 0; i<4;i++){
                newHand[i] = deck[i];
                deck.RemoveAt(i);
            }
        }
        return newHand;
    }
    public int getDeckCount(){
        return deck.Count;
    }
}
