using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{    
    // public string PlayerId { get; set;}
    [SerializeField] private HeroData heroData;    
    public HeroData HeroData { get { return heroData; } }
    
    [SerializeField] private float experience;
    [SerializeField] private float levelUpExp;
    [SerializeField] private int level;
    public int Level { get { return level; } }
    [SerializeField] private int maxHP;
    [SerializeField] private int health;
    [SerializeField] private int maxMP;
    [SerializeField] private int mana;
    [SerializeField] private int attackDamage;
    public int AttackDamage { get { return attackDamage; } }
    [SerializeField] private int armor;
    public int Armor { get { return armor; } }
    [SerializeField] private int abilityPower;
    [SerializeField] private int magicResistance;
    [SerializeField] private int movementSpeed;
    [SerializeField] private int gold;
    [SerializeField] private bool isDie;
    


    [SerializeField] private Text playerIdText;
    [SerializeField] private Text heroNameText;
    [SerializeField] private Text heroLevelText;
    [SerializeField] private Text heroGoldText;
    public HealthBar HealthBar { get; private set; }
    // public SimpleHealthBar HealthBar{ get; private set; }

    void Awake() {
        HealthBar = transform.GetChild(0).GetChild(0).GetComponent<HealthBar>();
        playerIdText = transform.GetChild(0).GetChild(1).GetComponent<Text>();
        heroNameText = transform.GetChild(0).GetChild(2).GetComponent<Text>();
        heroLevelText = transform.GetChild(0).GetChild(3).GetComponent<Text>();
        heroGoldText = transform.GetChild(0).GetChild(4).GetComponent<Text>();
    }
    
    private void SetTexts(string playerId) {
        playerIdText.text = playerId;
        heroNameText.text = HeroData.Name;
        heroLevelText.text = level.ToString();
        heroGoldText.text = gold.ToString();        
    }

    public void MoveText() {
        float x = heroNameText.GetComponent<RectTransform>().anchoredPosition.x;
        float y = heroNameText.GetComponent<RectTransform>().anchoredPosition.y;
        heroNameText.GetComponent<RectTransform>().anchoredPosition = new Vector2(-x, y);
        x = heroGoldText.GetComponent<RectTransform>().anchoredPosition.x;
        y = heroGoldText.GetComponent<RectTransform>().anchoredPosition.y;
        heroGoldText.GetComponent<RectTransform>().anchoredPosition = new Vector2(-x, y);
    }

    public void Initialize(string playerId) {        
        experience = 0f;
        levelUpExp = 100f;
        level = 1;
        maxHP = heroData.MaxHP;
        maxMP = heroData.MaxMP;
        health = heroData.MaxHP;
        mana = heroData.MaxMP;
        attackDamage = heroData.AttackDamage;
        armor = heroData.Armor;
        abilityPower = heroData.AbilityPower;
        magicResistance = heroData.MagicResistance;
        movementSpeed = heroData.MovementSpeed;
        SetTexts(playerId);
    }

    public void UpdateHero(float exp, int g) {
        // heroData.AddExp(exp);       
        experience += exp;
        if (experience >= levelUpExp) {            
            LevelUp();
        } 
        gold += g;

        heroLevelText.text = level.ToString();
        heroGoldText.text = gold.ToString();
    }

    private void LevelUp() {
        level += 1;
        experience -= levelUpExp;
        levelUpExp += heroData.ILevelUpExp;
        maxHP += heroData.IHP;
        maxMP += heroData.IMP;
        attackDamage += heroData.IAD;
        armor += heroData.IAR;
        abilityPower += heroData.IAP;
        magicResistance += heroData.IMR;
        movementSpeed += heroData.IMS;
    }
    // [SerializeField] private GameEvent OnTakeDamage;

    // public void Setup(string id) {
    //     this.playerId = id;
    //     // health = maxHP;
    // }
   
    public bool TakeDamage(int damage) {
        // Debug.Log(heroData + " " + damage);
        int amount = damage - armor;
        if (amount <= 0) {
            return false;
        }

        health -= amount;

        if (health <= 0) {
            Die();
            return true;
        }
        return false;

        Debug.Log(this + " " + health + " " + heroData.MaxHP);
        HealthBar.HandleHealthChanged(health, heroData.MaxHP);
        // return die;
        // HealthBar.UpdateBar(heroData.Health, heroData.MaxHP);
    }

    private void Die() {
        isDie = true;        
    }

    private void Respawn() {
        isDie = false;
        health = heroData.MaxHP;
        mana = heroData.MaxMP;
    }

}