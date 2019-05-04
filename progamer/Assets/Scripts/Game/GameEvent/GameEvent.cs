using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

[System.Serializable]
public class GameEvent
{
    public GameEventData GameEventData;
    // public int[] Lines;
    public int RaiseTeam;
    public int RaiseLine;
    public int TargetTeam;
    public int TargetLine;
    public float Time;

    // [SerializeField] private float[] minProp;
    // [SerializeField] private float[] maxProp;
    // [SerializeField] private float[,] lineProp;
    // [SerializeField] private float totalIndStr;

    public List<string> Targets = new List<string>();
    public const float MIN_TIME = 30f;
    public const float MAX_TIME = 60f;
    // public Dictionary<string, float> RelativeAdv = new Dictionary<string, float>();
    // public Dictionary<string, float> AbilityAdv = new Dictionary<string, float>();
    // public Dictionary<string, float> HeroAdv = new Dictionary<string, float>();

    public GameEvent(GameEventData gameEventData) {
        this.GameEventData = gameEventData;
        this.Time = Random.Range(MIN_TIME, MAX_TIME);
        SelectRaser();
        // this.Lines = lines;
        // minProp = new float[Lines.Length];
        // maxProp = new float[Lines.Length];
        // lineProp = new float[2, Lines.Length]; 
    }

    // public void AddTargets(List<string> targets) {        
    //     for (int i = 0; i < targets.Count; i++) {
    //         string id = targets[i];
    //         int j = Targets.FindIndex(item => item == id);            
    //         if (j < 0) {
    //             Debug.Log("Add " + id);
    //             Targets.Add(id);
    //         }
    //     }
    // }
    // public float CalculateRaiseProp() {
    //     return GameEventData.CalculateRaiseProp();
    // }

    // public void SelectRaser() {
    //     SetMinAndMax();
        
    //     float rand;
    //     while (true) {
    //         rand = Random.Range(0f, 1f);
    //         if (rand != 1f) {
    //             break;
    //         }
    //     }
        
    //     // Debug.Log("SelectRaser!!! " + rand);

    //     for (int i = Const.BLUE; i <= Const.RED; i++) { 
    //         for (int j = 0; j < Lines.Length; j++) {
    //             if (rand >= minProp[j + i*Lines.Length] && rand < maxProp[j + i*Lines.Length]) {
    //                 RaiseTeam = i;
    //                 RaiseLine = Lines[j];                    
    //                 break;
    //             }         
    //         }
    //     }
    // }
    
    // private void SetMinAndMax() {        
    //     minProp[0] = 0f;
    //     for (int i = Const.BLUE; i <= Const.RED; i++) {
    //         for (int j = 0; j < Lines.Length; j++) {
    //             // Debug.Log(i +" " + j);
    //             if (j + i*Lines.Length != 0) {
    //                 // minProp[j + i*Lines.Length] = maxProp[j + i*Lines.Length - 1];
    //                 minProp[j + i*Lines.Length] = maxProp[j + i*Lines.Length - 1];
    //             }                
    //             maxProp[j + i*Lines.Length] = minProp[j + i*Lines.Length] + lineProp[i, j] / totalIndStr;
    //         }
    //     }
    // }
    private void SelectRaser() {
        int raser = GameEventData.SelectRaiser();        
        RaiseTeam = raser < 5 ? Const.BLUE : Const.RED;
        RaiseLine = raser % 5;        
        Targets.Clear();
        int target = GameEventData.AddTargets(Targets, RaiseLine, RaiseTeam);
        TargetTeam = target < 5 ? Const.BLUE : Const.RED;
        TargetLine = target % 5;
        // GameEventData.CalculateAdv(RelativeAdv, Targets);
        // GameEventData.CalculateAdv(AbilityAdv, HeroAdv, Targets);
    }

    public void CalculateAdv(Dictionary<string, float> abilityAdv, Dictionary<string, float> heroAdv) {
        GameEventData.CalculateAdv(abilityAdv, heroAdv, Targets);
    }

    public void ApplySimResult(int result, int amount, List<Player> bluePlayer, List<Player> redPlayer) {
        switch (result) {
            case 0:
                Debug.Log("Blue Win");
                for (int i = 0; i < bluePlayer.Count; i++) {
                    Debug.Log("Hero: " + bluePlayer[i].Hero + "Growth: " + amount);
                    bluePlayer[i].Hero.UpdateHero(amount, amount);    
                }
                break;
            case 1:
                Debug.Log("Red Win");
                for (int i = 0; i < redPlayer.Count; i++) {
                    Debug.Log("Hero: " + redPlayer[i].Hero + "Growth: " + amount);
                    redPlayer[i].Hero.UpdateHero(amount, amount);    
                }
                break;
            case 2:
                Debug.Log("None");
                break;
            default: 
                Debug.Log("Error");
                break;
        }
        
        int targetLine = TargetTeam == Const.BLUE ? TargetLine : TargetLine + 5;
        GameEventData.ApplySimResult(result, amount, targetLine);
    }
    // public void Raise() {
    //     // ClearTargets();
    //     // GameEventData.AddTargets(targets, RaiseLine, RaiseTeam);        
    //     bool b = CheckIfIncludeMyHero();
    //     if (b == true) {
    //         // SceneManager.LoadScene("");
    //     } else {
    //         Debug.Log("CalculateResultProp!!!");
    //         // GameEventData.CalculateResultProp();
    //         // ApplyEvent();
    //     }   
    // }
    
    // private void ClearTargets() {
    //     targets.Clear();
    //     RelativeAdv.Clear();
    // }

    // private bool CheckIfIncludeMyHero() {
    //     for (int i = 0; i < Targets.Count; i++) { 
    //         if (Targets[i] == GameSetup.Instance.MyPlayer.Id) {
    //             Debug.Log("Load Game Scene!!!");
    //             return true;     
    //         }
    //     }
    //     return false;
    // }   
}