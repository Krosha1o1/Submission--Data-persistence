using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public string playerName;
    public int playerScore;
    private void Awake()
    {
        if(Instance!=null)
        {
            Destroy(gameObject);
            }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public string UpdateData()
    {
        return "Best Score: " + playerName + " : " + playerScore;
    }
}
