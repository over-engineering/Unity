using UnityEngine;
using UnityEngine.Events;
// using UnityEngine.SceneManagement;
using System.Collections.Generic;
// using System.Linq;

[CreateAssetMenu(fileName = "GameEvent", menuName = "GameEvent/GameEvent")]
public abstract class GameEventData : ScriptableObject
{
    // protected List<GameEventListener> listeners = new List<GameEventListener>();
    public UnityAction<string, string> func;
    
    // public UnityAction<string, string> func = ResponseHandler.AttackDamage;
    public int Id;
    [SerializeField] private string name;
    [SerializeField] protected string eventMessage;
    
    [Header("Indivisual")]
    public float IndivisualRatio;
    [SerializeField] protected int[] IndivisisualStrType;
    [SerializeField] protected float[] indStrRatio;
    [Header("Team")]
    public float TeamRatio;
    [SerializeField] protected int[] TeamStrType;
    [SerializeField] protected float[] teamStrRatio;

    // [SerializeField] private int lineNum;
    public int[] lines; // source line
    public int[] OriginLines; // original line
    // [SerializeField] protected float totalIProp;
    [SerializeField] protected float totalIndStr;
    [SerializeField] protected float[] lineProp;
    [SerializeField] protected float[] minProp;
    [SerializeField] protected float[] maxProp;
    // [SerializeField] protected float[,] lineProp;
    // [SerializeField] protected float[] redLineProp;
    

    // public int raiseTeam;
    // public int raiseLine;
    // [SerializeField] protected List<string> targets = new List<string>();
    // public int time;

    // public float ILine;
    // public float ITeamFight;
    // public float TLine;
    // public float TTeamFight; 

    // [Header("Advantage")]
    // [SerializeField] protected int[] advAbilityType;
    // public Dictionary<string, float> RelativeAdv = new Dictionary<string, float>();
    // public float RelativeAdv1;
    // public float RelativeAdv2;
    

    [Header("Advantage")]
    // [SerializeField] protected float abilityRatio;
    [SerializeField] private int[] advAbilityType;
    [SerializeField] private float[] advAbilityRatio;
    // [SerializeField] protected float heroRatio;
    // [SerializeField] protected float resAbilityRatio;
    // [SerializeField] protected int[] resAbilityType;
    
    // public float SpecifiedAbilityRatio;

    // public int[] BaseAbilityType;
    // public int[] SpecifiedAbilityType;

    // public Hero hero1;
    // public Hero hero2;
    

    // public float Prop1;
    // public float Prop2;
    // public int[] baseAbilityType;
    // public int[] specifiedAbilityType;

    
    

    // public int sourceHeroIndex;
    // public int targetHeroNumber;
    // public List<float> addVal;
    // public List<float> subVal;

    // public void EventHappen(Hero sourceHero, Hero[] targetHero) {
    //     int target = Random.Range(0, 4);
    //     bool die = targetHero[target].TakeDamage(sourceHero.attackDamage);
    //     if (die) {
    //         sourceHero.LevelUp();
    //     }

    //     eventMessage = "Player " + sourceHero.playerId + ", Hero " + sourceHero.name + " attack Player " + targetHero[target].playerId + ", Damage: " + (sourceHero.attackDamage - targetHero[target].armor).ToString();
    //     GameUI.Instance.ShowEventMsg(eventMessage);
        
    //     string playerId = targetHero[target].playerId;
    //     Debug.Log(target);
    //     GameUI.Instance.UpdateHealth(playerId, targetHero[target].health, targetHero[target].maxHP);
    
    //     // for (int i = 0; i < targetHero.Length; i++) {

    //     //     bool die = targetHero[i].TakeDamage(sourceHero.attackDamage);
    //     //     if (die) {
    //     //         sourceHero.LevelUp();
    //     //     }
    //     // }
    // }   

    // public virtual void Raise(string source, string target) 
    // {
    //     for (int i = listeners.Count - 1; i >= 0; i--) 
    //     {
    //         listeners[i].OnEventRaised(this, source, target); 
    //     }        
    // }
    protected virtual void OnEnable() {
        Debug.Log("GameEvent OnEnable!!!");
        lines = new int[OriginLines.Length];
        for (int i = 0; i < OriginLines.Length; i++) {
            lines[i] = OriginLines[i];
        }
        // Array.Copy(OriginLines, 0, lines, 0, OriginLines.Length);
        Setup();
        // lineProp = new float[2, 5];
        // minProp = new float[2*5];
        // maxProp = new float[2*5];
        
    }

    protected void Setup() {
        lineProp = new float[lines.Length];
        minProp = new float[lines.Length];
        maxProp = new float[lines.Length];
    }

    public virtual void NewSourceLine(int sourceLine, int targetLine) {        
        if (targetLine == 3 || targetLine == 4 || targetLine == 8 || targetLine == 9) {
            lines = new int[4];
            lines[0] = 3;
            lines[1] = 4;
            lines[2] = 8;
            lines[3] = 9;
        } else {
            int line = targetLine % 5;
            lines = new int[2];
            lines[0] = line;
            lines[1] = line + 5;
        }
        // lines = sourceLines;
        Setup();
    }

    public virtual void ResetLine() {
        lines = new int[OriginLines.Length];
        for (int i = 0; i < OriginLines.Length; i++) {
            lines[i] = OriginLines[i];
        }
        Setup();
    }

    public virtual float CalculateRaiseProp() {
        // TeamStrategy[] teamStrategy = GameEventMaker.Instance.teamStrategy;

        totalIndStr = 0f;
        // float totalTeamProp = 0f;
        for (int j = 0; j < lines.Length; j++) { 
            totalIndStr += CalculateIndStr(j);         
            // int line = lines[j];
            // if (line < 5) {              
            //     totalIndStr += CalculateIndStr(Const.BLUE, j);
            // } else {
            //     totalIndStr += CalculateIndStr(Const.RED, j);                                    
            // }
        }

        // Debug.Log("CalculateEventProp!!! EventProp: " + IndivisualRatio);
        // Debug.Log("CalculateEventProp!!! EventProp: " + totalIndProp);
        // Debug.Log("CalculateEventProp!!! EventProp: " + (float)IndivisisualStrType.Length);
        // Debug.Log("CalculateEventProp!!! EventProp: " + TeamRatio);
        // Debug.Log("CalculateEventProp!!! EventProp: " + lines.Length);
        // Debug.Log("CalculateEventProp!!! EventProp: " + totalTeamProp);
        // Debug.Log("CalculateEventProp!!! EventProp: " + (float)TeamStrType.Length);

        // totalIndProp /=  (float) IndivisisualStrType.Length;
        // totalTeamProp /= (float) TeamStrType.Length;

        // Debug.Log("CalculateEventProp!!! " + IndivisualRatio*totalIndProp + TeamRatio*lines.Length*totalTeamProp);
        return totalIndStr;
        // return IndivisualRatio*totalIndStr + TeamRatio*totalTeamProp;
    }

    public virtual float CalculateIndStr(int j) {
        // TeamStrategy[] teamStrategy = GameEventMaker.Instance.teamStrategy;
        // int realLine = lines[j] % 5;
        // int team = lines[j] < 5 ? Const.BLUE : Const.RED;
        
        // float indStr = 0f;
        // float teamStr = 0f;
        // for (int k = 0; k < IndivisisualStrType.Length; k++) {            
        //     int strType = IndivisisualStrType[k];     
        //     // Debug.Log();       
        //     indStr += teamStrategy[team].IndStr[realLine].IndStrategy[strType]*indStrRatio[k];
        // }

        // for (int k = 0; k < TeamStrType.Length; k++) {
        //     int strType = TeamStrType[k];
        //     teamStr += teamStrategy[team].TeamStr[strType]*teamStrRatio[k];
        // }

        // lineProp[j] = indStr*IndivisualRatio + teamStr*TeamRatio;
        // // Debug.Log("Line prop: " + lineProp[j]);
        // return lineProp[j];
        // for (int k = 0; k < TeamStrType.Length; k++) {
        //     int strType = TeamStrType[k];
        //     lineProp[team, line] += teamStrategy[team].TeamStr[strType] * teamStrRatio[k];
        // }
        TeamStrategy[] teamStrategy = GameEventMaker.Instance.teamStrategy;
        int realLine = lines[j] % 5;
        int team = lines[j] < 5 ? Const.BLUE : Const.RED;
        
        float indStr = 0f;
        float teamStr = 0f;
        for (int k = 0; k < IndivisisualStrType.Length; k++) {            
            int strType = IndivisisualStrType[k];     
            indStr += teamStrategy[team].IndStr[realLine].IndStrategy[strType]*indStrRatio[k];
        }
        lineProp[j] = indStr;

        for (int k = 0; k < TeamStrType.Length; k++) {
            int strType = TeamStrType[k];
            teamStr += teamStrategy[team].TeamStr[strType]*teamStrRatio[k];
        }

        // lineProp[j] = indStr*IndivisualRatio + teamStr*TeamRatio;
        return indStr*IndivisualRatio + teamStr*TeamRatio;

    }

    // public float CalculateTeamStr(int team) {
    //     TeamStrategy[] teamStrategy = GameSetup.Instance.teamStrategy;
    //     float totalTeamProp = 0f;
    //     for (int k = 0; k < TeamStrType.Length; k++) {
    //         int strType = TeamStrType[k];
    //         totalTeamProp += teamStrategy[team].TeamStr[strType]*teamStrRatio[k];
    //     }
    //     return totalTeamProp;
    // }

    protected float SetMinAndMax() {
        
        float tot = 0f;
        for (int i = 0; i < lines.Length; i++) {
            tot += lineProp[i];
        }

        minProp[0] = 0f;
        for (int j = 0; j < lines.Length; j++) {
            if (j != 0) {
                minProp[j] = maxProp[j - 1];
            }
            maxProp[j] = minProp[j] + lineProp[j] / tot;
        }

        float rand;
        while (true) {
            rand = Random.Range(0f, 1f);
            if (rand != 1f) {
                break;
            }
        }

        return rand;

        // for (int i = Const.BLUE; i <= Const.RED; i++) {
        //     for (int j = 0; j < lines.Length; j++) {
        //         // Debug.Log(i +" " + j);
        //         if (j + i*lines.Length != 0) {
        //             minProp[j + i*lines.Length] = maxProp[j + i*lines.Length - 1];
        //         }                
        //         maxProp[j + i*lines.Length] = minProp[j + i*lines.Length] + lineProp[i, j] / totalIndStr;
        //     }
        // }
    }
    
    public virtual int SelectRaiser() {
        float rand = SetMinAndMax();
                
        // Debug.Log("SelectRaser!!! " + rand);
        for (int j = 0; j < lines.Length; j++) {
            if (rand >= minProp[j] && rand < maxProp[j]) {
                return lines[j];
            }
        }

        // for (int i = Const.BLUE; i <= Const.RED; i++) { 
        //     for (int j = 0; j < lines.Length; j++) {
        //         if (rand >= minProp[j + i*lines.Length] && rand < maxProp[j + i*lines.Length]) {
        //             // raiseTeam = i;
        //             // raiseLine = lines[j];                    
        //             return i*5 + lines[j];
        //             // break;
        //         }         
        //     }
        // }
        return -1;
    }

    // public virtual void Raise() {
    //     // if (raiseLine)
    //     // CalculateResultProp();
    //     ClearTargets();
    //     AddTargets();
    //     CalculateAdv();
    //     bool b = CheckIfIncludeMyHero();
    //     if (b == true) {
    //         // SceneManager.LoadScene("");
    //     } else {
    //         Debug.Log("CalculateResultProp!!!");
    //         CalculateResultProp();
    //         // ApplyEvent();
    //     }
        

    // }

    public abstract int AddTargets(List<string> targets, int raiseLine, int raiseTeam);

    // private void ClearTargets() {
    //     targets.Clear();
    //     RelativeAdv.Clear();
    // }

    // public virtual bool CheckIfIncludeMyHero() {
    //     for (int i = 0; i < targets.Count; i++) { 
    //         if (targets[i] == GameSetup.Instance.MyPlayer.Id) {
    //             Debug.Log("Load Game Scene!!!");
    //             return true;     
    //         }
    //     }
    //     return false;
    // }   

    public virtual void CalculateAdv(Dictionary<string, float> abilityAdv, Dictionary<string, float> heroAdv, List<string> targets) {
        float[] ability = new float[targets.Count];
        float heroDmg;
        // Hero[] heros = new Hero[targets.Count];
        // float max1 = 100f * advAbilityType.Length;
        // float max2 = 0f;
        for (int i = 0; i < targets.Count; i++) {
            string id = targets[i];
            Player player = GameSetup.Instance.GetPlayer(id);
            for (int j = 0; j < advAbilityType.Length; j++) {
                // Debug.Log(player.Ability.ability_list[advAbilityType[j]] + " " + advAbilityRatio[j]);
                ability[i] += player.Ability.ability_list[advAbilityType[j]] * advAbilityRatio[j];
            
            }            
            
            heroDmg = player.Hero.AttackDamage + player.Hero.Armor;
            float abilitySum = ability[i];
            float heroSum = heroDmg;
            Debug.Log("Calculate advantage id: " + id + " " + abilitySum + " " + heroSum);
            abilityAdv.Add(id, abilitySum);
            heroAdv.Add(id, heroSum);
            // max2 += heroDmg[i];
        }
    }

    public virtual void ApplySimResult(int result, int amount, int targetLine) {

    }

    // public void Sim(Dictionary<string, float> abilityAdv, Dictionary<string, float> heroAdv) {

    // }

    // public abstract void CalculateResultProp();

    // public virtual void CalculateResultProp() {
    //     Ability ability1 = Simulation.Instance.blueAbility[raiseLine];
    //     Ability ability2 = Simulation.Instance.redAbility[raiseLine]; 

    //     // calculate bAbility
    //     float bAbility1 = 0f;
    //     float bAbility2 = 0f;
    //     for (int i = 0; i < BaseAbilityType.Length; i++) {
    //         bAbility1 += ability1.ability_list[BaseAbilityType[i]];
    //         bAbility2 += ability2.ability_list[BaseAbilityType[i]];
    //     }
    //     bAbility1 = bAbility1/(bAbility1+bAbility2);
    //     bAbility2 = 1-bAbility1;

    //     // calculate sAbility
    //     float sAbility1 = 0f;
    //     float sAbility2 = 0f;        
    //     for (int i = 0; i < SpecifiedAbilityType.Length; i++) {
    //         sAbility1 += ability1.ability_list[SpecifiedAbilityType[i]];
    //         sAbility2 += ability2.ability_list[SpecifiedAbilityType[i]];
    //     }
    //     sAbility1 = sAbility1/(sAbility1+sAbility2);
    //     sAbility2 = 1-sAbility1;

    //     // calulate damage
    //     float dmg1 = (float) (hero1.HeroData.AttackDamage - hero2.HeroData.Armor);
    //     float dmg2 = (float) (hero2.HeroData.AttackDamage - hero1.HeroData.Armor);
    //     dmg1 = dmg1/(dmg1+dmg2);
    //     dmg2 = 1-dmg1;

        
    //     Prop1 = bAbility1 * BaseAbilityRatio + sAbility1 * SpecifiedAbilityRatio + dmg1 * HeroRatio;
    //     Prop2 = 1-Prop1;
    //     Debug.Log("Prop: " + Prop1 + " " + Prop2);
    // }

    // public virtual void RegisterListener(GameEventListener listener) 
    // {
    //     listeners.Add(listener);
    // }

    // public virtual void UnregisterListener(GameEventListener listener) 
    // {
    //     listeners.Remove(listener);
    // }
}
