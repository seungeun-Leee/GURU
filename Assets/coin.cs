﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public GameObject player;

    public Vector3 OB_base_location;
    private void Awake()
    {
        //초기 위치를 시작하자마자 저장
        OB_base_location = gameObject.transform.localPosition;
    }
    public void OnEnable()
    {
        //OnEnable은 오브젝트가 활성화되는 경우에 호출
        //게임 오브젝트의 현재 위치를 초기 위치로
        gameObject.transform.localPosition = OB_base_location;
    }


    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector2.Distance(gameObject.transform.position, player.transform.position);

        if (DataManager.Instance.PlayerDie == false && DataManager.Instance.margnetTimeCurrent > 0)
        {
            if (distance < 6)
            {
                Vector2 dir = player.transform.position - transform.position;

                transform.Translate(dir.normalized * DataManager.Instance.itemMoveSpeed * Time.deltaTime, Space.World);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Player") == 0)
        {
            DataManager.Instance.score += 1;

            gameObject.SetActive(false);
        }
    }

}
