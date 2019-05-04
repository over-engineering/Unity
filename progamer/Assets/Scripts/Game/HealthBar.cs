using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image foregroundImage;
    [SerializeField] private Text text;
    [SerializeField] private float updateSpeedSeconds = 0.5f;

    public void SetHealth(int point, int maxHealth) {
        HandleHealthChanged(point, maxHealth);
    }

    public void HandleHealthChanged(int point, int maxHealth) {
        text.text = point + " / " + maxHealth;
        float pct = (float) point / maxHealth;
        // Debug.Log("HandleHealthChanged!!! " + pct);
        StartCoroutine(ChangeToPct(pct));
    }

    public IEnumerator ChangeToPct(float pct) {
        // float preChangePct = foregroundImage.rectTransform.localScale.x;
        float preChangePct = foregroundImage.fillAmount;
        float elapsed = 0f;

        // Debug.Log("ChangeToPct!!! " + elapsed);
        while (elapsed < updateSpeedSeconds) {
            elapsed += Time.deltaTime;
            foregroundImage.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
            yield return null;
        }

        foregroundImage.fillAmount = pct;
    }
}
