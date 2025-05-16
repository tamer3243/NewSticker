using UnityEngine;
using System.Collections.Generic;
using MyBox;

public class Skill
{
    public Character user;
    public List<Transform> targets = new List<Transform>();
    public SkillData data;
    public Skill(Character user,SkillData data)
    {
        this.user = user;
        this.data = data;
    }

    public virtual void Active()
    {
        if (user == null) return;
        List<IAbility> abilities = data.GetAbilities(); // Lấy danh sách skill

        foreach (IAbility ability in abilities)
        {
            ability.ActivateSkill(user.transform, targets); // Kích hoạt từng skill
        }
        targets.Clear();
    }

}
