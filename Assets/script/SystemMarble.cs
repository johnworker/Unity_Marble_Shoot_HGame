using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace LEO
{
    /// <summary>
    /// 彈珠系統
    /// 1.長時間沒有碰到怪物就往下方回收
    /// </summary>
    public class SystemMarble : MonoBehaviour
    {
        [SerializeField, Header("怪物圖層")]
        private LayerMask layerEnemy;
        [SerializeField, Header("幾秒沒有碰到怪物要回收"), Range(0, 10)]
        private float timeRecycle = 3;
        [SerializeField, Header("回收速度")]
        private Vector3 v3SpeedRecycle;

        private float timer;
        private bool timerRun;



        /* 1.偵測彈珠是否碰撞怪物圖層的怪物
         * 2.沒有碰撞怪物多久後回收
         */

        private void OnCollisionEnter(Collision collision)
        {
            if ((layerEnemy & (1 << collision.gameObject.layer)) != 0)
            {
                // 碰到怪物不回收
                timer = 0f;
            }

            /* 第二種寫法
             * if (collision.gameObject.layer == LayerMask.NameToLayer("怪物"))
            {
                // 碰到怪物不回收
                timer = 0f;
            }
             */
        }

        private void FixedUpdate()
        {
            // 如果計時器跑動未開 則返回
            if (!timerRun) return;
            // 計時遞增
            timer += Time.fixedDeltaTime;


            if (timer >= timeRecycle)
            {
                // 回收
                transform.Translate(v3SpeedRecycle * Time.fixedDeltaTime);
                if (transform.position.z < -20f)
                {
                    gameObject.SetActive(false);
                }
            }
        }

        // 啟用程式時
        private void OnEnable()
        {
            // 計時器跑動開啟
            timerRun = true;
            // 計時歸零
            timer = 0f;
        }

        // 程式運轉結束時
        private void OnDisable()
        {
            // 計時器跑動關閉
            timerRun = false;
        }
    }

}
