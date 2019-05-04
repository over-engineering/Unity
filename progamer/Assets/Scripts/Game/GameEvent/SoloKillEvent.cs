using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SoloKillEvent", menuName = "GameEvent/SoloKillEvent")]
public class SoloKillEvent : GameEventData
{
    // int line;
    // [SerializeField] private float totalIProp;
    // [SerializeField] private float[] lineProp;
    // [SerializeField] private float[] minProp;
    // [SerializeField] private float[] maxProp;
    // [Header("Advantage")]
    // [SerializeField] private int[] advAbilityType;
    // [SerializeField] private float[] advAbilityRatio;
    // [SerializeField] private int[] advAbilityType;

    // int cnt;
    // public Hero hero1;
    // public Hero hero2;
    // public float Prop1;
    // public float Prop2;

    // private void GetHero() {
    //     hero1 = Simulation.Instance.blueSideHero[raiseLine];
    //     hero2 = Simulation.Instance.redSideHero[raiseLine];
    //     Debug.Log(hero1 + " " + hero2);
    // }

    // public override float CalculateEventProp(TeamStrategy[] teamStrategy) {
    //     totalIProp = 0f;
    //     float totalTProp = 0f;        
        

    //     for (int j = Const.TOP; j <= Const.SPT; j++) {            
    //         lineProp[j] = 0f;
    //         for (int i = Const.BLUE; i <= Const.RED; i++) {
    //             totalIProp += teamStrategy[i].ILine[j];
    //             lineProp[j] += teamStrategy[i].ILine[j];
    //         }        
            
    //     }
    //     totalTProp = teamStrategy[Const.BLUE].TLine + teamStrategy[Const.RED].TLine;
        
    //     minProp[0] = 0f;
    //     for (int j = 0; j < lineNum; j++) {
    //         lineProp[j] /= totalIProp;
            
    //         if (j != 0) {    
    //             minProp[j] = maxProp[j-1];
    //         }
    //         maxProp[j] = minProp[j] + lineProp[j];
    //     }
        

    //     return IndivisualRatio*totalIProp + TeamRatio*lineNum*totalTProp;
    // }

    // public override int SelectLine() {
     
    // }
    
    // void Awake() {
    //     lineProp = new float[lines.Length];
    //     minProp = new float[lines.Length];
    //     maxProp = new float[lines.Length];
    // }

    // private void CalculateProp() {        
    //     Ability ability1 = Simulation.Instance.blueAbility[raiseLine];
    //     Ability ability2 = Simulation.Instance.redAbility[raiseLine]; 

    //     float val1 = 0f;
    //     float val2 = 0f;        
    //     // for (int i = 0; i < abilityType.Length; i++) {
    //     //     val1 += ability1.ability_list[i];
    //     //     val2 += ability2.ability_list[i];
    //     // }        
        
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

    // public void TakeDamage() {        
    //     hero1.TakeDamage(dmg2);
    //     hero2.TakeDamage(dmg1);
    //     // cnt++;
    //     // if (cnt == time) {
    //     //     Simulation.Instance.CancelInvoke("TakeDamage");                
    //     //     Simulation.Instance.currentGameEvent = null;
    //     //     cnt = 0;
    //     // }
    // }

    // void OnEnable() {                
    //     func = AttackDamage;
    // }

    // void OnDisable() {
    //     func = null;
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

    // public override void NewLine(int targetLine) {        
    //     if (targetLine == Const.ADC || targetLine == Const.SPT) {
    //         lines = new int[2];
    //         lines[0] = Const.ADC;
    //         lines[1] = Const.SPT;
    //     } else {
    //         lines = new int[1];
    //         lines[0] = targetLine;
    //     }
    // }

    // public override void OriginLine() {
    //     lines = new int[5];
    //     for (int i = 0; i < lines.Length; i++) {
    //         lines[i] = i;
    //     }
    // }    

    public override int AddTargets(List<string> targets, int raiseLine, int raiseTeam) {
        // 0 -> top, 1 -> jug, 2 -> mid, 3 -> adc, 4-> spt
        if (raiseLine == Const.ADC || raiseLine == Const.SPT) {
            targets.Add(Simulation.Instance.teamStatus[Const.BLUE].Id[Const.ADC]);
            targets.Add(Simulation.Instance.teamStatus[Const.BLUE].Id[Const.SPT]);
            targets.Add(Simulation.Instance.teamStatus[Const.RED].Id[Const.ADC]);
            targets.Add(Simulation.Instance.teamStatus[Const.RED].Id[Const.SPT]);
        } else {
            targets.Add(Simulation.Instance.teamStatus[Const.BLUE].Id[raiseLine]);
            targets.Add(Simulation.Instance.teamStatus[Const.RED].Id[raiseLine]);
        }
        return raiseTeam == Const.BLUE ? raiseLine+5 : raiseLine;
    }

    // public override void CalculateAdv(Dictionary<string, float> relativeAdv, List<string> targets) {
        
        
        // AddAdv(relativeAdv, targets, ability, max);
        // for (int i = 0; i < targets.Count; i++) {
        //     string id = targets[i];
        //     Debug.Log("id: " + id + ", relativeAdv: " + ability[i] / max);
        //     RelativeAdv.Add(id, ability[i] / max);
        // }

        

        // Ability blueAbility = GameSetup.Instance.teamStatus[Const.BLUE].Ability[raiseLine];
        // Ability redAbility = GameSetup.Instance.teamStatus[Const.RED].Ability[raiseLine]; 
        
        // // calculate bAbility
        // float ability1 = 0f;
        // float ability2 = 0f;
        // for (int i = 0; i < advAbilityType.Length; i++) {
        //     ability1 += blueAbility.ability_list[advAbilityType[i]];
        //     ability2 += redAbility.ability_list[advAbilityType[i]];
        // }
        // ability1 = ability1/(ability1+ability2);
        // ability2 = 1-ability1;
        // RelativeAdv.Add(blueAbility.)

        // calculate sAbility
        // float sAbility1 = 0f;
        // float sAbility2 = 0f;        
        // for (int i = 0; i < SpecifiedAbilityType.Length; i++) {
        //     sAbility1 += ability1.ability_list[SpecifiedAbilityType[i]];
        //     sAbility2 += ability2.ability_list[SpecifiedAbilityType[i]];
        // }
        // sAbility1 = sAbility1/(sAbility1+sAbility2);
        // sAbility2 = 1-sAbility1;

        // Hero blueHero = GameSetup.Instance.teamStatus[Const.BLUE].Hero[raiseLine];
        // Hero redHero = GameSetup.Instance.teamStatus[Const.RED].Hero[raiseLine];
        // // calulate damage
        // float dmg1 = (float) (blueHero.HeroData.AttackDamage - redHero.HeroData.Armor);
        // float dmg2 = (float) (redHero.HeroData.AttackDamage - blueHero.HeroData.Armor);
        // dmg1 = dmg1/(dmg1+dmg2);
        // dmg2 = 1-dmg1;
        
        // Prop1 = bAbility1 * BaseAbilityRatio + dmg1 * HeroRatio;
        // Prop2 = 1-Prop1;
        // Debug.Log("Prop: " + Prop1 + " " + Prop2);
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