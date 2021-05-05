using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    [SerializeField] 
    private HandController Neutral;
    [SerializeField]
    private HandController Player;
    private GameObject collidedObject;
    private CardController collidedCard;
    private bool cardEntered;
    private int turn;
    void Start()
    {
        turn = 0;
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        collidedObject = collisionInfo.gameObject;//
        collidedCard = collidedObject.GetComponent<CardController>();// get card controller component from collided object
        collidedCard.setInRange(true);//the card is in the range of neutral cards collider
    }
    void OnCollisionExit2D(Collision2D other) {//if the card is out of the range
        collidedCard = other.gameObject.GetComponent<CardController>();//get the collided card controller component
        collidedCard.setInRange(false);//its out of the range of neutral collider
    }
    void Update()
    {
        if(collidedCard.isPlayable()&&collidedCard.isDropped()&&collidedCard.isInRange()){//if a card is playable and in the rage of collision
            collidedObject.transform.parent.gameObject.GetComponent<HandController>().RemoveCard(collidedCard.getCard());//remove the card from user hand
            Neutral.cardDropped(collidedCard);//drop the card on table
            if(Neutral.getHand()[0].gameObject.activeSelf){//if there is an active card on table
                if(collidedCard.getCard().getValue()==Neutral.getHand()[0].getCard().getValue()||collidedCard.getCard().getValue()==10){
                    
                    Player.AddAwardedCards(Neutral.getCardList());
                    Neutral.ClearCardsAtHand();
                    Neutral.getHand()[0].gameObject.SetActive(false);
                }
                else{
                    //Neutral.cardDropped(collidedCard);
                }
            }
            else{//if the drop zone empty
                //Neutral.cardDropped(collidedCard);
                Neutral.getHand()[0].gameObject.SetActive(true);

            }
            collidedCard.setInRange(false);
            collidedObject.SetActive(false);
            turn++;
        }
    }
    public void ComputerDrop(HandController opponentHand,CardController card){
        Neutral.cardDropped(card);
        opponentHand.RemoveCard(card.getCard());
        card.gameObject.SetActive(false);
        turn++;
    }

    public void incrementTurn(){
        turn++;
    }
    public int getTurn(){
        return turn;
    }
}