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

        private float moveDistance = -20;


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

                print(timer);
                if (timer == timeRecycle)
                {
                    StartCoroutine(Move());
                }

            }

        }

        private IEnumerator Move()
        {
            //print(gameObject + "往前移動");
            float moveCount = 10;
            float perDistance = moveDistance / moveCount;

            for (int i = 0; i < moveCount; i++)
            {
                transform.position -= new Vector3(0, 0, perDistance);

            }

            yield return new WaitForSeconds(0.1f);


        }
    }

}
