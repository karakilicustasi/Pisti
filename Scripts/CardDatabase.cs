using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDatabase{
    private Image clubImage;
    private Image heartImage;
    private Image spadeImage;
    private Image diamondImage;
    private Image jackClub;
    private Image jackSpade;
    private Image jackHeart;
    private Image jackDiamond;
    private Image queenClub;
    private Image queenSpade;
    private Image queenHeart;
    private Image queenDiamond;
    private Image kingClub;
    private Image kingSpade;
    private Image kingHeart;
    private Image kingDiamond;
    public CardDatabase(){
        clubImage = Resources.Load<Sprite>("cards/club");
        heartImage = Resources.Load<Sprite>("cards/heart");
        spadeImage = Resources.Load<Sprite>("cards/spade");
        diamondImage = Resources.Load<Sprite>("cards/diamond");
        Debug.Log("Database has been initialized");        
    }
    public Image getClubImage(){
        return clubImage;
    }
    public Image getHeartImage(){
        return heartImage;
    }
    public Image getDiamondImage(){
        return diamondImage;
    }
    public Image getSpadeImage(){
        return spadeImage;
    }
}
