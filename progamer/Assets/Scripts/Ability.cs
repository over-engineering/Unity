using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Ability 
{    
    public string id;
    public List<float> ability_iv_list;
    public List<float> ability_list;
    
    // public static void SetAbility(Ability ability) {        
    //     this = ability;        
    //     Debug.Log("SetAbility " + ability.id + " " + ability.ability_list);       
    // }
    public void AddAbility(Dictionary<int, float> vals) {
        foreach (int target in vals.Keys) {
            ability_list[target] += vals[target];
        }
        Api.UpdateAbility(this);
    }

    public void SubAbility(Dictionary<int, float> vals) {
        foreach (int target in vals.Keys) {
            ability_list[target] -= vals[target];
        }
        Api.UpdateAbility(this);
    }
}

