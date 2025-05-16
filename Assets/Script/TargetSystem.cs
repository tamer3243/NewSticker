using Unity.VisualScripting;
using UnityEngine;
public enum GameState { CharacterSL, SkilSL, TargetSL, Exercute, Waiting }
public class TargetSystem : MonoBehaviour
{
    public static TargetSystem Instance;
    public Character selectedCharacter;
    public Skill selectedSkill;
    public GameState state = GameState.CharacterSL;
    private void Awake()
    {
        if (Instance == null) Instance = gameObject.GetComponent<TargetSystem>();
    }

    // Chọn nhân vật để điều khiển
    public void SelectCharacter(Character character)
    {

        Debug.Log($"Selected character: {character.name}");
        if (character != null && character.canAttack && character.canControl & state == GameState.CharacterSL)
        {

            selectedCharacter = character;
            selectedSkill = null; // Reset skill khi chọn nhân vật mới
            Debug.Log($"Selected character: {character.name}");
        }
    }

    // Chọn kỹ năng
    public void SelectSkill(int skillIndex)
    {
        if (selectedCharacter != null && skillIndex >= 0 && skillIndex < selectedCharacter.SkillSet.Length)
        {
            selectedSkill = selectedCharacter.SkillSet[skillIndex];

            Debug.Log($"Selected skill: {selectedSkill.data.skillName}");
            state = GameState.TargetSL;
        }
    }

    // Kích hoạt kỹ năng lên mục tiêu
    public void UseSkillOnTarget(Character target)
    {
        if (selectedCharacter != null && selectedSkill != null && target != null)
        {
            selectedSkill.targets.Add(target.transform);
            selectedSkill.Active();
            Debug.Log($"{selectedCharacter.name} used {selectedSkill.data.skillName} on {target.name}");
            selectedSkill = null; // Reset skill sau khi dùng
        }
        else
        {
            Debug.Log("Invalid target or no skill selected!");
        }
       
        selectedCharacter = null;

        state = GameState.CharacterSL;
    }

    public bool HasSelectedSkill() => selectedSkill != null;
}
