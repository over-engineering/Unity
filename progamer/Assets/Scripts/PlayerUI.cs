using UnityEngine;

public class PlayerUI : MonoBehaviour 
{
    [SerializeField] private Transform[] listToEnable;
    
    private int currentState = 0;
    const int NONE = 0;
    const int PLAY = 1;
    const int TEAM = 2;
    const int TRAINING = 3;
    const int EQUIPMENT = 4;
    const int ABILITY = 5;

    public void OnClickTraining() {        
        if (currentState != NONE) {
            ActivateObjects(false);
        }
        currentState = TRAINING;
        ActivateObjects(true);
    }

    public void OnClickEquipment() {
        if (currentState != NONE) {
            ActivateObjects(false);
        }
        currentState = EQUIPMENT;
        ActivateObjects(true);
    }

    public void OnClickAbility() {
        if (currentState != NONE) {
            ActivateObjects(false);
        }
        currentState = ABILITY;
        listToEnable[ABILITY].gameObject.GetComponent<AbilityUI>().SetTexts();
        ActivateObjects(true);        
    }

    private void ActivateObjects(bool activate) {
        foreach (Transform child in listToEnable[currentState]) {
            child.gameObject.SetActive(activate);
        }    
    }
}