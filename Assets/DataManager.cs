using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public float playTimeCurrent = 20f;
    public float playTimeMax = 20f;

    public int stage = 0;
    public int stageView = 0;

    static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }

    public int score = 0;

    public bool PlayerDie = false; // 사망 판단

    // 자석에 사용할 변수
    public float margnetTimeCurrent = 0f;
    public float margnetTimeMax = 3f;
    public float itemMoveSpeed = 3f;
}
