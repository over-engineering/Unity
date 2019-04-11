using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Ability 
{
    private const int MOVING = 0;
    private const int SKILLSHOT = 1;
    private const int REACTION = 2;
    private const int CONCENTRATION = 3;
    private const int CREATIVITY = 4;

    public string id;
    public List<float> ability_iv_list;
    public List<float> ability_list;
    
    // public static void SetAbility(Ability ability) {        
    //     this = ability;        
    //     Debug.Log("SetAbility " + ability.id + " " + ability.ability_list);       
    // }
}

