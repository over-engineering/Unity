using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BattleEvent", menuName = "GameEvent/BattleEvent")]
public class BattleEvent : GameEventData
{
    [SerializeField] private List<int> participantLines = new List<int>();    
    [SerializeField] private int targetLine;
    
    public override float CalculateRaiseProp() {
        return base.CalculateRaiseProp();   
    }

    public override int SelectRaiser() {
        participantLines.Clear();
        
        // float raiseRand = SetMinAndMax();
        // int raiseLine = -1;        
        List<int> blue = new List<int>();
        List<int> red = new List<int>();        
        for (int i = 0; i < lines.Length; i++) {
            float rand;
            while (true) {
                rand = Random.Range(0f, 1f);
                if (rand != 1f) {
                    break;
                }
            }

            if (rand < lineProp[i]) {
                participantLines.Add(lines[i]);
                if (lines[i] < 5) {
                    blue.Add(lines[i]);
                } else {
                    red.Add(lines[i]);
                }
                // if (raiseRand >= minProp[i] && raiseRand < maxProp[i]) {
                //     raiseLine = lines[i];
                // }
            }            
        }

        if (blue.Count == 0 || red.Count == 0) {
            SelectRaiser();
        }

        // pick raise
        int raiseRand = Random.Range(0, participantLines.Count);
        int raiseLine = participantLines[raiseRand];        

        // pick target
        targetLine = -1;
        if (raiseLine < 5) {
            int targetRand = Random.Range(0, red.Count);
            targetLine = red[targetRand];
        } else {
            int targetRand = Random.Range(0, blue.Count);
            targetLine = blue[targetRand];
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
    }    

}