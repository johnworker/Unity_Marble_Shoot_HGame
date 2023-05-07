using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace LEO{ 
public class SystemTurn : SystemFinal
{
        #region 資料
        /// <summary>
        /// 敵人回合
        /// </summary>
        public UnityEvent onTurnEnemy;

        // 需要玩家的彈珠資料
        private SystemControl systemControl;
        // 需要知道幾隻怪物在場上
        private SystemSpawn systemSpawn;
        // 需要知道回收區域
        private RecycleArea recycleArea;

        /// <summary>
        /// 彈珠總數
        /// </summary>
        private int totleCountMarble;

        /// <summary>
        /// 怪物與可以吃的彈珠存活總數
        /// </summary>
        private int totalCountEnemyLive;

        /// <summary>
        /// 回收彈珠數量
        /// </summary>
        private int totalRecycleMarble;

        private bool canSpawn = true;

        private int countMarbleEat;

        /// <summary>
        /// 層數數字
        /// </summary>
        private TextMeshProUGUI textFloorCount;
        private int countFloor = 1;

        [SerializeField, Header("當前層數的最大值"), Range(1, 100)]
        private int countFloorMax = 50;
        private bool isFloorCountMax;

        private SystemFinal systemFinal;

        /// <summary>
        /// 關卡設定
        /// </summary>
        public string nextLevel = "Level2";
        public int levelToUnlock = 2;

        private SceneFader sceneFader;

        #endregion

        private void Awake()
        {
            systemControl = GameObject.Find("陳小姐").GetComponent<SystemControl>();
            systemSpawn = GameObject.Find("生成怪物系統").GetComponent<SystemSpawn>();
            recycleArea = GameObject.Find("回收區域").GetComponent<RecycleArea>();
            textFloorCount = GameObject.Find("層數數字").GetComponent<TextMeshProUGUI>();
            

            recycleArea.onRecycle.AddListener(RecycleMarble);

            systemFinal = FindObjectOfType<SystemFinal>();
        }

        [SerializeField, Header("沒有移動物件並且延遲生成的時間"), Range(0, 3)]
        private float noMoveObjectAndDelaySpawn = 1;

        /// <summary>
        ///  回收彈珠
        /// </summary>

        public void RecycleMarble()
        {
            totleCountMarble = systemControl.canShootMarbleTotal;

            totalRecycleMarble++;
            // print("<color=yellow>彈珠回收數量：" + totalRecycleMarble + "</color>");

            if(totalRecycleMarble == totleCountMarble)
            {
                // print("回收完畢，換敵人回合");
                onTurnEnemy.Invoke();

                // 如果沒有敵人就移動結束並生成敵人與彈珠
                if(FindObjectsOfType<SystemMove>().Length == 0)
                {
                    Invoke("MoveEndSpawnEnemy", noMoveObjectAndDelaySpawn);
                }
            } 
        }
        /// <summary>
        /// 移動結束後生成敵人和彈珠
        /// </summary>
        public void MoveEndSpawnEnemy()
        {
            if (!canSpawn) return;

            if (!isFloorCountMax)
            {
                canSpawn = false;
                systemSpawn.SpawnRandomEnemy();
            }

            Invoke("PlayerTurn", 1);
        }
        /// <summary>
        /// 玩家回合
        /// </summary>
        private void PlayerTurn()
        {
            systemControl.canShootMarble = true;
            canSpawn = true;
            totalRecycleMarble = 0;

            #region 彈珠數量處理
            systemControl.canShootMarbleTotal += countMarbleEat;
            countMarbleEat = 0;
            #endregion

            if(countFloor < countFloorMax)
            { 
                countFloor++;
                textFloorCount.text = countFloor.ToString();
            }

            if (countFloor == countFloorMax) isFloorCountMax = true;

            if(isFloorCountMax)
            {
                if(FindObjectOfType<SystemMove>().Length == 0)
                {
                    systemFinal.ShowFinalAndUndateSubTitle("恭喜挑戰關卡成功!");
                }
            }
        }

        /// <summary>
        /// 移動結束號生成敵人和彈珠
        /// </summary>

        public void MarbleEat()
        {
            countMarbleEat++;
        }

        /// <summary>
        /// 關卡勝利
        /// </summary>
        public void WinLevel()
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
            sceneFader.FadeTo(nextLevel);
        }

       }

    }