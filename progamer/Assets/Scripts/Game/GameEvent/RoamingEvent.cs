using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "RoamingEvent", menuName = "GameEvent/RoamingEvent")]
public class RoamingEvent : GameEventData
{

    // [Header("Advantage")]
    // [SerializeField] private int[] advSourceAbilityType;
    // [SerializeField] private float[] advSourceAbilityRatio;
    // [SerializeField] private int[] advTargetAbilityType;
    // [SerializeField] private float[] advTargetAbilityRatio;

    // [SerializeField] private int[] targetLines;
    [SerializeField] private List<int> participantLines = new List<int>();    
    [SerializeField] private int targetLine;

    // [SerializeField] private float totalIProp;
    // [SerializeField] private float[] lineProp;
    // [SerializeField] private float[] minProp;
    // [SerializeField] private float[] maxProp;
    
    // void Awake() {
    //     lineProp = new float[(int)lineNum];
    //     minProp = new float[(int)lineNum];
    //     maxProp = new float[(int)lineNum];
    // }

    // public override float CalculateEventProp(TeamStrategy[] teamStrategy) {
    //     totalIProp = 0f;
    //     float totalTProp = 0f;
    //     for (int i = Const.BLUE; i <= Const.RED; i++) {                
    //         totalIProp += teamStrategy[i].ITeamFight[Const.TOP] + teamStrategy[i].ITeamFight[Const.MID] + teamStrategy[i].ITeamFight[Const.ADC] + teamStrategy[i].ITeamFight[Const.SPT];
    //         totalTProp += teamStrategy[i].TTeamFight;
    //         lineProp[Const.TOP] += teamStrategy[i].ILine[Const.TOP];
    //         lineProp[Const.MID] += teamStrategy[i].ILine[Const.MID];
    //         lineProp[Const.ADC] += teamStrategy[i].ILine[Const.ADC];
    //         lineProp[Const.SPT] += teamStrategy[i].ILine[Const.SPT];
    //     }
    //     return IndivisualRatio*totalIProp + TeamRatio*lineNum*totalTProp;
    // }

    // public override int SelectLine() {
    //     return Const.TOP;
    // }



    // public override void Raise() {
    //     // base.Raise(source, target);
    //     // line = Random.Range(0,4);
    //     // GetHero();
    //     // CalculateProp();
                
    //     base.Raise();
    //     GameUI.Instance.ShowEventMsg(eventMessage + " , line: " + raiseLine);

    //     // Simulation.Instance.TakeDamage(hero1, hero2, dmg1, dmg2, time, 1f);
    //     // hero1.MultipleTakeDamage(dmg2, time);
    //     // hero2.MultipleTakeDamage(dmg1, time);

    //     // Simulation.Instance.InvokeRepeating("TakeDamage", 0f, 1f); 
    //     // Simulation.Instance.CancelInvoke("TakeDamage");                        
    // }
    // protected override void OnEnable() {
    //     base.OnEnable();
    //     targetLines = new int[10];
    //     for (int i = 0; i < targetLines.Length; i++) {
    //         targetLines[i] = i;
    //     }
    // }

    // public override void NewSourceLine(int sourceLine, int targetLine) {
    //     // if (sourceLines.Length == 4) {
    //     lines = lines.Where(val => val != sourceLine).ToArray();
    //     if (targetLine == 3 || targetLine == 4 || targetLine == 8 || targetLine == 9) {
    //         lines = lines.Where(val => val != 3 && val != 4 && val != 8 && val != 9).ToArray();
    //         // for (int i = 0; i < lines.Length; i++) {
    //         //     if (lines[i] == 3 || lines[i] == 4 || lines[i] == 8 || lines[i] == 9) {
    //         //         lines = lines.Where(val => val != 3 &&).ToArray();
    //         //     }
    //         // }
    //         this.targetLines = new int[4];
    //         this.targetLines[0] = 3;
    //         this.targetLines[1] = 4;
    //         this.targetLines[2] = 8;
    //         this.targetLines[3] = 9;
    //     } else {
    //         int line = targetLine % 5;
    //         lines = lines.Where(val => val != line && val != line+5).ToArray();
    //         this.targetLines = new int[2];
    //         this.targetLines[0] = line;
    //         this.targetLines[1] = line+5;
    //     }
    //     Setup();
    // }

    // public override void ResetLine() {
    //     base.ResetLine();
    //     targetLines = new int[10];
    //     for (int i = 0; i < targetLines.Length; i++) {
    //         targetLines[i] = i;
    //     }
    // }    

    public override int SelectRaiser() {
        participantLines.Clear();
        
        // 0 ~ 9, pick roaming liner
        int raiseLine = base.SelectRaiser();

        // 0 ~ 9, pick line to roam
        targetLine = -1;
        while (true) {
            targetLine = Random.Range(0, 10);
            if (targetLine % 5 != raiseLine % 5) {
                break;
            }
        }

        for (int i = 0; i < lines.Length; i++) {
            if (raiseLine == lines[i]) {
                participantLines.Add(lines[i]);
                continue;
            }   

            if (targetLine % 5 == Const.ADC || targetLine % 5 == Const.SPT) {
                if (lines[i] % 5 == Const.ADC || lines[i] % 5 == Const.SPT) {
                    participantLines.Add(lines[i]);
                    continue;
                }
            } else {
                if (targetLine % 5 == lines[i] % 5) {
                    participantLines.Add(lines[i]);
                    continue;
                }
            }


            float rand;
            while (true) {
                rand = Random.Range(0f, 1f);
                if (rand != 1f) {
                    break;
                }
            }

            if (rand < lineProp[i]) {
                participantLines.Add(lines[i]);
            }            
        }

        return raiseLine;
    }

    public override int AddTargets(List<string> targets, int raiseLine, int raiseTeam) {
        for (int i = 0; i < participantLines.Count; i++) {
            int team = participantLines[i] < 5 ? Const.BLUE : Const.RED;
            int realLine = participantLines[i] % 5;            
            targets.Add(Simulation.Instance.teamStatus[team].Id[realLine]);
        }        
        return targetLine;

        // 0 -> top, 1 -> jug, 2 -> mid, 3 -> adc, 4-> spt
        
        // if (raiseLine == Const.ADC || raiseLine == Const.SPT) {
        //     targetLines = targetLines.Where(val => val != 3 && val != 4 && val != 8 && val != 9).ToArray();
        // } else {
        //     targetLines = targetLines.Where(val => val != raiseLine && val != raiseLine+5).ToArray();
        // }


        // int rand = -1;
        // bool isTarget = false;
        // while (isTarget == false) {
        //     rand = Random.Range(0, 10);
        //     // if (rand == raiseLine || rand == raiseLine+5) {
        //     //     continue;
        //     // }

        //     for (int i = 0; i < targetLines.Length; i++) {
        //         if (rand == targetLines[i]) {
        //             isTarget = true;
        //             break;
        //         }
        //     }

            // if (raiseLine == rand) {
            //     continue;
            // }

            // if (raiseLine == Const.ADC || raiseLine == Const.SPT) {
            //     if (rand == 3 || rand == 4) {
            //         continue;
            //     }
            // }
        // }

        // targets.Add(Simulation.Instance.teamStatus[raiseTeam].Id[raiseLine]);
        // if (rand == 3 || rand == 4 || rand == 8 || rand == 9) {
        //     targets.Add(Simulation.Instance.teamStatus[Const.BLUE].Id[Const.ADC]);
        //     targets.Add(Simulation.Instance.teamStatus[Const.BLUE].Id[Const.SPT]);
        //     targets.Add(Simulation.Instance.teamStatus[Const.RED].Id[Const.ADC]);
        //     targets.Add(Simulation.Instance.teamStatus[Const.RED].Id[Const.SPT]);
        // } else {
        //     int line = rand % 5;
        //     targets.Add(Simulation.Instance.teamStatus[Const.BLUE].Id[line]);
        //     targets.Add(Simulation.Instance.teamStatus[Const.RED].Id[line]);
        // }
        // targets.Add(raiseTeam*5 + raiseLine);
        // if (rand == 3 || rand == 4 || rand == 8 || rand == 9) {
        //     targets.Add(3);
        //     targets.Add(4);
        //     targets.Add(8);
        //     targets.Add(9);
        // } else {
        //     if (rand < 5) {
        //         targets.Add(rand);
        //         targets.Add(rand+5);
        //     } else {
        //         targets.Add(rand);
        //         targets.Add(rand-5);
        //     }
        // }

        
        
        // if (rand == 3 || rand == 4 || rand == 8 || rand == 9) {
        //     targets.Add(Simulation.Instance.teamStatus[Const.BLUE].Id[Const.ADC]);
        //     targets.Add(Simulation.Instance.teamStatus[Const.BLUE].Id[Const.SPT]);
        //     targets.Add(Simulation.Instance.teamStatus[Const.RED].Id[Const.ADC]);
        //     targets.Add(Simulation.Instance.teamStatus[Const.RED].Id[Const.SPT]);
        // } else {
        //     if (rand < 5) {
        //         targets.Add(Simulation.Instance.teamStatus[Const.BLUE].Id[rand]);
        //         targets.Add(Simulation.Instance.teamStatus[Const.RED].Id[rand]);
        //     } else {
        //         targets.Add(Simulation.Instance.teamStatus[Const.BLUE].Id[rand-5]);
        //         targets.Add(Simulation.Instance.teamStatus[Const.RED].Id[rand-5]);
        //     }
        // }
            
        // return rand;
    }

    // public override void CalculateAdv(Dictionary<string, float> relativeAdv, List<string> targets) {
    //     float[] ability = new float[targets.Count];
    //     float max = 0f;
        
    //     Player sourcePlayer = GameSetup.Instance.GetPlayer(targets[0]);
    //     for (int j = 0; j < advSourceAbilityType.Length; j++) {
    //         Debug.Log(sourcePlayer.Ability.ability_list[advSourceAbilityType[j]] + " " + advSourceAbilityRatio[j]);
    //         ability[0] += sourcePlayer.Ability.ability_list[advSourceAbilityType[j]] * advSourceAbilityRatio[j];
    //     }
    //     max += ability[0];

    //     for (int i = 1; i < targets.Count; i++) {
    //         Player targetPlayer = GameSetup.Instance.GetPlayer(targets[i]);
    //         for (int j = 0; j < advTargetAbilityType.Length; j++) {
    //             Debug.Log(targetPlayer.Ability.ability_list[advTargetAbilityType[j]] + " " + advTargetAbilityRatio[j]);
    //             ability[i] += targetPlayer.Ability.ability_list[advTargetAbilityType[j]] * advTargetAbilityRatio[j];
    //         }
    //         max += ability[i];         
    //     }

    //     AddAdv(relativeAdv, targets, ability, max);
    // }

    // public override void CalculateResultProp() {
        
    // }

    // public override void RegisterListener(GameEventListener listener) {
    //     base.RegisterListener(listener);
    // }

    // public override void UnregisterListener(GameEventListener listener) {
    //     base.UnregisterListener(listener);
    // }
}