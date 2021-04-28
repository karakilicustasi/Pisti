using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    
    private int type; //0- hearts 1-clubs 2- diamonds 3-spades
    private int value;//1-10 -> 11 - J 12 - Q 13 - K
    private Texture cardImage;
    private bool isCardPlayed;

    public Card(int type,int value){
        this.type = type;
        this.value = value;
        isCardPlayed = false;
    }
    public int getType(){
        return type;
    }
    public int getValue(){
        return value;
    }
    public Texture getImage(){
        return cardImage;
    }
    public Played(){
        isCardPlayed = true;
    }
    public Dealt(){
        isCardPlayed = false;
    }
    
}
