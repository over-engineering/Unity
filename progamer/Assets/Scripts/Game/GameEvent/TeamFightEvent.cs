using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "TeamFightEvent", menuName = "GameEvent/TeamFightEvent")]
public class TeamFightEvent : GameEventData
{
    // [SerializeField] private float minTime;

    public override float CalculateRaiseProp() {
        // if (Simulation.Instance.Timer < minTime) {
        //     return 0f;
        // }
        
        TeamStatus[] teamStatus = GameSetup.Instance.teamStatus;
        // tower check
        for (int i = 0; i < 4; i++) {
            // jug
            if (i == 1) {
                continue;
            }

            bool b = teamStatus[Const.BLUE].IsFirstTowerExist(i);
            if (b == false) {
                break;
            }

            b = teamStatus[Const.RED].IsFirstTowerExist(i);
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
}
