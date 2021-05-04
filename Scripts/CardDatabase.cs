using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDatabase{
    private Sprite [] suits;
    private Sprite [] jackSuits;
    private Sprite [] queenSuits;
    private Sprite [] kingSuits;
    Sprite[] Sprites;
    
    public CardDatabase(){
        suits = new Sprite[4];
        jackSuits = new Sprite[4];
        queenSuits = new Sprite[4];
        kingSuits = new Sprite[4];
        importSprites();
        fillSuits();    
    }
    private void importSprites(){
        Sprites = Resources.LoadAll<Sprite>("cards");
    }
    private void fillSuits(){
        int i = 0;
        while(i<4){
            suits[i]=Sprites[i];
            jackSuits[i]=Sprites[i+4];
            queenSuits[i]=Sprites[i+8];
            kingSuits[i]=Sprites[i+12];
            i++;
        }
    }
    public Sprite returnSprite(int suitIndex,int value){
        if(value == 10){
            return jackSuits[suitIndex];
        }
        else if(value == 11){
            return queenSuits[suitIndex];
        }
        else if(value == 12){
            return kingSuits[suitIndex];
        }
        else{
            return suits[suitIndex];    
        }
    }

}
