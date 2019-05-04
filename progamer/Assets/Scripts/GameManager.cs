using UnityEngine;
using UnityEngine.SceneManagement;
// using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
     
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } 
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // public string MyCharacterId = "MyCharacter0";
    string userId = "ParkChan";
    public Character MyCharacter;
    [SerializeField] private AbilityUI abilityUI;
    [SerializeField] private TrainingUI trainingUI;
    [SerializeField] private EquipmentUI equipmentUI;

    void Start()
    {
        Login();
    }

    void Update()
    {
        
    }

    private void Login() {
        bool success = true;        
        if(success) {
            Setup();
        } else {

        }
    }

    private void Setup() {
        Api.GetChracter(userId);
        // Api.GetTrainings();
        // Api.GetEquipments();
    }

    public void SetCharacter(Character c) {
        MyCharacter = c;
        SetAbility(MyCharacter.ability);
        SetEquipments(MyCharacter.equipments);
        Debug.Log("SetMyCharacter " + MyCharacter);
    }

    public void SetAbility(Ability ability) {
        Debug.Log("SetAbility " + ability);
        MyCharacter.ability = ability;
        abilityUI.Setup(ability);
    }

    public void SetEquipments(Equipment[] equipments) {
        Debug.Log("SetEquipments " + equipments);
        MyCharacter.equipments = equipments;
        equipmentUI.Setup(equipments);
    }

    public void SetTrainings(Trainings trainings) {
        Debug.Log("SetTrainings " + trainings);
        trainingUI.Setup(trainings.trainings);
        // trainingUI.SetupTrainings(trainings);
    }

    public Equipment[] GetEquipments() {
        if (MyCharacter == null) {
            Api.GetChracter(userId);
        }
        return MyCharacter.equipments;
    }

    public Ability GetAbility() {
        if (MyCharacter == null) {
            // GetChracterFromServer(userId);
            Api.GetChracter(userId);
        }
        return MyCharacter.ability;
    }

    public void LoadGame() {
        SceneManager.LoadScene("GameScene");
    }

    // public void SetAbility(Ability a) {
    //     if (MyCharacter == null) {
    //         Api.GetChracter(userId);
    //     }
    //     Debug.Log("SetAbility " + a);
    //     MyCharacter.ability = a;
    // }

    

    

}
