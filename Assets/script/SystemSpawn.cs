using UnityEngine;
using System.Collections.Generic;   // ��Ƶ��c �M�� List
using System.Linq;                  // �d�߻y��

namespace LEO
{
    /// <summary>
    /// �ͦ��Ǫ��t��
    /// </summary>
    public class SystemSpawn : MonoBehaviour
    {
        #region ���
        // [] �}�C
        // SerializeField �N�p�H������
        [Header("�Ǫ��}�C"), SerializeField]
        private GameObject[] goEnemys;
        [Header("�ͦ���l�ĤG�Ʈy��"), SerializeField]
        private Transform[] traSecondPlace;

        [SerializeField]
        private List<Transform> listSecondPlace = new List<Transform>();

        /// <summary>
        /// �Ǫ��P�i�H�Y���u�]�s���`��
        /// </summary>
        public int totalCountEnemyLive;

        #endregion

        #region �ƥ�
        private void Awake()
        {
            SpawnRandomEnemy();
        }
        #endregion

        #region ��k
        /// <summary>
        /// �ͦ��H���ĤH
        /// </summary>
        public void SpawnRandomEnemy()
        {
            int min = 2;
            int max = traSecondPlace.Length;

            int randomCount = Random.Range(min, max);
            // print("�H���Ǫ��ƶq�G" + randomCount);

            // �M�� = �}�C.�ର�M��();
            listSecondPlace = traSecondPlace.ToList();

            // �H������
            System.Random random = new System.Random();
            // �M�� = �M�� �� �Ƨ�(�C�ӲM�椺�e => �H���Ƨ�) �ର�M��
            listSecondPlace = listSecondPlace.OrderBy(x => random.Next()).ToList();

            int sub = traSecondPlace.Length - randomCount;
            // print("�n�������ƶq�G" + sub);

            // �j�� �R�� �n�������ƶq
            for (int i = 0; i < sub; i++)
            {
                // �R���Ĥ@�ӲM����
                listSecondPlace.RemoveAt(0);
            }

            // �ͦ��Ҧ��Ǫ��P�u�]�@��
            for (int i = 0; i < listSecondPlace.Count; i++)
            {
                // �p�G i ���� 0 �ͦ��u�]
                if (i == 0)
                {
                    Instantiate(
                    goMarble,
                    listSecondPlace[i].position,
                    Quaternion.identity);
                }
                else
                {
                    // �H���Ǫ�
                    int randomIndex = Random.Range(0, goEnemys.Length);
                    // �ͦ��Ǫ�
                    Instantiate(
                        goEnemys[randomIndex],
                        listSecondPlace[i].position,
                        Quaternion.identity);
                }

                totalCountEnemyLive++;
                // print("�Ǫ��P�u�]�ƶq" + totalCountEnemyLive);
            }
        }
        #endregion

        [Header("��l �u�]"), SerializeField]
        private GameObject goMarble;
    }
}