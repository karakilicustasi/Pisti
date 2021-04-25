using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    
    private int type; //0- hearts 1-clubs 2- diamonds 3-spades
    private int value;//1-10 -> 11 - J 12 - Q 13 - K

    public Card(int type,int value){
        this.type = type;
        this.value = value;
    }
    
}
