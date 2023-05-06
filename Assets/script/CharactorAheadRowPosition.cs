using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Linq;

namespace LEO
{
    public class CharactorAheadRowPosition : MonoBehaviour
    {
        #region 資料
        [Header("動作格子角色前一排座標"), SerializeField]
        private Transform[] traCharatorAheadRowPlace;

        public GameObject[] aheadEnemy;

        [SerializeField, Header("敵人動畫控制")]
        private Animator aniEnemy;
        private string parDamage = "觸發受傷";

        #endregion


        #region 事件
        private void Awake()
        {
            traCharatorAheadRowPlace = GetComponent<Transform[]>();
        }

        void Update()
        {

        }
        #endregion

        #region 方法
        /// <summary>
        /// 敵人到玩家面前播攻擊動畫
        /// </summary>
        public void EnemyAniPos()
        {
            int range = traCharatorAheadRowPlace.Length;

            // 清單 = 陣列.轉為清單();
            // listPlayerPlace = traCharatorAheadRowPlace.ToList();

            if(aheadEnemy.Length != 0 && range != 0)
            {
                aniEnemy.SetBool(parDamage,true);
            }
            else
            {
                aniEnemy.SetBool(parDamage, false);
            }
        }

        #endregion
    }
}