using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour
{
    public Image cardImage;
    private Item card;

    public void SetCard(Item newCard)
    {
        card = newCard;
        cardImage.sprite = card.cardData.cardImage;      
    }

 
}
