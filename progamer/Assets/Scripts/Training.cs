using UnityEngine;
using System.Collections.Generic;

// [System.Serializable]
[CreateAssetMenu(fileName = "Training", menuName = "GameObject/Training")]
// public class Training
public class Training : ScriptableObject
// public class Training : MonoBehaviour
{
    public string id;
    public string name;
    public Dictionary<int, float> target_ability = new Dictionary<int, float>();    
    public List<float> _target_ability = new List<float>();
    // public int level;
    // public float time;        

    // public void SetTraining(string id, Dictionary<int, float> target) {
    //     this.id = id;
    //     this.target_ability = target;
    // }
    void OnEnable() {
        // Debug.Log("Start!!!");
        for (int i = 0; i < _target_ability.Count; i++) {
            if (_target_ability[i] == 0f)    
                continue;
            target_ability[i] = _target_ability[i];
        }
    }

    public void TakeTraining(int level, float time, float efficiecy) {
        Debug.Log("TakeTraining!!!");
        Dictionary<int, float> dict = new Dictionary<int, float>();
        foreach (int target in target_ability.Keys) {
            dict[target] = efficiecy * time * (target_ability[target] + level);                
            Debug.Log("TakeTraining2!!! " + dict[target]);
        }
        GameManager.Instance.MyCharacter.ability.AddAbility(dict);
    }
}