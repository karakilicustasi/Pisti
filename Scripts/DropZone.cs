using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    [SerializeField] 
    private HandController Neutral;
    private CardController collidedCard;
    private bool cardEntered;
    void Start()
    {
        Debug.Log("neutral initialized");
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        collidedCard = collisionInfo.gameObject.GetComponent<CardController>();
        collidedCard.setInRange(true);
    }
    void OnCollisionExit2D(Collision2D other) {
        collidedCard = other.gameObject.GetComponent<CardController>();
        collidedCard.setInRange(false);
    }
    void Update()
    {
        if(collidedCard.isPlayable()&&collidedCard.isDropped()&&collidedCard.isInRange()){
            Neutral.cardDropped(collidedCard);
            collidedCard.setInRange(false);
        }
    }
}
