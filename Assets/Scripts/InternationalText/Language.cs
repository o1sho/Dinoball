using System.Runtime.InteropServices;
using UnityEngine;

public class Language : MonoBehaviour
{
    public static Language instance { get; private set; }

    public string currentLanguage;

    [DllImport("__Internal")]
    private static extern string GetLang();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

#if !UNITY_EDITOR && UNITY_WEBGL
            currentLanguage = GetLang();
#endif
        }
        else
        {
            Destroy(gameObject);
        }
    }
}