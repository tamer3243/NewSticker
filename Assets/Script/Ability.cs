
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "Card System/Abilities")]
public class Ability : ScriptableObject
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
     public void ActivateSkill(Transform user, Transform target)
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



