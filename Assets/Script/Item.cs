using UnityEngine;
using System.Collections.Generic;
using MyBox;

public class Item : MonoBehaviour
{
    public CardData cardData;
    public List<Transform> targets = new List<Transform>();
    public ItemStat statbonus;

    [ButtonMethod]
    public void PlayCard()
    {
        
        List<IAbility> abilities = cardData.GetAbilities(); // Lấy danh sách skill

        foreach (IAbility ability in abilities)
        {
            ability.ActivateSkill(transform, targets); // Kích hoạt từng skill
        }
        targets.Clear();
    }
}
