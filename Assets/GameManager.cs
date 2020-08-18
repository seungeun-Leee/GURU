using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] NumberImage;
    public Sprite[] Number;
    public GameObject[] StageMap;
    public GameObject LoadMap;
    public Text StageText;
    /*
    public GameObject BG_1;
    public GameObject BG_2;
    bool BG_flag = false;       //배경 바꾸기
    */
    public Image TimeBar;

    public void Restart_Btu()
    {
        DataManager.Instance.stage = 0;
        DataManager.Instance.stageView = 0;
        DataManager.Instance.score = 0;
        DataManager.Instance.PlayerDie = false;
        DataManager.Instance.playTimeCurrent = DataManager.Instance.playTimeMax;
        DataManager.Instance.margnetTimeCurrent = 0;

        SceneManager.LoadScene("SampleScene");
    }

    public void Next_Stage()
    {
        /*
        //배경 바꾸기
        if (!BG_flag)
        {
            BG_1.SetActive(true);
            BG_2.SetActive(false);
            BG_flag = true;
        }

        else
        {
            BG_1.SetActive(false);
            BG_2.SetActive(true);
            BG_flag = false;
        }
        */
        DataManager.Instance.stage += 1;
        DataManager.Instance.stageView += 1;
        
        if (DataManager.Instance.stage > StageMap.Length)
        {
            DataManager.Instance.stage = DataManager.Instance.stage % StageMap.Length;
            if (DataManager.Instance.stage == 0)
            {
                DataManager.Instance.stage = StageMap.Length;
            }
        }
        StageStart();
    }

    public void StageStart()
    {
        for (int temp = 1; temp <= StageMap.Length; temp++)
        {
            if (temp == DataManager.Instance.stage)
            {
                StageMap[temp - 1].transform.position = new Vector3(15f, StageMap[temp - 1].transform.position.y, StageMap[temp - 1].transform.position.z);
                StageMap[temp - 1].SetActive(true);
            }
            else
            {
                StageMap[temp - 1].SetActive(false);
            }
        }
    }

    public void Load_Map()
    {
        LoadMap.transform.position = new Vector3(15f, LoadMap.transform.position.y, LoadMap.transform.position.z);
        LoadMap.SetActive(true);
    }

    public GameObject EndPanel;

    private void Update()
    {
        if (DataManager.Instance.stageView == 0)
        {
            StageText.text = "START";
        }
        else
            StageText.text = "Stage " + DataManager.Instance.stageView.ToString();

        int temp2 = DataManager.Instance.score % 1000;

        temp2 = temp2 / 100;
        NumberImage[0].GetComponent<Image>().sprite = Number[temp2];

        int temp3 = DataManager.Instance.score % 100;

        temp3 = temp3 / 10;
        NumberImage[1].GetComponent<Image>().sprite = Number[temp3];

        int temp4 = DataManager.Instance.score % 10;
        NumberImage[2].GetComponent<Image>().sprite = Number[temp4];

        if (!DataManager.Instance.PlayerDie)
        {
            DataManager.Instance.playTimeCurrent -= 1 * Time.deltaTime;

            TimeBar.fillAmount = DataManager.Instance.playTimeCurrent / DataManager.Instance.playTimeMax;

            if (DataManager.Instance.playTimeCurrent < 0)
            {
                DataManager.Instance.PlayerDie = true;
            }

            if (DataManager.Instance.margnetTimeCurrent > 0)
            {
                DataManager.Instance.margnetTimeCurrent -= 1 * Time.deltaTime;
            }
        }

        if (DataManager.Instance.PlayerDie == true)
        {
            EndPanel.SetActive(true);
        }
    }
}
