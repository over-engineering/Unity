using UnityEngine;
using Models;
using Proyecto26;
using Newtonsoft.Json;




public static class Api
{
    const string COMMON_ROUTE = "http://localhost:8080"; 
    const string PROGAMER_ROUTE = "http://localhost:8082"; 
    
    private static RequestHelper currentRequest;

    public static void GetChracter(string userId) {
        Debug.Log("GetCharacter!!!");
        RequestHelper requestOptions = new RequestHelper {
            Uri = PROGAMER_ROUTE + "/api/character/" + userId,
            // Headers = new Dictionary<string, string> {
            //     { "Content-Type", "application/json" }
            // },
            EnableDebug = true
        };

        RestClient.Get<Character>(requestOptions).Then( res => {
            // Debug.Log(JsonUtility.ToJson(res, true));
            // Debug.Log(JsonUtility.FromJson<Character>(JsonUtility.ToJson(res, true)));
            GameManager.Instance.SetCharacter(JsonUtility.FromJson<Character>(JsonUtility.ToJson(res, true)));
        }).Catch(err => Debug.Log(err.Message));
    }

    public static void UpdateAbility(Ability ability) {
        string chracterId = GameManager.Instance.MyCharacter.id;        

    }

    public static void GetTrainings() {
        Debug.Log("GetTrainings!!!");
        RequestHelper requestOptions = new RequestHelper {
            Uri = PROGAMER_ROUTE + "/api/trainings",
            EnableDebug = true
        };
        
        RestClient.Get(requestOptions).Then( res => {
            GameManager.Instance.SetTrainings(JsonConvert.DeserializeObject<Trainings>(res.Text));
        }).Catch(err => Debug.Log(err.Message));
    }

    // public static void GetEquipments() {
    //     Debug.Log("GetEquipments!!!");
    //     string characterId = GameManager.Instance.Character.id;
    //     RequestHelper requestOptions = new RequestHelper {
    //         Uri = PROGAMER_ROUTE + "/api/equipments/" + characterId,
    //         EnableDebug = true
    //     };
        
    //     RestClient.Get(requestOptions).Then( res => {
    //         GameManager.Instance.SetEquipments(JsonConvert.DeserializeObject<Equipments>(res.Text));
    //     }).Catch(err => Debug.Log(err.Message));   
    // }

    public static void TakeTraining(string trainingId, string level, string time) {
        Debug.Log("TakeTraining");
        string chracterId = GameManager.Instance.MyCharacter.id;        
        RequestHelper requestOptions = new RequestHelper {
            Uri = PROGAMER_ROUTE + "/api/training/" + chracterId + "/" + trainingId + "/" + level + "/" + time + "/" + "1",
            EnableDebug = true      
        };

        RestClient.Get<Ability>(requestOptions).Then( res => {
            GameManager.Instance.SetAbility(JsonUtility.FromJson<Ability>(JsonUtility.ToJson(res, true)));
        }).Catch(err => Debug.Log(err.Message));
    }

    public static void Equipment() {

    }

    public static void AddEquipment(string equipmentId) {
        Debug.Log("AddEquipment!!!");
        string chracterId = GameManager.Instance.MyCharacter.id;        
        RequestHelper requestOptions = new RequestHelper {
            Uri = PROGAMER_ROUTE + "/api/equipment/" + chracterId + "/" + equipmentId,
            EnableDebug = true      
        };

        RestClient.Get<Equipment[]>(requestOptions).Then( res => {
            GameManager.Instance.SetEquipments(JsonUtility.FromJson<Equipment[]>(JsonUtility.ToJson(res, true)));
        }).Catch(err => Debug.Log(err.Message));      
    }

    public static void EquipEquipment(string equipmentId) {
        Debug.Log("EquipEquipment");
        string chracterId = GameManager.Instance.MyCharacter.id;        
        RequestHelper requestOptions = new RequestHelper {
            Uri = PROGAMER_ROUTE + "/api/equipment/" + chracterId + "/" + equipmentId,
            EnableDebug = true      
        };

        RestClient.Get<Ability>(requestOptions).Then( res => {
            GameManager.Instance.SetAbility(JsonUtility.FromJson<Ability>(JsonUtility.ToJson(res, true)));
        }).Catch(err => Debug.Log(err.Message));   
    }
}