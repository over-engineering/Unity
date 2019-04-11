using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    public void OnEquip() {

    }

    public void OnClickExit() {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);
        }    
    }

}