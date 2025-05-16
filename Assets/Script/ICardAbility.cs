
using System.Collections.Generic;
using UnityEngine;
public interface IAbility
{
    void ActivateSkill(Transform user, List<Transform> targets);
}

