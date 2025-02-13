using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace LEO{ 
public class SystemTurn : SystemFinal
{
        #region 資料

        // 需要玩家的彈珠資料
        private SystemControl systemControl;
        // 需要知道幾隻怪物在場上
        private SystemSpawn systemSpawn;
        // 需要知道回收區域
        private RecycleArea recycleArea;

        public UnityEvent onTurnEnemy;

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

        private SystemEnemy systemEnemy;

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
          

                // 抓取魔王遠程攻擊

                // 1.抓取SystemEnemy.cs裡的 EnemyTurn() 並執行
                // 呼叫 EnemyTurn() 方法
                // FindObjectOfType<SystemEnemy>().EnemyTurn();

                // 如果沒有敵人就移動結束並生成敵人與彈珠
                if (FindObjectsOfType<SystemMove>().Length == 0)
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

                // **當第10回合時，生成魔王**
                if (countFloor == 10)
                {
                    systemSpawn.SpawnRandomBoss();
                }
            }

            if (countFloor == countFloorMax) isFloorCountMax = true;

            // 玩家抵達最終樓層且偵測格子沒有怪才獲勝
            if (isFloorCountMax)
            {
                // 沒有怪物和魔王就勝利
                if (AreAllGridsEmpty())
                {
                    systemFinal.ShowFinalAndUndateSubTitle("恭喜挑戰關卡成功!");
                }
            }
        }

        // 檢查所有格子是否沒有怪物
        private bool AreAllGridsEmpty()
        {
            SystemMove[] gridObjects = FindObjectsOfType<SystemMove>();

            foreach (SystemMove gridObject in gridObjects)
            {
                if (gridObject.HasEnemy())
                {
                    return false; // **如果還有怪物，不能獲勝**
                }
            }

            // **確認魔王數量是否為 0**
            if (systemSpawn.totalBossAlive > 0)
            {
                return false; // **如果還有魔王，不能獲勝**
            }

            return true; // **所有敵人和魔王都消失時，才可以獲勝**
        }


        /// <summary>
        /// 移動結束號生成敵人和彈珠
        /// </summary>

        public void MarbleEat()
        {
            countMarbleEat++;
        }

    }

}