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
        public GameObject[] goEnemys;
        [Header("�ͦ���l�ĤT�Ʈy��"), SerializeField]
        private Transform[] traThirdPlace;
        [Header("�]���}�C"), SerializeField]
        public GameObject[] moveBoss;
        [Header("�ͦ���l�Ĥ@�Ʈy��"), SerializeField]
        private Transform[] traFirstPlace;

        [SerializeField]
        private List<Transform> listThirdPlace = new List<Transform>();

        /// <summary>
        /// �Ǫ��P�i�H�Y���u�]�s���`��
        /// </summary>
        public int totalCountEnemyLive;

        [Header("��l �u�]"), SerializeField]
        private GameObject goMarble;


        #endregion

        #region �ƥ�
        private void Awake()
        {
            SpawnRandomEnemy();
            SpawnRandomBoss();
        }
        #endregion

        #region ��k
        /// <summary>
        /// �ͦ��H���ĤH
        /// </summary>
        public void SpawnRandomEnemy()
        {
            int min = 2;
            int max = traThirdPlace.Length;

            int randomCount = Random.Range(min, max);
            // print("�H���Ǫ��ƶq�G" + randomCount);

            // �M�� = �}�C.�ର�M��();
            listThirdPlace = traThirdPlace.ToList();

            // �H������
            System.Random random = new System.Random();
            // �M�� = �M�� �� �Ƨ�(�C�ӲM�椺�e => �H���Ƨ�) �ର�M��
            listThirdPlace = listThirdPlace.OrderBy(x => random.Next()).ToList();

            int sub = traThirdPlace.Length - randomCount;
            // print("�n�������ƶq�G" + sub);

            // �j�� �R�� �n�������ƶq
            for (int i = 0; i < sub; i++)
            {
                // �R���Ĥ@�ӲM����
                listThirdPlace.RemoveAt(0);
            }

            // �ͦ��Ҧ��Ǫ��P�u�]�@��
            for (int i = 0; i < listThirdPlace.Count; i++)
            {
                // �p�G i ���� 0 �ͦ��u�]
                if (i == 0)
                {
                    Instantiate(
                    goMarble,
                    listThirdPlace[i].position,
                    Quaternion.identity);
                }
                else
                {
                    // �H���Ǫ�
                    int randomIndex = Random.Range(0, goEnemys.Length);
                    // �ͦ��Ǫ�
                    Instantiate(
                        goEnemys[randomIndex],
                        listThirdPlace[i].position,
                        Quaternion.identity);
                }

                totalCountEnemyLive++;
                // print("�Ǫ��P�u�]�ƶq" + totalCountEnemyLive);
            }


        }

        /// <summary>
        /// �ͦ��H���]��
        /// </summary>
        public void SpawnRandomBoss()
        {
            // �u�ͦ��@�� �]���}�C3�� �M �Ĥ@��3�Ӯ�l�y��   �u�ͦ��@���]��

            // �H������]���}�C�����@�ӯ���
            int randomIndex = Random.Range(0, moveBoss.Length);

            // �H����ܲĤ@�Ʈ�l������
            int randomPlaceIndex = Random.Range(0, traFirstPlace.Length);

            // �b�H����ܪ��Ĥ@�Ʈ�l�y�ФW�ͦ��H�����]��
            Instantiate(moveBoss[randomIndex], traFirstPlace[randomPlaceIndex].position, Quaternion.identity); 
        }
        #endregion
    }
}