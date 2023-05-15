using UnityEngine;
using System.Collections.Generic;   // 資料結構 清單 List
using System.Linq;                  // 查詢語言

namespace LEO
{
    /// <summary>
    /// 生成怪物系統
    /// </summary>
    public class SystemSpawn : MonoBehaviour
    {
        #region 資料
        // [] 陣列
        // SerializeField 將私人欄位顯示
        [Header("怪物陣列"), SerializeField]
        public GameObject[] goEnemys;
        [Header("生成格子第三排座標"), SerializeField]
        private Transform[] traThirdPlace;
        [Header("魔王陣列"), SerializeField]
        public GameObject[] moveBoss;
        [Header("生成格子第一排座標"), SerializeField]
        private Transform[] traFirstPlace;

        [SerializeField]
        private List<Transform> listThirdPlace = new List<Transform>();

        /// <summary>
        /// 怪物與可以吃的彈珠存活總數
        /// </summary>
        public int totalCountEnemyLive;

        [Header("格子 彈珠"), SerializeField]
        private GameObject goMarble;


        #endregion

        #region 事件
        private void Awake()
        {
            SpawnRandomEnemy();
            SpawnRandomBoss();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 生成隨機敵人
        /// </summary>
        public void SpawnRandomEnemy()
        {
            int min = 2;
            int max = traThirdPlace.Length;

            int randomCount = Random.Range(min, max);
            // print("隨機怪物數量：" + randomCount);

            // 清單 = 陣列.轉為清單();
            listThirdPlace = traThirdPlace.ToList();

            // 隨機物件
            System.Random random = new System.Random();
            // 清單 = 清單 的 排序(每個清單內容 => 隨機排序) 轉為清單
            listThirdPlace = listThirdPlace.OrderBy(x => random.Next()).ToList();

            int sub = traThirdPlace.Length - randomCount;
            // print("要扣除的數量：" + sub);

            // 迴圈 刪除 要扣掉的數量
            for (int i = 0; i < sub; i++)
            {
                // 刪除第一個清單資料
                listThirdPlace.RemoveAt(0);
            }

            // 生成所有怪物與彈珠一顆
            for (int i = 0; i < listThirdPlace.Count; i++)
            {
                // 如果 i 等於 0 生成彈珠
                if (i == 0)
                {
                    Instantiate(
                    goMarble,
                    listThirdPlace[i].position,
                    Quaternion.identity);
                }
                else
                {
                    // 隨機怪物
                    int randomIndex = Random.Range(0, goEnemys.Length);
                    // 生成怪物
                    Instantiate(
                        goEnemys[randomIndex],
                        listThirdPlace[i].position,
                        Quaternion.identity);
                }

                totalCountEnemyLive++;
                // print("怪物與彈珠數量" + totalCountEnemyLive);
            }


        }

        /// <summary>
        /// 生成隨機魔王
        /// </summary>
        public void SpawnRandomBoss()
        {
            // 只生成一次 魔王陣列3種 和 第一排3個格子座標   只生成一個魔王

            // 隨機選擇魔王陣列中的一個索引
            int randomIndex = Random.Range(0, moveBoss.Length);

            // 隨機選擇第一排格子的索引
            int randomPlaceIndex = Random.Range(0, traFirstPlace.Length);

            // 在隨機選擇的第一排格子座標上生成隨機的魔王
            Instantiate(moveBoss[randomIndex], traFirstPlace[randomPlaceIndex].position, Quaternion.identity); 
        }
        #endregion
    }
}