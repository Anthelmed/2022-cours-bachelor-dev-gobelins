using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    
    private void OnEnable()
    {
        Scene.ClickCountChangeEvent += OnClickCountChanged; // Pareil que AddEventListener
    }
    
    private void OnDisable()
    {
        Scene.ClickCountChangeEvent -= OnClickCountChanged;
    }
    
    private void OnClickCountChanged(int value)
    {
        textMesh.text = $"ClickCount: {value}";
    }
}
