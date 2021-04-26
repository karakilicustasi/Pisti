using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDatabase{
    private Texture [] suits;
    private Texture [] jackSuits;
    private Texture [] queenSuits;
    private Texture [] kingSuits;
    Texture[] textures;
    
    public CardDatabase(){
        suits = new Texture[4];
        jackSuits = new Texture[4];
        queenSuits = new Texture[4];
        kingSuits = new Texture[4];
        importTextures();
        fillSuits();
        Debug.Log("Database has been initialized");        
    }
    private void importTextures(){
        textures = Resources.LoadAll<Texture>("cards");
    }
    private void fillSuits(){
        int i = 0;
        while(i<4){
            suits[i]=textures[i];
            jackSuits[i]=textures[i+4];
            queenSuits[i]=textures[i+8];
            kingSuits[i]=textures[i+12];
            i++;
        }
    }
    public Texture returnTexture(int suitIndex,int value){
        if(value == 11){
            return jackSuits[suitIndex];
        }
        else if(value==12){
            return queenSuits[suitIndex];
        }
        else if(value==13){
            return kingSuits[suitIndex];
        }
        else{
            return suits[suitIndex];
        }
    }

}
