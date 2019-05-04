using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SiegeEvent", menuName = "GameEvent/SiegeEvent")]
public class SiegeEvent : GameEventData
{
    // [Header("Advantage")]
    // [SerializeField] private int[] advAbilityType;
    // [SerializeField] private float[] advAbilityRatio;
    [SerializeField] private float minTime;

    // 조건: minTime지나고, 상대 라인보다 레벨 높은 라인에서만 발생, 타워가 남아 있을 때만
    public override float CalculateRaiseProp() {        
        if (Simulation.Instance.Timer < minTime) {
            return 0f;
        }

        // TeamStatus ts = targetLine < 5 ? Simulation.Instance.teamStatus[Const.BLUE] : Simulation.Instance.teamStatus[Const.RED];
        // int rl = targetLine % 5;
        // bool b = ts.isTowerExist(rl);
        // if (b == false) {
        //     return 0f;
        // }

        // Debug.Log("SiegeEvent!!!");
        TeamStatus[] teamStatus = GameSetup.Instance.teamStatus;
        // TeamStrategy[] teamStrategy = GameEventMaker.Instance.teamStrategy;
        

        totalIndStr = 0f;
        // float totalTeamProp = 0f;
        for (int j = 0; j < lines.Length; j++) {
            // int line = lines[j];
            // int team = j < 5 ? Const.BLUE : Const.RED;
            int realLine = lines[j] % 5;
            int team = lines[j] < 5 ? Const.BLUE : Const.RED;
            int enemyTeam = lines[j] < 5 ? Const.RED : Const.BLUE;
            // lineProp[Const.BLUE, j] = 0f;            
            // lineProp[Const.RED, j] = 0f;     
            if (teamStatus[team].Hero[realLine].Level > teamStatus[enemyTeam].Hero[realLine].Level) {
                bool b = teamStatus[enemyTeam].IsSecondTowerExist(realLine);
                if (b == true) {
                    totalIndStr += CalculateIndStr(j);
                } else {
                    lineProp[j] = 0f;
                }
            }

            // if (lines[j] < 5) {
            //     if (teamStatus[Const.BLUE].Hero[realLine].Level > teamStatus[Const.RED].Hero[realLine].Level) {    
            //         bool b = teamStatus[Const.RED].isTowerExist(realLine);
            //         if (b == true) { 
            //             totalIndStr += CalculateIndStr(j);
            //         } else {
            //             lineProp[j] = 0f;
            //         }

            //     } else if (teamStatus[Const.BLUE].Hero[realLine].Level <= teamStatus[Const.RED].Hero[realLine].Level) {
            //         lineProp[j] = 0f;
            //     } 
            // } else {
            //     if (teamStatus[Const.RED].Hero[realLine].Level > teamStatus[Const.BLUE].Hero[realLine].Level) {    
            //         bool b = teamStatus[Const.BLUE].isTowerExist(realLine);
            //         if (b == true) {
            //             totalIndStr += CalculateIndStr(j);
            //         }  else {
            //             lineProp[j] = 0f;
            //         }                    
            //     } else if (teamStatus[Const.RED].Hero[realLine].Level <= teamStatus[Const.BLUE].Hero[realLine].Level) {
            //         lineProp[j] = 0f;
            //     } 
            // }

          
            // totalIndStr += lineProp[Const.BLUE, j] + lineProp[Const.RED, j];

            // for (int k = 0; k < TeamStrType.Length; k++) {
            //     int strType = TeamStrType[k];
            //     totalTeamProp += teamStrategy[Const.BLUE].TeamStr[strType] * teamStrRatio[k];
            //     totalTeamProp += teamStrategy[Const.RED].TeamStr[strType] * teamStrRatio[k];
            // }
        }

        // return totalIndProp*IndivisualRatio + totalTeamProp*TeamRatio;        
        return totalIndStr;
    }
    
    // private void CalculateLineProp(int team, int line) {
    //     for (int k = 0; k < IndivisisualStrType.Length; k++) {
    //         int strType = IndivisisualStrType[k];
    //         lineProp[team, line] += teamStrategy[team].IndStr[line].IndStrategy[strType] * indStrRatio[k];
    //     }
    //     // for (int k = 0; k < TeamStrType.Length; k++) {
    //     //     int strType = TeamStrType[k];
    //     //     lineProp[team, line] += teamStrategy[team].TeamStr[strType] * teamStrRatio[k];
    //     // }
    // }

    // public override void Raise() {
    //     base.Raise();         
    //     GameUI.Instance.ShowEventMsg(eventMessage + " , line: " + raiseLine);
    // }

    public override int AddTargets(List<string> targets, int raiseLine, int raiseTeam) {
        // 0 -> top, 2 -> mid, 3 -> adc, 4-> spt

        if (raiseLine == Const.ADC || raiseLine == Const.SPT) {
            // targets.Add();
            targets.Add(Simulation.Instance.teamStatus[Const.BLUE].Id[Const.ADC]);
            targets.Add(Simulation.Instance.teamStatus[Const.BLUE].Id[Const.SPT]);
            targets.Add(Simulation.Instance.teamStatus[Const.RED].Id[Const.ADC]);
            targets.Add(Simulation.Instance.teamStatus[Const.RED].Id[Const.SPT]);
        } else if (raiseLine == Const.TOP || raiseLine == Const.MID) {
            targets.Add(Simulation.Instance.teamStatus[Const.BLUE].Id[raiseLine]);
            targets.Add(Simulation.Instance.teamStatus[Const.RED].Id[raiseLine]);
        }

        return raiseTeam == Const.BLUE ? raiseLine+5 : raiseLine;
    }

    public override void ApplySimResult(int result, int amount, int targetLine) {
        TeamStatus[] teamStatus = Simulation.Instance.teamStatus;
        int enemyTeam = targetLine < 5 ? Const.BLUE : Const.RED;
        int realLine = targetLine % 5;

        switch (result) {
            case 0:                
                if (enemyTeam == Const.RED) {
                    teamStatus[Const.RED].UpdateTowerHealth(amount, realLine);    
                    Debug.Log("Red turret -");
                }                
                break;
            case 1:
                if (enemyTeam == Const.BLUE) {
                    teamStatus[Const.BLUE].UpdateTowerHealth(amount, realLine);
                    Debug.Log("Blue turret -");                
                }
                break;
            case 2:
                Debug.Log("None");
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    // public override void CalculateAdv(Dictionary<string, float> relativeAdv, List<string> targets) {

    //     float[] ability = new float[targets.Count];
    //     float max = 0f;
    //     for (int i = 0; i < targets.Count; i++) {
    //         Player player = GameSetup.Instance.GetPlayer(targets[i]);
    //         for (int j = 0; j < advAbilityType.Length; j++) {
    //             Debug.Log(player.Ability.ability_list[advAbilityType[j]] + " " + advAbilityRatio[j]);
    //             ability[i] += player.Ability.ability_list[advAbilityType[j]] * advAbilityRatio[j];
    //         }
    //         max += ability[i];         
    //     }
        
    //     AddAdv(relativeAdv, targets, ability, max);
    // }

    // public override void CalculateResultProp() {

    // }

}