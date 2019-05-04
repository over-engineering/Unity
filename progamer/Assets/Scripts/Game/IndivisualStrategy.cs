using UnityEngine;

[System.Serializable]
public class IndivisualStrategy
{
    public const int ROAM = 0;
    public const int GROWTH = 1; 
    public const int EARLY = 2;
    public const int LATE = 3;

    public float[] IndStrategy;

    public void UpdateStrategy(int type, float val) {
        if (val >= 0f) {
            IndStrategy[type] = val;
            IndStrategy[type+1] = 0f;
        } else {
            IndStrategy[type] = 0f;
            IndStrategy[type+1] = -val;
        }
    }
}