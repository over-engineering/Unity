using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class GameSetup : MonoBehaviour
{
    private static GameSetup instance;
    public static GameSetup Instance { get { return instance; } }
     
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } 
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }


    [SerializeField] private List<Hero> heroPrefab = new List<Hero>();
    // [SerializeField] private TeamStatus[] teamStatus;
    private Dictionary<string, Player> players = new Dictionary<string, Player>();
    public TeamStatus[] teamStatus;
    
    private const int TOWER_MAX_HP = 100;
    // public int MyTeam;
    // public int MyHeroLine;
    // public string MyHeroId;
    // public Hero MyHero;
    public Player MyPlayer;
    
    private int turnTeam;
    private int turnLine;
    // public int Turn;

    void Start() {
        teamStatus = new TeamStatus[2];
        teamStatus[Const.BLUE] = new TeamStatus();
        teamStatus[Const.RED] = new TeamStatus();

        teamStatus[Const.BLUE].Towers = new int[8] {TOWER_MAX_HP, TOWER_MAX_HP, TOWER_MAX_HP, TOWER_MAX_HP, TOWER_MAX_HP, TOWER_MAX_HP, TOWER_MAX_HP, TOWER_MAX_HP};
        teamStatus[Const.BLUE].Nexus = TOWER_MAX_HP;
        teamStatus[Const.RED].Towers = new int[8] {TOWER_MAX_HP, TOWER_MAX_HP, TOWER_MAX_HP, TOWER_MAX_HP, TOWER_MAX_HP, TOWER_MAX_HP, TOWER_MAX_HP, TOWER_MAX_HP};
        teamStatus[Const.RED].Nexus = TOWER_MAX_HP;
    
        teamStatus[Const.BLUE].Id = new string[5];        
        teamStatus[Const.BLUE].Ability = new Ability[5];
        teamStatus[Const.BLUE].Hero = new Hero[5];
        teamStatus[Const.RED].Id = new string[5];
        teamStatus[Const.RED].Ability = new Ability[5];
        teamStatus[Const.RED].Hero = new Hero[5];
        
        Character[] c = Test();
        Setup(c); // temp
        // heroPrefab.Add(AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Hero/PlayerController.prefab", typeof(PlayerController)));
    }   

    

    private Character MyCharacter; // tmp
    private Character[] Test() {
        Character[] c = new Character[10];        
        for (int i  = 0; i < 10; i++) {
            c[i] = new Character();
            c[i].ability = new Ability();
            c[i].ability.id = (i*i).ToString();
            c[i].id = c[i].ability.id;
            c[i].ability.ability_list = new List<float>();

            for (int j = 0; j < 5; j++) {
                c[i].ability.ability_list.Add(40f);
            }
        }
        MyCharacter = c[0];
        return c;
    }

     
    public void Setup(Character[] c) {
        for (int i = 0; i < c.Length; i++) {          
            if (i < 5) {
                // if (GameManager.Instance.MyCharacter.id == c[i].id) {                
                teamStatus[Const.BLUE].Id[i] = c[i].id;
                teamStatus[Const.BLUE].Ability[i] = c[i].ability;                
                Player player = new Player(c[i].id, c[i].ability, Const.BLUE, i);
                if (MyCharacter.id == c[i].id) {
                    MyPlayer = player;
                }
                players.Add(c[i].id, player);

            } else {
                // if (GameManager.Instance.MyCharacter.id == c[i].id) {               
                teamStatus[Const.RED].Id[i-5] = c[i].id;
                teamStatus[Const.RED].Ability[i-5] = c[i].ability;
                Player player = new Player(c[i].id, c[i].ability, Const.RED, i-5);
                 if (MyCharacter.id == c[i].id) {
                    MyPlayer = player;
                }
                players.Add(c[i].id, player);
            }            
        }        
    }

    public void PickAndBan() {
        ShowHeros();

        // TODO: AI
        // for (int i = 0; i < 10; i++) {  
        //     SelectHero();    
        // }
        // while (true) {
        //     if (turnTeam == Const.RED && turnLine == Const.SPT) {
        //         break;
        //     }
        // }
        // Simulation.Instance.StartSimulation();
    }

    private void ShowHeros() {
        GameUI.Instance.SetHeroButtons();
    }

    
    public void PickHero(Hero hero) {
        string id = teamStatus[turnTeam].Id[turnLine];
        // hero.PlayerId = teamStatus[turnTeam].Ability[turnLine].id;
        teamStatus[turnTeam].Hero[turnLine] = hero;
        players[id].Hero = hero;
        // hero.SetTexts(id);
        hero.Initialize(id);
        if (turnTeam == Const.RED) {
            hero.MoveText();
        }
        // heros.Add(hero.PlayerId, hero);
        if (turnTeam == Const.RED && turnLine == Const.SPT) {
            Debug.Log(GameSetup.Instance.PlayerPos());
            Simulation.Instance.StartSimulation();
        }
        Turn();
    }

    public Player GetPlayer(string id) {
        return players[id];
    }

    private void Turn() {
        if (turnTeam == Const.BLUE) {
            turnTeam = Const.RED;
        } else {
            turnTeam = Const.BLUE;
            turnLine += 1;
        }
        
        // Turn = turnTeam*5 + turnLine;
    }

    public int PlayerPos() {
        return turnTeam*5 + turnLine;
    }

    public void GameEnd() {
        Debug.Log("Game end!!!");
        Simulation.Instance.StopSimulation();
        Destroy(Simulation.Instance.gameObject);
        Destroy(gameObject);
        // gameObject.Destroy();
        // SceneManager.LoadScene();
    }


}