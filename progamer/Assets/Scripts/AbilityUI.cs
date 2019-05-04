using UnityEngine;
using UnityEngine.UI;
// using System.Linq;
// using System.Threading.Tasks;

public class AbilityUI : MonoBehaviour
{
    // [SerializeField] private float moving;
    // [SerializeField] private float skillshot;
    // [SerializeField] private float reaction;
    // [SerializeField] private float concentration;    
    // [SerializeField] private float creativity;

    // private Dictionary<string, float> abilities;
    
    [SerializeField] private string[] key;
    // [SerializeField] private float[] value;
    // private Ability ability;
    [SerializeField] private Text[] text;

    public void Setup(Ability ability) {
        // this.ability = ability;
        SetTexts();
    }

    public void OnEnable() {
        SetTexts();
    }

    // public void OnClick() {        
    //     SetTexts();
    //     foreach (Transform child in transform) {
    //         child.gameObject.SetActive(true);
    //     }    
    // }

    public void SetTexts() {
        Debug.Log("SetTexts");
        Ability ability = GameManager.Instance.GetAbility();

        for (int i = 0; i < text.Length; i++) {
            // Debug.Log(ability.ability_list[i] + " " + ability.ability_list.Count);
            text[i].text = key[i] + ": " + ability.ability_list[i];
        }
    }
}