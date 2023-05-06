using System.Linq;                  // 查詢語言
using System.Collections.Generic;
using UnityEngine;

namespace LEO
{
    public class CharactorAheadRowPosition : MonoBehaviour
    {
        #region 資料
        [Header("動作格子角色前一排座標"), SerializeField]
        private Transform[] traCharatorAheadRowPlace;

        [SerializeField]
        private List<Transform> listPlayerAheadPlace = new List<Transform>();

        #endregion


        #region 事件
        void Update()
        {

        }
        #endregion

        #region 方法
        public void EnemyAniPos()
        {
            // 清單 = 陣列.轉為清單();
            listPlayerAheadPlace = traCharatorAheadRowPlace.ToString;
        }
        #endregion
    }
}