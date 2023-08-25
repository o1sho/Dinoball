using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;

    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI textMaxScore;

    [DllImport("__Internal")]
    private static extern void LeaderBoard(int maxScore);

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        score = 0;
        textScore.text = "0";
        textMaxScore.text = Database.instance.GetMaxScore().ToString();
    }

    private void Update()
    {
        textScore.text = score.ToString();
        
    }

    public void ScoreUp()
    {
        score++;
        if (score > Database.instance.GetMaxScore()) 
        {
            Database.instance.SetMaxScore(score);
            textMaxScore.text = Database.instance.GetMaxScore().ToString();
#if !UNITY_EDITOR && UNITY_WEBGL
            LeaderBoard(Database.instance.GetMaxScore());
#endif
            Database.instance.SaveGameData();
        } 
        
    }


}
