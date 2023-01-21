using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class  Gold : MonoBehaviour
{
    private TMP_Text textMesh;

    private void Awake()
    {
        textMesh = GetComponent<TMP_Text>();        
        textMesh.SetText("Gold: 0");
    }

    public void UpdateGold(int gold)
    {
        if (textMesh == null) return;
        textMesh.SetText($"Gold: {gold}");
    }
}