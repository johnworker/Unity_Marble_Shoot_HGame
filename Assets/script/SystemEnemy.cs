using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LEO
{
    public class SystemEnemy : MonoBehaviour
    {
        /// <summary>
        /// �ĤH�^�X
        /// </summary>
        [Header("�ĤH��q"), SerializeField]
        private GameObject slimePower;
        private int canShootEnemyEnergyNumber = 1;
        private float intervalEnergy = 0.3f;
        [Header("�ĤH��q�o�g�t��"), Range(0, 1000)]
        public float speedEnemyEnergy = 500;
        [Header("�ĤH��q�ͦ��I"), SerializeField]
        private Transform traSpawnAttack;

        public GameObject target;


        /// <summary>
        /// �ĤH�^�X����
        /// </summary>
        private void EnemyTurn()
        {
            spawnSlimeEnergy();
        }

        // �v�ܩi���� ��k
        private IEnumerator spawnSlimeEnergy()
        {
            

            GameObject tempEnemyEnergy = Instantiate(slimePower, traSpawnAttack.position, Quaternion.identity);
            tempEnemyEnergy.GetComponent<Rigidbody>().AddForce(transform.forward * speedEnemyEnergy);

            yield return new WaitForSeconds(intervalEnergy);
            print(slimePower);
        }

    }
}