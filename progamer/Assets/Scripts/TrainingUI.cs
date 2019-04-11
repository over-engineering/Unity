using UnityEngine;

public class TrainingUI : MonoBehaviour
{

    [SerializeField] private AbilityUI AUI;

    public void OnClickTraining() {
        // string body = "";
        // GameManager.Instance.rest.Post("/api/training", "TakeTraining", body);
        TakeTrainingFromServer("training0", "5", "5");
    }

    public void OnClickExit() {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);
        }    
    }

    public void TakeTrainingFromServer(string trainingId, string level, string time) {
        Debug.Log("TakeTrainingFromServer");
        string chracterId = GameManager.Instance.CharacterId;        
        StartCoroutine(RestClient.Instance.Get(RestClient.ProgamerBaseURL, "/api/training/" + chracterId + "/" + trainingId + "/" + level + "/" + time + "/" + "1", AUI.SetAbility));
    }
}
