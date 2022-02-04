using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI textMesh; // ancien système d'ui
    public UIDocument uiDocument; // nouveau sytème d'ui
    
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
        //textMesh.text = $"ClickCount: {value}";

        var label = uiDocument.rootVisualElement.Q<Label>();
        label.text  = $"ClickCount: {value}";
    }
}
