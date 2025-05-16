using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) TargetSystem.Instance.SelectSkill(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) TargetSystem.Instance.SelectSkill(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) TargetSystem.Instance.SelectSkill(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) TargetSystem.Instance.SelectSkill(3);
    }
}
