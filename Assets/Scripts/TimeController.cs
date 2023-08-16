using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController instance { get; private set; }

    public float gameSpeed;
    public float speedIncrease;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }

    private void Update()
    {
        gameSpeed += speedIncrease * Time.deltaTime;
    }

    public void SetDefaulttGameSpeed()
    {
        gameSpeed = 6f;
    }
}
