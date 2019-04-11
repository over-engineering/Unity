using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Threading.Tasks;

class AbilityUI : MonoBehaviour
{
    // [SerializeField] private float moving;
    // [SerializeField] private float skillshot;
    // [SerializeField] private float reaction;
    // [SerializeField] private float concentration;    
    // [SerializeField] private float creativity;

    // private Dictionary<string, float> abilities;
    
    [SerializeField] private string[] key;
    // [SerializeField] private float[] value;
    private Ability ability;
    [SerializeField] private Text[] text;

    public void SetTexts() {
        Debug.Log("SetTexts");
        if (ability == null) {
        // if (!ability.AbilityList.Any()) {            
            // Task task = new Task(GetAbilityFromServer);
            // task.Start();
            // Task task = GetAbilityFromServer();
            // await GetAbilityFromServer();
            GetAbilityFromServer();
            // await task;
            // await Debug.Log("Task is done");
            return;
        }

        for (int i = 0; i < text.Length; i++) {
            // Debug.Log(ability.ability_list[i] + " " + ability.ability_list.Count);
            text[i].text = key[i] + ": " + ability.ability_list[i];
        }
    }

    public void SetAbility(Ability ability) {        
        this.ability = ability;
        // // this.ability.Id = ability.Id;
        Debug.Log("SetAbility " + ability.id + " " + ability.ability_list);
        // Debug.Log(ability);
        // Debug.Log(ability.ability_list);
        // foreach (float val in ability.ability_list) {
        //     Debug.Log(val);
        // }

        // for (int i = 0; i < ability.AbilityList.Count; i++) {
        //     Debug.Log(ability.AbilityList[i]);
        //     // this.ability = ability;
            
        //     Debug.Log(this.ability);
        //     Debug.Log(this.ability.Id);
        //     this.ability.AbilityList[i] = ability.AbilityList[i];
        // }
    }

    public void GetAbilityFromServer() {
        Debug.Log("GetAbilityFromServer");
        StartCoroutine(RestClient.Instance.Get(RestClient.ProgamerBaseURL, "/api/ability/character0", SetAbility));
    }



}