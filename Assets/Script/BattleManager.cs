using System.Collections.Generic;
using MyBox;
using Unity.Collections;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public List<Character> player;
    public List<Character> enemy;
    public bool IsEnd { get; private set; }

    [ButtonMethod]
    public void Init (){
        player.ForEach(x => x.Init());
        enemy.ForEach(x => x.Init());
    }
   


}
