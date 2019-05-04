// using UnityEngine;
// using UnityEngine.Events;
// // using System.Collections.Generic;


// [CreateAssetMenu(fileName = "GangEvent", menuName = "GameEvent/GangEvent")]
// public class GangEvent : GameEvent
// {   
//     [Header("Advantage")]
//     [SerializeField] private int[] advSourceAbilityType;
//     [SerializeField] private float[] advSourceAbilityRatio;
//     [SerializeField] private int[] advTargetAbilityType;
//     [SerializeField] private float[] advTargetAbilityRatio;

//     // public override float CalculateEventProp(TeamStrategy[] teamStrategy) {
//     //     float totalIProp = 0f;
//     //     float totalTProp = 0f;
//     //     for (int i = Const.BLUE; i <= Const.RED; i++) {            
//     //             totalIProp += teamStrategy[i].ILine[Const.JUG];
//     //         totalTProp += teamStrategy[i].TLine;
//     //     }
//     //     return IndivisualRatio*totalIProp + TeamRatio*lineNum*totalTProp;
//     // }

//     // public override int SelectLine() {
//     //     return Const.JUG;
//     // }
//     // [SerializeField] private List<int> targets = new List<int>();

//     public override void Raise() {
//         // base.Raise(source, target);
//         // line = Random.Range(0,4);
//         // GetHero();
//         // CalculateProp();
        
        
        
//         base.Raise();
//         GameUI.Instance.ShowEventMsg(eventMessage + " , line: " + raiseLine);

//         // Simulation.Instance.TakeDamage(hero1, hero2, dmg1, dmg2, time, 1f);
//         // hero1.MultipleTakeDamage(dmg2, time);
//         // hero2.MultipleTakeDamage(dmg1, time);

//         // Simulation.Instance.InvokeRepeating("TakeDamage", 0f, 1f); 
//         // Simulation.Instance.CancelInvoke("TakeDamage");                        
//     }

//     public override void AddTargets() {
//         // 0 -> top, 1 -> mid, 2 -> adc, 3 -> spt
//         int rand = Random.Range(0, 4);
//         targets.Add(Simulation.Instance.teamStatus[raiseTeam].Id[raiseLine]);
//         if (rand == 0) {
//             targets.Add(Simulation.Instance.teamStatus[Const.BLUE].Id[Const.TOP]);
//             targets.Add(Simulation.Instance.teamStatus[Const.RED].Id[Const.TOP]);            
//         } else if (rand == 1) {
//             targets.Add(Simulation.Instance.teamStatus[Const.BLUE].Id[Const.MID]);            
//             targets.Add(Simulation.Instance.teamStatus[Const.RED].Id[Const.MID]);            
//         } else if (rand == 2 || rand == 3) {
//             targets.Add(Simulation.Instance.teamStatus[Const.BLUE].Id[Const.ADC]);            
//             targets.Add(Simulation.Instance.teamStatus[Const.BLUE].Id[Const.SPT]);
//             targets.Add(Simulation.Instance.teamStatus[Const.RED].Id[Const.ADC]);
//             targets.Add(Simulation.Instance.teamStatus[Const.RED].Id[Const.SPT]);
//         } 
//     }

//     public override void CalculateAdv() {
//         float[] ability = new float[targets.Count];
//         float max = 0f;
        
//         Player sourcePlayer = GameSetup.Instance.GetPlayer(targets[0]);
//         for (int j = 0; j < advSourceAbilityType.Length; j++) {
//             Debug.Log(sourcePlayer.Ability.ability_list[advSourceAbilityType[j]] + " " + advSourceAbilityRatio[j]);
//             ability[0] += sourcePlayer.Ability.ability_list[advSourceAbilityType[j]] * advSourceAbilityRatio[j];
//         }
//         max += ability[0];

//         for (int i = 1; i < targets.Count; i++) {
//             Player targetPlayer = GameSetup.Instance.GetPlayer(targets[i]);
//             for (int j = 0; j < advTargetAbilityType.Length; j++) {
//                 Debug.Log(targetPlayer.Ability.ability_list[advTargetAbilityType[j]] + " " + advTargetAbilityRatio[j]);
//                 ability[i] += targetPlayer.Ability.ability_list[advTargetAbilityType[j]] * advTargetAbilityRatio[j];
//             }
//             max += ability[i];         
//         }

//         AddAdv(ability, max);
//     }

//     public override void CalculateResultProp() {
        
//     }

//     // public override void RegisterListener(GameEventListener listener) {
//     //     base.RegisterListener(listener);
//     // }

//     // public override void UnregisterListener(GameEventListener listener) {
//     //     base.UnregisterListener(listener);
//     // }
// }