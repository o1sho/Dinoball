using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ShowYandexAdvGameOver : MonoBehaviour
{
    //ADV Yandex
    [DllImport("__Internal")]
    private static extern void ShowAdv();

    private void OnEnable()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        ShowAdv();
#endif
    }
}
