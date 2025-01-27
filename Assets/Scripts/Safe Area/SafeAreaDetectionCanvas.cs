using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeAreaDetectionCanvas : MonoBehaviour
{
    public delegate void SafeAreaChanged(Rect safeArea);
    public static event SafeAreaChanged onSafeAreaChanged;

    private Rect _safeArea;

    private void Awake()
    {
        _safeArea = Screen.safeArea;
    }

    private void Update()
    {
        if (_safeArea != Screen.safeArea)
        {
            _safeArea = Screen.safeArea;
            onSafeAreaChanged?.Invoke(_safeArea);
        }
    }
}
