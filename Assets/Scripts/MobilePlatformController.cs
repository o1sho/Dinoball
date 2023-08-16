using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatformController : MonoBehaviour
{
    public static MobilePlatformController instance { get; private set; }

    [SerializeField] private GameObject inputButtonLeft;
    [SerializeField] private GameObject inputButtonRight;

    public float resultInput;


    private void Awake()
    {
        instance= this;

        if (Application.isMobilePlatform)
        {
            inputButtonLeft.SetActive(true);
            inputButtonRight.SetActive(true);
        }
        else
        {
            inputButtonLeft.SetActive(false);
            inputButtonRight.SetActive(false);
        }
    }



    public void DownInputButton(int side)
    {
        if (side == -1)
        {
            resultInput = -1;
        } 
        else if (side == 1) 
        {
            resultInput = 1;
        }
        else if (side == 0)
        {
            resultInput = 0;
        }
    }

}
