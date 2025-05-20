using System.Collections.Generic;
using MyBox;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    public HorizontalCardHolder horizontalCardHolder;
    public List<CharacterData> characterDataList;
    public Card cardPrefab;
    [ButtonMethod]
    public void Spawn()
    {
        horizontalCardHolder.Spawn();
        int index = 0;
        foreach (Transform transform in horizontalCardHolder.transform)
        {
            if (index < characterDataList.Count)
            {
                if (characterDataList[index] != null)
                {
                    Card x = Instantiate(cardPrefab, transform);
                    x.SetData(characterDataList[index]);
                    x.Init();
                }

                index++;
            }

        }
        Invoke(nameof(DelayAction), 1);
    }

    private void DelayAction()
    {
        horizontalCardHolder.Reload();
    }
}
