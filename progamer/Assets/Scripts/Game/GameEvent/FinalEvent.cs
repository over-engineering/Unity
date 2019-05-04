using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "FinalEvent", menuName = "GameEvent/FinalEvent")]
public class FinalEvent : GameEventData
{
    
    public override float CalculateRaiseProp() {
        TeamStatus[] teamStatus = GameSetup.Instance.teamStatus;

        for (int i = 0; i < 4; i++) {
            if (i == 1) {
                continue;
            }

            bool b = teamStatus[Const.BLUE].IsSecondTowerExist(i);
            if (b == false) {
                break;
            }

            b = teamStatus[Const.RED].IsSecondTowerExist(i);
            if (b == false) {
                break;
            }

            if (i == 3) {
                return 0f;
            }
        }

        return base.CalculateRaiseProp();
    }

    public override int AddTargets(List<string> targets, int raiseLine, int raiseTeam) {
        int rand = -1;                
        if (raiseTeam == Const.BLUE) {
            rand = Random.Range(5, 10);
        } else {
            rand = Random.Range(0, 5);
        }
        
        for (int i = 0; i < 5; i++) {
            targets.Add(Simulation.Instance.teamStatus[Const.BLUE].Id[i]);
            targets.Add(Simulation.Instance.teamStatus[Const.RED].Id[i]);
        }

        return rand;
    }

    public override void ApplySimResult(int result, int amount, int targetLine) {       
        int enemyTeam = targetLine < 5 ? Const.BLUE : Const.RED;
        
        switch (result) {
            case 0: 
                if (enemyTeam == Const.RED) {
                    Debug.Log("Blue Win!!!");
                    GameSetup.Instance.GameEnd();
                    
                }
                break;
            case 1:
                if (enemyTeam == Const.BLUE) {
                    Debug.Log("Red Win!!!");
                    GameSetup.Instance.GameEnd();
                    
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
}
