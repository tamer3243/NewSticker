using System.Collections.Generic;
using MyBox;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    public HorizontalCardHolder horizontalCardHolder;
    public List<CharacterData> characterDataList;
  
    [ButtonMethod]
    public void Spawn()
    {
        horizontalCardHolder.Spawn(characterDataList);
    }

}
