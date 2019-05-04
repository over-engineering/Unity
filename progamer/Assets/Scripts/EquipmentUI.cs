using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipmentUI : MonoBehaviour
{    
    [SerializeField] private Button[] ownedButtons;
    [SerializeField] private Button[] equippedButtons;
    [SerializeField] private Equipment[] ownedList;
    [SerializeField] private Equipment[] equippedList;

    void Start() {
        equippedList = new Equipment[equippedButtons.Length];
    }

    public void Setup(Equipment[] owned) {
        // ownedList = owned;
        for (int i = 0; i < ownedList.Length; i++) {
            if (ownedButtons[i] == null) {
                return;
            }
            ownedButtons[i].gameObject.SetActive(true);
            ownedButtons[i].transform.GetChild(0).GetComponent<Text>().text = ownedList[i].name;
        }
        
        // this.equipments = new Equipment[equipments.Length];
        // for (int i = 0; i < equipments.Length; i++) {
        //     this.equipments[i] = equipments[i];
        //     equipmentButtons[i].onClick.AddListener(OnClickEquip);
        // }
    }

    public void OnClickEquip() {
        int index = EventSystem.current.currentSelectedGameObject.transform.GetSiblingIndex();
        Debug.Log("OnClickEquip!!! " + index);
        Equipment equipment = ownedList[index];
        if (equipment == null) {
            return;
        }

        if (equippedList[equipment.equipment_type] != null) {
            equippedList[equipment.equipment_type].UnEquip();
        }
        
        equipment.Equip();
        equippedList[equipment.equipment_type] = equipment;
        GameManager.Instance.MyCharacter.equipments = equippedList;
        equippedButtons[equipment.equipment_type].transform.GetChild(0).GetComponent<Text>().text = equipment.name;
        // Api.EquipEquipment(equipments[index].id);
        Api.Equipment();
    }

    public void OnClickUnEquip() {
        int index = EventSystem.current.currentSelectedGameObject.transform.GetSiblingIndex();
        Debug.Log("OnClickUnEquip!!! " + index);
        Equipment equipment = equippedList[index];
        if (equipment == null) {
            return;
        }

        equipment.UnEquip();
        equippedList[index] = null;
        GameManager.Instance.MyCharacter.equipments = equippedList;
        equippedButtons[index].transform.GetChild(0).GetComponent<Text>().text = "";
        Api.Equipment();
    }

    

}