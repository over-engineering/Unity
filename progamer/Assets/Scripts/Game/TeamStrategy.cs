using UnityEngine;

[System.Serializable]
public class TeamStrategy
{    
    // public float[] ILine;
    // public float[] ITeamFight;

    public IndivisualStrategy[] IndStr;
    public float[] TeamStr;

    // public float TotalILine;
    // public float TotalITeamFight;
    
    // public float TLine;
    // public float TTeamFight;

    // public void UpdateTotal() {
    //     TotalILine = 0f;
    //     TotalITeamFight = 0f;
    //     for (int i = 0; i <= Const.SPT; i++) {            
    //         TotalILine += ILine[i];
    //         TotalITeamFight += ITeamFight[i];
    //     } 
    // }

    public void UpdateIndivisual(int type, float val, int line) {
        IndStr[line].UpdateStrategy(type, val);

        // if (val >= 0f) {
        //     ILine[line] = val;
        //     ITeamFight[line] = 0f;
        // } else {
        //     ILine[line] = 0f;
        //     ITeamFight[line] = -val;
        // }
        
    }

    public void UpdateTeam(int type, float val) {
        if (val >= 0f) {
            TeamStr[type] = val;
            TeamStr[type+1] = 0f;
        } else {
            TeamStr[type] = 0f;
            TeamStr[type+1] = -val;
        }
        // if (val >= 0f) {
        //     TLine = val;
        //     TTeamFight = 0f;
        // } else {
        //     TLine = 0f;
        //     TTeamFight = -val;
        // }
    }
}
