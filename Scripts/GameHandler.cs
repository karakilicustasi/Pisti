using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private Deck deck;
    [SerializeField]
    private CardController[] playerHand = new CardController[4];//will be initialized in editor
    [SerializeField]
    private CardController[] enemyHand = new CardController[4];
    //deck
    //card array of card controllers for user and oppenent
    //instantiate those cards from the editor
    //try to manipulate them through this class 
    
    void Start()
    {
        deck = new Deck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
