using UnityEngine;

[System.Serializable]
public class Character
{
    public string name;
    public string id;
    public Ability ability;
    public Equipment[] equipments;    
    
    // public void SetAbility(Ability a) {
    //     this.ability = a;
    // }

    // public void SetEquipment(Equipment e) {
    //     this.equipment = e;
    // }
}
