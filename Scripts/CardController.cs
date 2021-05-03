using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler,IDragHandler
{
    Card card;
    private Vector3 startPosition;
    private Image imageObject;
    private Text valueObject;
    private CardDatabase cd;
    private bool newCardSet = false;
    private bool inRange = false;
    private bool dropped = false;
    [SerializeField] private bool playable = false;
    private RectTransform rectTransform;
    
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    void Start()
    {
        startPosition = transform.position;
        imageObject = transform.GetChild(0).gameObject.GetComponent<Image>();
        valueObject = transform.GetChild(1).gameObject.GetComponent<Text>();
        cd = new CardDatabase();
    }
    // Update is called once per frame
    void Update()
    {
        if(newCardSet){     //check if a new card set on this object
            setCardTexture();//set the texture
            newCardSet = false; //since the new card is set, set the flag to false
        }
    }
    public void setCard(Card c){
        card = c;
        newCardSet = true;
    }
    public Card getCard(){
        return card;
    }
    public void setCardTexture(){
        imageObject.sprite = cd.returnSprite(card.getType(),card.getValue());
        if(card.getValue()<10)
            valueObject.text = (card.getValue()+1).ToString();
        else
            valueObject.text = "";
        
    }
    public void OnPointerDown(PointerEventData eventData){

    }
    public void OnBeginDrag(PointerEventData eventData){

    }
    public void OnEndDrag(PointerEventData eventData){
        if(inRange){
            dropped = true;
        }
        returnPosition();
        
    }
    public void OnDrag(PointerEventData eventData){
        if(playable){
            rectTransform.anchoredPosition += eventData.delta;
        }
        
    }
    public bool isPlayable(){
        return playable;
    }
    public bool isDropped(){
        return dropped;
    }
    public bool isInRange(){
        return inRange;
    }
    public void setCardDropped(bool dropped){
        this.dropped = dropped;
    }
    public void setInRange(bool inRange){
        this.inRange=inRange;

    }
    public void returnPosition(){
        transform.position = startPosition;
    }
    
    
}
