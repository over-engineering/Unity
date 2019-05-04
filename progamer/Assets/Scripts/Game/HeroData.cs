using UnityEngine;

[CreateAssetMenu(fileName = "HeroData", menuName = "GameObject/Hero Data")]
public class HeroData : ScriptableObject
{
    [SerializeField] private Sprite icon;

    [SerializeField] private int id;
    [SerializeField] private int type;
    [SerializeField] private string name;
    
    // [SerializeField] private int health;
    // [SerializeField] private int mana;    
    [SerializeField] private int maxHP;
    [SerializeField] private int maxMP;
    [SerializeField] private int attackDamage;
    [SerializeField] private int armor;
    [SerializeField] private int abilityPower;
    [SerializeField] private int magicResistance;    
    [SerializeField] private int movementSpeed;

    
    [SerializeField] private float iLevelUpExp;    
    [SerializeField] private int iHP;     
    [SerializeField] private int iMP;    
    [SerializeField] private int iAD;    
    [SerializeField] private int iAR;    
    [SerializeField] private int iAP;    
    [SerializeField] private int iMR;
    [SerializeField] private int iMS;
    [SerializeField] private int range;
    
    [SerializeField] private Skill[] skills = new Skill[4];

    public int Id { get{ return id;} } 
    public int Type { get{ return type;} } 
    public string Name { get{ return name;} }
    
    // public int Health { get{ return health;} }     
    // public int Mana { get{ return mana;} } 
    public int MaxHP { get{ return maxHP;} }
    public int MaxMP { get{ return maxMP;} } 
    public int AttackDamage { get{ return attackDamage;} } 
    public int Armor { get{ return armor;} } 
    public int AbilityPower { get{ return abilityPower;} } 
    public int MagicResistance { get{ return magicResistance;} } 
    public int MovementSpeed { get{ return movementSpeed;} }

    public float ILevelUpExp { get{ return iLevelUpExp;} }    
    public int IHP { get { return iHP; } }     
    public int IMP { get { return iMP; } }    
    public int IAD { get { return iAD; } }
    public int IAR { get { return iAR; } }
    public int IAP { get { return iAP; } }
    public int IMR { get { return iMR; } }
    public int IMS { get { return iMS; } } 
    public int Range { get{ return range;} } 

    // void Awake() {
    //     Die();
    // }

    // public void AddExp(int exp) {
    //     experience += exp;
    //     if (experience >= 100) {
    //         experience -= 100;
    //         LevelUp();
    //     }
    // }

    // public void LevelUp() {
    //     level += 1;
    //     // health += iHP;
    //     // mana += iMP;
    //     // attackDamage += iAD;
    //     // armor += iAR;
    //     // abilityPower += iAP;
    //     // magicResistance += iMR;
    //     // movementSpeed += iMS;
    // }

    // public bool TakeDamage(int damage) {
    //     int amount = damage - armor;
        
    //     if (amount <= 0) {
    //         return false;
    //     }
        
    //     int leftHealth = health-amount;
    //     health -= amount;
        
    //     // Debug.Log(playerId + " TakeDamage: " + (damage - armor).ToString());
    //     if (health <= 0) {
    //         Die();
    //         return true;
    //     }
    //     return false;
    // }

    // private void Die() {
    //     Debug.Log(this + " die!!!");
    //     health = maxHP;   
    //     mana = maxMP;
    // }

    

    // public void UpdateHero(List<float> addVal, List<float> subVal) {
    //     for (int i = 0; i < addVal.Count; i++) {
    //         stats[i] += addVal;
    //         stats[i] -= subVal;
    //     }
    // }
}


