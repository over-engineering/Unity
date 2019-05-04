// using UnityEngine;
// using UnityEngine.Events;
// using System.Collections.Generic;

// [CreateAssetMenu(fileName = "AttackDamageEvent", menuName = "GameEvent/AttackDamageEvent")]
// public class AttackDamageEvent : GameEvent
// {
//     // this.func = ResponseHandler.AttackDamage;
//     // public UnityAction<string, string> func = ResponseHandler.AttackDamage;

//     private Dictionary<string, Hero> heros = new Dictionary<string, Hero>();

//     void Setup() {
//         // heros.Add();
//     }

//     public void AttackDamage(string source, string target) {
//         Debug.Log("TakeDamageEvent!!!, Source: " + heros[source].PlayerId + ", Target: " + heros[target].PlayerId);
//         heros[target].TakeDamage(heros[source].HeroData.AttackDamage);        
//     }

//     void OnEnable() {                
//         func = AttackDamage;
//     }

//     void OnDisable() {
//         func = null;
//     }

//     public override void Raise() {

//     }
//     // public override void Raise(string source, string target) {
//     //     base.Raise(source, target);
//     //     GameUI.Instance.ShowEventMsg(this.eventMessage + " " + source + " -> " + target);
//     // }

//     public override void RegisterListener(GameEventListener listener) {
//         base.RegisterListener(listener);
//     }

//     public override void UnregisterListener(GameEventListener listener) {
//         base.UnregisterListener(listener);
//     }
// }