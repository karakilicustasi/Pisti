using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    Card card;
    private Image imageObject;
    private Text valueObject;
    private CardDatabase cd;
    
    void Start()
    {
        imageObject = transform.GetChild(0).gameObject.GetComponent<Image>();
        valueObject = transform.GetChild(1).gameObject.GetComponent<Text>();
        cd = new CardDatabase();
        setCardTexture();
    }

    // Update is called once per frame
    void Update()
    {//drag drop operations?
        
    }
    public void setCard(Card c){
        card = c;
    }
    public void setCardTexture(){
        imageObject.sprite = cd.returnSprite(0,12);
    }
    
}
