using UnityEngine;
using System.Collections.Generic;

// [System.Serializable]
[CreateAssetMenu(fileName = "Equipment", menuName = "GameObject/Equipment")]
public class Equipment : ScriptableObject
{
    public string id;
    public string name;
    public int equipment_type;
    public Dictionary<int, float> target_ability = new Dictionary<int, float>();
    public List<float> _target_ability = new List<float>();

    void OnEnable() {
        for (int i = 0; i < _target_ability.Count; i++) {
            if (_target_ability[i] == 0f)    
                continue;
            target_ability[i] = _target_ability[i];
        }
    }

    public void Equip() {
        Debug.Log("Equip!!!");
        // Equipment equipment = GameManager.Instance.Character.equipments[equipment_type];
        // GameManager.Instance.Character.equipments[equipment_type] = equipment;
        GameManager.Instance.MyCharacter.ability.AddAbility(target_ability);
        // Api.EquipEquipment();
    }

    public void UnEquip() {
        Debug.Log("UnEquip!!!");
        // Equipment equipment = GameManager.Instance.Character.equipments[equipment_type];
        GameManager.Instance.MyCharacter.ability.SubAbility(target_ability);
    }
}