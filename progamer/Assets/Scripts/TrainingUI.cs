using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TrainingUI : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private Training[] trainings;
    // private Training[] trainings;

    void Start() {
        for (int i = 0; i < buttons.Length; i++) {            
            buttons[i].onClick.AddListener(OnClickTraining);
        }
    }

    public void OnClick() {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(true);
        }    
    }

    public void Setup(Training[] trainings) {
        this.trainings = new Training[trainings.Length];
        for (int i = 0; i < trainings.Length; i++) {            
            this.trainings[i] = trainings[i];
            // buttons[i].gameObject.GetComponent<Training>().SetTraining(training.id, training.target_ability);            
            buttons[i].onClick.AddListener(OnClickTraining);
        }
    }

    public void OnClickTraining() {
        int index = EventSystem.current.currentSelectedGameObject.transform.GetSiblingIndex();
        trainings[index].TakeTraining(5, 3f, 0.8f);
        // Api.TakeTraining(trainings[index].id, "5", "1");
    }

    // public void OnClickExit() {
    //     foreach (Transform child in transform) {
    //         child.gameObject.SetActive(false);
    //     }    
    // }    
}
