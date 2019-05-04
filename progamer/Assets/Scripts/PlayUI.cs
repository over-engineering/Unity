using UnityEngine;

public class PlayUI : MonoBehaviour
{
   public void OnClick() {
       GameManager.Instance.LoadGame();
   }
}
