using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Training : MonoBehaviour
{
    [SerializeField] public string id;
    [SerializeField] private int level;
    [SerializeField] private float time;    

    public Dictionary<int, float> target_ability;
    
    
}