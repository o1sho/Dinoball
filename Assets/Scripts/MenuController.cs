using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI maxScoreText;

    private void Start()
    {
        maxScoreText.text = Database.instance.GetMaxScore().ToString();
    }
}
