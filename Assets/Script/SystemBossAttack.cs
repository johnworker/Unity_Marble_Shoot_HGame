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
        private bool canAttack = false;

        private void Start()
        {
            // 在 Start 方法中啟動遠程攻擊協程
            StartCoroutine(BossAttackCoroutine());
        }

        // 需把玩家作為攻擊目標而且敵人回合才攻擊一次

        public IEnumerator BossAttackCoroutine()
        {
            while (true)
            {
                if (canAttack)
                {
                    // 創建投射物
                    GameObject projectile = Instantiate(projectilePrefab, attackPoint.position, Quaternion.identity);

                    // 設置投射物的速度和方向
                    Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
                    projectileRb.velocity = transform.right * projectileSpeed;

                    // 找到玩家物件
                    GameObject player = GameObject.FindWithTag("Player");

                    // 如果找到玩家物件，將魔王的攻擊目標設定為玩家的位置
                    if (player != null)
                    {
                        Vector3 playerPosition = player.transform.position;
                        playerPosition.z = transform.position.z;
                        Vector3 direction = (playerPosition - attackPoint.position).normalized;
                        projectile.GetComponent<Rigidbody>().velocity = direction * projectileSpeed;
                        // 3D能量球須往玩家攻擊
                    }

                    // 等待攻擊間隔時間
                    yield return new WaitForSeconds(attackInterval);

                    // 敵人攻擊完後結束攻擊回合
                    canAttack = false;
                }
                else
                {
                    yield return null;
                }
            }
        }

        public void StartBossAttack()
        {
            // 在敵人回合開始時呼叫這個方法，開始魔王的攻擊回合
            canAttack = true;
        }
    }
}