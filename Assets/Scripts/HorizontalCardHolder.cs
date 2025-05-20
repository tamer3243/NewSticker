using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using MyBox;

public class HorizontalCardHolder : MonoBehaviour
{

    [SerializeField] private Card selectedCard;
    [SerializeReference] private Card hoveredCard;

    [SerializeField] private GameObject slotPrefab;
    private RectTransform rect;

    public List<Card> cards;
    public List<GameObject> cardSlot;
    bool isCrossing = false;
    [SerializeField] private bool tweenCardReturn = true;
    private int slotCount=5;

    [ButtonMethod]
    public void Spawn()
    {
        for (int i = 0; i < slotCount; i++)
        {
            var x = Instantiate(slotPrefab, transform);
            cardSlot.Add(x);
        }
    }
    [ButtonMethod]
    public void Reload()
    {
        rect = GetComponent<RectTransform>();
        cards = GetComponentsInChildren<Card>().ToList();
        int cardCount = 0;

        foreach (Card card in cards)
        {
            card.PointerEnterEvent.AddListener(CardPointerEnter);
            card.PointerExitEvent.AddListener(CardPointerExit);
            card.BeginDragEvent.AddListener(BeginDrag);
            card.EndDragEvent.AddListener(EndDrag);
            card.name = cardCount.ToString();
            cardCount++;
        }

        StartCoroutine(Frame());

        IEnumerator Frame()
        {
            yield return new WaitForSecondsRealtime(.1f);
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].cardVisual != null)
                    cards[i].cardVisual.UpdateIndex(transform.childCount);
            }
        }
    }

    private void BeginDrag(Card card)
    {
        selectedCard = card;
    }


    void EndDrag(Card card)
    {
        if (selectedCard == null)
            return;

        selectedCard.transform.DOLocalMove(selectedCard.selected ? new Vector3(0, selectedCard.selectionOffset, 0) : Vector3.zero, tweenCardReturn ? .15f : 0).SetEase(Ease.OutBack);

        rect.sizeDelta += Vector2.right;
        rect.sizeDelta -= Vector2.right;

        selectedCard = null;

    }

    void CardPointerEnter(Card card)
    {
        hoveredCard = card;
    }

    void CardPointerExit(Card card)
    {
        hoveredCard = null;
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Delete))
        // {
        //     if (hoveredCard != null)
        //     {
        //         Destroy(hoveredCard.transform.parent.gameObject);
        //         cards.Remove(hoveredCard);

        //     }
        // }


        if (selectedCard == null)
            return;

        if (isCrossing)
            return;

        for (int i = 0; i < cardSlot.Count; i++)
        {
            float selectedX = selectedCard.transform.position.x;
            float slotX = cardSlot[i].transform.position.x;

            // Nếu selectedCard kéo qua trái hoặc phải slot[i]
            if ((selectedX > slotX && selectedCard.ParentIndex() < i) ||
                (selectedX < slotX && selectedCard.ParentIndex() > i))
            {
                Swap(i); // Swap hoặc Move vào slot đó
                break;
            }
        }

    }

    void Swap(int index)
    {
        isCrossing = true;

        Transform focusedParent = selectedCard.transform.parent;
        Transform crossedParent = cardSlot[index].transform;

        // Tìm card đang ở slot[index] nếu có
        Card targetCard = cards.FirstOrDefault(card => card.transform.parent == crossedParent);

        if (targetCard != null && targetCard != selectedCard)
        {

            bool swapIsRight = targetCard.ParentIndex() > selectedCard.ParentIndex();
            // Di chuyển targetCard về slot cũ của selectedCard
            targetCard.transform.SetParent(cardSlot[index - 1 * (swapIsRight ? 1 : -1)].transform);
            targetCard.transform.localPosition = targetCard.selected ? new Vector3(0, targetCard.selectionOffset, 0) : Vector3.zero;

            // Visual swap animation
            targetCard.cardVisual.Swap(swapIsRight ? -1 : 1);
        }

        // Di chuyển selectedCard đến slot[index]
        selectedCard.transform.SetParent(crossedParent);

        isCrossing = false;

        // Cập nhật lại index visuals
        foreach (Card card in cards)
        {
            card.cardVisual.UpdateIndex(transform.childCount);
        }
    }

}
