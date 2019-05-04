// using UnityEngine;
// using UnityEngine.Events;

// [CreateAssetMenu(fileName = "LevelUpEvent", menuName = "GameEvent/LevelUpEvent")]
// public class LevelUpEvent : GameEvent
// {
//     // this.func = ResponseHandler.AttackDamage;
//     // public UnityAction<string, string> func = ResponseHandler.AttackDamage;
//     public void LevelUp(string source, string target) {
//         Debug.Log(source + " LevelUp!!!");
//     }

//     void OnEnable() {
//         this.func = LevelUp;
//     }

//     void OnDisable() {
//         this.func = null;
//     }

//     // public override void Raise(string source, string target) {
//     //     base.Raise(source, target);
//     //     GameUI.Instance.ShowEventMsg(source + " " + this.eventMessage);
//     // }
//     public override void Raise() {

//     }

//     public override void RegisterListener(GameEventListener listener) {
//         base.RegisterListener(listener);
//     }

//     public override void UnregisterListener(GameEventListener listener) {
//         base.UnregisterListener(listener);
//     }
// }