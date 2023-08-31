using TMPro;
using UnityEngine;

public class InternationalText : MonoBehaviour
{
    [SerializeField] private string _ru;
    [SerializeField] private string _en;
    //[SerializeField] private string _tr;

    private void Start()
    {
        switch (Language.instance.currentLanguage)
        {
            case "ru":
                GetComponent<TextMeshProUGUI>().text = _ru;
                break;
            case "en":
                GetComponent<TextMeshProUGUI>().text = _en;
                break;
            /*
            case "tr":
                GetComponent<TextMeshProUGUI>().text = _tr;
                break;
            */
            default: break;
        }
    }
}
