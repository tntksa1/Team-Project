using UnityEngine;
using TMPro;
using System;

public class GearUI : MonoBehaviour
{
    public TMP_Text text;
    public static Action<int, int> RefreshStatic; 

    void OnEnable() { RefreshStatic += Refresh; }
    void OnDisable() { RefreshStatic -= Refresh; }

    void Start()
    {
        var gm = GearsManager.I;
        if (gm != null)
            Refresh(gm.totalCollected, gm.totalGoal);
    }

    public void Refresh(int total, int totalGoal)
    {
        text.text = $"Gears {total}/{totalGoal}";
    }
}
