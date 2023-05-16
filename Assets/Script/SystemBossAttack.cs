using System.Collections;
using UnityEngine;

namespace LEO
{
    public class SystemBossAttack : MonoBehaviour
    {
        // 遠程攻擊的投射物預製體
        public GameObject projectilePrefab;
        // 遠程攻擊的起始位置
        public Transform attackPoint;
        // 投射物的速度
        public float projectileSpeed = 10f;
        // 遠程攻擊的間隔時間
        public float attackInterval = 2f;
        // 控制是否可以進行遠程攻擊
        private bool canAttack = true; 

        private void Start()
        {
            // 在 Start 方法中啟動遠程攻擊協程
            StartCoroutine(BossAttackCoroutine());
        }

        private IEnumerator BossAttackCoroutine()
        {
            while (true)
            {
                if (canAttack)
                {
                    // 創建投射物
                    GameObject projectile = Instantiate(projectilePrefab, attackPoint.position, Quaternion.identity);

                    // 設置投射物的速度和方向
                    Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
                    projectileRb.velocity = transform.right * projectileSpeed;

                    // 等待攻擊間隔時間
                    yield return new WaitForSeconds(attackInterval);
                }
                else
                {
                    yield return null;
                }
            }
        }
    }
}