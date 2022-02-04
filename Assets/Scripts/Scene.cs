using System;
using UnityEngine;

public static class Scene
{
    private static int _clickCount;

    public static event Action<int> ClickCountChangeEvent;
    
    public static void IncrementClickCount()
    {
        _clickCount++;
        
        ClickCountChangeEvent?.Invoke(_clickCount);

        /* Pareil que
        if (ClickCountChangeEvent != null)
            ClickCountChangeEvent(_clickCount);
            */
    }

    public static void ResetClickCount()
    {
        _clickCount = 0;
        
        ClickCountChangeEvent?.Invoke(_clickCount);
    }
}
