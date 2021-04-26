using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    Card card;
    private CardDatabase cd;
    private Texture cardImage;
    void Start()
    {
        cd = new CardDatabase();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getCard(Card c){
        card = c;
    }
}
