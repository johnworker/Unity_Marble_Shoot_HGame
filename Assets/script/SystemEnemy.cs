using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LEO
{
    public class SystemEnemy : MonoBehaviour
    {
        // 1.用以下功能做出敵人遠程攻擊

        /// <summary>
        /// 敵人回合
        /// </summary>
        [Header("敵人能量"), SerializeField]
        private GameObject slimePower;
        private int canShootEnemyEnergyNumber = 1;
        private float intervalEnergy = 0.3f;
        [Header("敵人能量發射速度"), Range(0, 1000)]
        public float speedEnemyEnergy = 500;
        [Header("敵人能量生成點"), SerializeField]
        private Transform traSpawnAttack;

        public GameObject target;


        /// <summary>
        /// 敵人回合攻擊
        /// </summary>
        public void EnemyTurn()
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(transform.position, transform.forward, out hitInfo))
            {
                if (hitInfo.collider.gameObject.CompareTag("Player"))
                {
                    target = hitInfo.collider.gameObject;
                }
            }
            if (target != null)
            {
                StartCoroutine(SpawnSlimeEnergy());
            }
        }

        // 史萊姆攻擊 方法
        private IEnumerator SpawnSlimeEnergy()
        {
            

            GameObject tempEnemyEnergy = Instantiate(slimePower, traSpawnAttack.position, Quaternion.identity);
            tempEnemyEnergy.GetComponent<Rigidbody>().AddForce(transform.forward * speedEnemyEnergy);

            yield return new WaitForSeconds(intervalEnergy);
            print(slimePower);
        }

    }
}