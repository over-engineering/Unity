using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class TeamStatus
{
    public const int TOP_TOWER0 = 0;
    public const int TOP_TOWER1 = 1;
    public const int MID_TOWER0 = 2;
    public const int MID_TOWER1 = 3;
    public const int BOT_TOWER0 = 4;
    public const int BOT_TOWER1 = 5;
    public const int NEXUS_TOWER0 = 6;
    public const int NEXUS_TOWER1 = 7;

    public string[] Id;
    public Ability[] Ability;
    public Hero[] Hero;
    // key: id, value: health
    // 0, 1: top, 2, 3: mid, 4, 5: bot, 6, 7: nexus
    public int[] Towers; // hp
    public int Nexus; // hp

    // targetLine: 0 -> top, 1 -> jug, 2 -> mid, 3 -> adc, 4 -> spt
    public void UpdateTowerHealth(int amount, int targetLine) {
        switch (targetLine) {
            case 0:
                UpdateTower(0, amount);                
                break;
            case 2:
                UpdateTower(2, amount);
                break;
            case 3:
                UpdateTower(4, amount);
                break;
            case 4:
                UpdateTower(4, amount);
                break;
            default:
                Debug.Log("Tower health bug");
                break;
        }
    }

    private void UpdateTower(int k, int amount) {
        if (Towers[k] > 0) {
            Towers[k] -= amount;
            if (Towers[k] < 0) {
                Towers[k] = 0;
            }
            Debug.Log(this + " " + k + " Tower Hp: " + Towers[k]);
        } else if (Towers[k+1] > 0) {
            Towers[k+1] -= amount;            
            if (Towers[k+1] < 0) {                
                Towers[k+1] = 0;
            }
            Debug.Log(this + " " + (k+1).ToString() + " Tower Hp: " + Towers[k+1]);
        } else {
            Debug.Log("No tower left, Bug!!!");
        }    
    }

    public bool IsFirstTowerExist(int line) {       
        int towerIndex = GetTowerIndex(line);
        if (Towers[towerIndex] > 0) {
            return true;
        }
        return false;
    }    
    
    public bool IsSecondTowerExist(int line) {
        int towerIndex = GetTowerIndex(line);
        if (Towers[towerIndex+1] > 0) {
            return true;
        }
        return false;
    }

    private int GetTowerIndex(int line) {
        int towerIndex = -1;
        switch (line) {
            case 0:
                towerIndex = 0;
                break;
            case 2:
                towerIndex = 2;
                break;
            case 3:
                towerIndex = 4;
                break;
            case 4:
                towerIndex = 4;
                break;
            default:
                break;
        }
        return towerIndex;
    }
}