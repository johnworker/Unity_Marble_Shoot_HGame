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

        private void Awake()
        {
            StartNewTiming();
        }

        private void Update()
        {
            timer += Time.deltaTime;
        }

        public void StartNewTiming()
        {
            timerRun = true;
            timer = 0;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag("怪物"))
            {
                if (timer > timeRecycle) return;

                print(timer);
                if (timer == timeRecycle)
                {
                    gameObject.transform.position -= v3SpeedRecycle;
                

                }

            }
        }
    }

}
