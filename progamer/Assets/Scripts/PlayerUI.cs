using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class PlayerUI : MonoBehaviour 
{
    [SerializeField] private List<GameObject> listToEnable;    
    private int currentState = 0;
    void Start() {
        Transform buttonChild = transform.GetChild(0);
        foreach (Transform childButton in buttonChild.transform) {
            childButton.gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
        }    
        
        Transform goChild = transform.GetChild(1);
        foreach (Transform child in goChild.transform) {
            listToEnable.Add(child.gameObject);
        }
        
        listToEnable[currentState].SetActive(true);
    }

    public void OnClick() {
        listToEnable[currentState].SetActive(false);   
        currentState = EventSystem.current.currentSelectedGameObject.transform.GetSiblingIndex();
        listToEnable[currentState].SetActive(true);   
    }
}