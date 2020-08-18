﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    public float mapSpeed = 5f;

    public GameObject[] ItemSet;

    private void Update()
    {
        if (!DataManager.Instance.PlayerDie)
        {
            //맵 스피트 만큼 -x 축으로 이동
            transform.Translate(-mapSpeed * Time.deltaTime, 0, 0);
        }
            
    }

    private void OnEnable()
    {
        for(int temp = 0; temp < ItemSet.Length; temp++)
        {
            ItemSet[temp].SetActive(true);
        }
    }
}