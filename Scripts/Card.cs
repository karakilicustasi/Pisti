using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    private int type {get; set;};
    private int value {get; set;};

    public Card(){

    }
    public Card(int type,int value){
        this.type = type;
        this.value = value;
    }
}
