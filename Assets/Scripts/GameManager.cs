using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject Card_up_1;
    public GameObject Card_up_2;
    public GameObject Card_up_3;
    
    public GameObject Card_down_1;
    public GameObject Card_down_2;
    public GameObject Card_down_3;
    
    public GameObject Card_Mission_A;
    public GameObject Card_Mission_B;
    public GameObject Card_Mission_C;

    public GameObject BackButton;
    
    private SpriteRenderer card_up_1_sprite;
    private SpriteRenderer card_up_2_sprite;
    private SpriteRenderer card_up_3_sprite;
    
    private SpriteRenderer Card_down_1_sprite;
    private SpriteRenderer Card_down_2_sprite;
    private SpriteRenderer Card_down_3_sprite;
    
    private List<Card> _deck;
    private Card _card;
    private int _deckSize;
    private int _i;
    
    private int _indexUpCard1;
    private int _indexUpCard2;
    private int _indexUpCard3;
    
    private bool _isBack;
    
    private bool _isActiveButtonBack;
    
    private Sprite _cardBack1;
    private Sprite _cardBack2;
    private Sprite _cardBack3;
    
    private Card _cardNextBack1;
    private Card _cardNextBack2;
    private Card _cardNextBack3;
    
    private Card _cardNext1;
    private Card _cardNext2;
    private Card _cardNext3;
    
    void Start()
    {
        _i = 0;
        _isBack = false;
        _isActiveButtonBack = false;

        GetCardsOfMissions();
            
        _deck = FindFirstObjectByType<CollectionCards>().cards;
        _deckSize = _deck.Count;
        Shuffle();
        Shuffle();

        card_up_1_sprite = Card_up_1.GetComponent<SpriteRenderer>();
        card_up_2_sprite = Card_up_2.GetComponent<SpriteRenderer>();
        card_up_3_sprite = Card_up_3.GetComponent<SpriteRenderer>();

        Card_down_1_sprite = Card_down_1.GetComponent<SpriteRenderer>();
        Card_down_2_sprite = Card_down_2.GetComponent<SpriteRenderer>();
        Card_down_3_sprite = Card_down_3.GetComponent<SpriteRenderer>();
        
        Card_down_1_sprite.sprite = _deck[_i++].cover;
        Card_down_2_sprite.sprite = _deck[_i++].cover;
        Card_down_3_sprite.sprite = _deck[_i++].cover;

        _indexUpCard1 = _i++;
        _indexUpCard2 = _i++;
        _indexUpCard3 = _i++;
        
        card_up_1_sprite.sprite = _deck[_indexUpCard1].font;
        card_up_2_sprite.sprite = _deck[_indexUpCard2].font;
        card_up_3_sprite.sprite = _deck[_indexUpCard3].font;
    }

    public void NextCards()
    {

        if (!_isActiveButtonBack)
        {
            BackButton.SetActive(true);
            _isActiveButtonBack = true;
        }

        if (_isBack)
        {
            _isBack = false;
            BackButton.SetActive(true);
            
            Card_down_1_sprite.sprite = _cardNextBack1.cover;
            Card_down_2_sprite.sprite = _cardNextBack2.cover;
            Card_down_3_sprite.sprite = _cardNextBack3.cover;

            card_up_1_sprite.sprite = _cardNext1.font;
            card_up_2_sprite.sprite = _cardNext2.font;
            card_up_3_sprite.sprite = _cardNext3.font;
        }
        else
        {
            if (_i >= 63)
            {
                //Debug.Log("Start new deck!!!");
            
                Card_down_1_sprite.sprite = _deck[_indexUpCard1].cover;
                Card_down_2_sprite.sprite = _deck[_indexUpCard2].cover;
                Card_down_3_sprite.sprite = _deck[_indexUpCard3].cover;
            
                _i = 0;
                Shuffle();

                _indexUpCard1 = _i++;
                _indexUpCard2 = _i++;
                _indexUpCard3 = _i++;
        
                card_up_1_sprite.sprite = _deck[_indexUpCard1].font;
                card_up_2_sprite.sprite = _deck[_indexUpCard2].font;
                card_up_3_sprite.sprite = _deck[_indexUpCard3].font;
            }
            else
            {
                SaveNextBackCard();
                SaveBackCard();
                Card_down_1_sprite.sprite = _deck[_indexUpCard1].cover;
                Card_down_2_sprite.sprite = _deck[_indexUpCard2].cover;
                Card_down_3_sprite.sprite = _deck[_indexUpCard3].cover;
        
                _indexUpCard1 = _i++;
                _indexUpCard2 = _i++;
                _indexUpCard3 = _i++;
            
                card_up_1_sprite.sprite = _deck[_indexUpCard1].font;
                card_up_2_sprite.sprite = _deck[_indexUpCard2].font;
                card_up_3_sprite.sprite = _deck[_indexUpCard3].font;
            }
        }
        
    }

    public void BackCards()
    {
        _isBack = true;
        BackButton.SetActive(false);

        SaveNextCard();
        
        Card_down_1_sprite.sprite = _cardBack1;
        Card_down_2_sprite.sprite = _cardBack2;
        Card_down_3_sprite.sprite = _cardBack3;

        card_up_1_sprite.sprite = _cardNextBack1.font;
        card_up_2_sprite.sprite = _cardNextBack2.font;
        card_up_3_sprite.sprite = _cardNextBack3.font;
    }

    private void SaveBackCard()
    {
        _cardBack1 = Card_down_1_sprite.sprite;
        _cardBack2 = Card_down_2_sprite.sprite;
        _cardBack3 = Card_down_3_sprite.sprite;
    }
    
    private void SaveNextCard()
    {
        _cardNext1 = _deck[_indexUpCard1];
        _cardNext2 = _deck[_indexUpCard2];
        _cardNext3 = _deck[_indexUpCard3];
    }
    
    private void SaveNextBackCard()
    {
        _cardNextBack1 = _deck[_indexUpCard1];
        _cardNextBack2 = _deck[_indexUpCard2];
        _cardNextBack3 = _deck[_indexUpCard3];
    }

    private void Shuffle()
    {
        for (int i = 0; i < _deckSize; i++)
        {
            _card = _deck[i];
            int randomIndex = Random.Range(i, _deckSize);
            _deck[i] = _deck[randomIndex];
            _deck[randomIndex] = _card;
        }
    }

    private void GetCardsOfMissions()
    {
        MissionCards _missionDeck = FindFirstObjectByType<MissionCards>();
        List<Card> missions = _missionDeck.GetMissions();

        FlipCard cardMissA = Card_Mission_A.GetComponent<FlipCard>();
        FlipCard cardMissB = Card_Mission_B.GetComponent<FlipCard>();
        FlipCard cardMissC = Card_Mission_C.GetComponent<FlipCard>();

        Card missionA = missions[Random.Range(0, 2)];
        Card missionB = missions[Random.Range(2, 4)];
        Card missionC = missions[Random.Range(4, 6)];
        
        cardMissA.cover = missionA.cover;
        cardMissA.face = missionA.font;
        
        cardMissB.cover = missionB.cover;
        cardMissB.face = missionB.font;
        
        cardMissC.cover = missionC.cover;
        cardMissC.face = missionC.font;

    }
}
