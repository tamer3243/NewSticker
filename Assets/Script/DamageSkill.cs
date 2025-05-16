using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DamageSkill", menuName = "Card System/Abilities/Damage")]
public class DamageSkill : ScriptableObject, IAbility
{
    public int damage;
    public GameObject vfxPrefab;

    public void ActivateSkill(Transform user, List<Transform> targets)
    {
        foreach (Transform target in targets)
        {
            if (target.TryGetComponent(out Character enemy))
            {
                enemy.TakeDamage(damage);
                if (vfxPrefab != null)
                {
                    GameObject vfx = Instantiate(vfxPrefab, user.position, Quaternion.identity);
                    vfx.GetComponent<Projectile>().Launch(target.position);
                }
            }
        }
    }
}