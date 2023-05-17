using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace LEO{ 
public class SystemTurn : SystemFinal
{
        #region ���

        // �ݭn���a���u�]���
        private SystemControl systemControl;
        // �ݭn���D�X���Ǫ��b���W
        private SystemSpawn systemSpawn;
        // �ݭn���D�^���ϰ�
        private RecycleArea recycleArea;

        public UnityEvent onTurnEnemy;

        /// <summary>
        /// �u�]�`��
        /// </summary>
        private int totleCountMarble;

        /// <summary>
        /// �Ǫ��P�i�H�Y���u�]�s���`��
        /// </summary>
        private int totalCountEnemyLive;

        /// <summary>
        /// �^���u�]�ƶq
        /// </summary>
        private int totalRecycleMarble;

        private bool canSpawn = true;

        private int countMarbleEat;

        /// <summary>
        /// �h�ƼƦr
        /// </summary>
        private TextMeshProUGUI textFloorCount;
        private int countFloor = 1;

        [SerializeField, Header("��e�h�ƪ��̤j��"), Range(1, 100)]
        private int countFloorMax = 50;
        private bool isFloorCountMax;

        private SystemFinal systemFinal;

        private SystemEnemy systemEnemy;

        #endregion

        private void Awake()
        {
            systemControl = GameObject.Find("���p�j").GetComponent<SystemControl>();
            systemSpawn = GameObject.Find("�ͦ��Ǫ��t��").GetComponent<SystemSpawn>();
            recycleArea = GameObject.Find("�^���ϰ�").GetComponent<RecycleArea>();
            textFloorCount = GameObject.Find("�h�ƼƦr").GetComponent<TextMeshProUGUI>();
            
            systemEnemy = GameObject.Find("�ĤH���{����").GetComponent<SystemEnemy>();

            recycleArea.onRecycle.AddListener(RecycleMarble);

            systemFinal = FindObjectOfType<SystemFinal>();
        }

        [SerializeField, Header("�S�����ʪ���åB����ͦ����ɶ�"), Range(0, 3)]
        private float noMoveObjectAndDelaySpawn = 1;

        /// <summary>
        ///  �^���u�]
        /// </summary>

        public void RecycleMarble()
        {
            totleCountMarble = systemControl.canShootMarbleTotal;

            totalRecycleMarble++;
            // print("<color=yellow>�u�]�^���ƶq�G" + totalRecycleMarble + "</color>");

            if(totalRecycleMarble == totleCountMarble)
            {
                // print("�^�������A���ĤH�^�X");
                onTurnEnemy.Invoke();

                // ����]�����{����

                // 1.���SystemEnemy.cs�̪� EnemyTurn() �ð���
                // �I�s EnemyTurn() ��k
                // FindObjectOfType<SystemEnemy>().EnemyTurn();

                // �p�G�S���ĤH�N���ʵ����åͦ��ĤH�P�u�]
                if (FindObjectsOfType<SystemMove>().Length == 0)
                {
                    Invoke("MoveEndSpawnEnemy", noMoveObjectAndDelaySpawn);
                }
            } 
        }
        /// <summary>
        /// ���ʵ�����ͦ��ĤH�M�u�]
        /// </summary>
        public void MoveEndSpawnEnemy()
        {
            if (!canSpawn) return;

            if (!isFloorCountMax)
            {
                canSpawn = false;
                systemSpawn.SpawnRandomEnemy();
            }

            Invoke("PlayerTurn", 1);
        }
        /// <summary>
        /// ���a�^�X
        /// </summary>
        private void PlayerTurn()
        {
            systemControl.canShootMarble = true;
            canSpawn = true;
            totalRecycleMarble = 0;

            #region �u�]�ƶq�B�z
            systemControl.canShootMarbleTotal += countMarbleEat;
            countMarbleEat = 0;
            #endregion

            if(countFloor < countFloorMax)
            { 
                countFloor++;
                textFloorCount.text = countFloor.ToString();
            }

            if (countFloor == countFloorMax) isFloorCountMax = true;

            // ���a��F�̲׼Ӽh�B������l�S���Ǥ~���
            if (isFloorCountMax)
            {
                // �S���Ǫ��M�]���N�ӧQ
                if (AreAllGridsEmpty())
                {
                    systemFinal.ShowFinalAndUndateSubTitle("���߬D�����d���\!");
                }
            }
        }

        // �ˬd�Ҧ���l�O�_�S���Ǫ�
        private bool AreAllGridsEmpty()
        {
            // ���ʸ}�� �}�C ����Ƽ� ���w �q���ʸ}����X
            SystemMove[] gridObjects = FindObjectsOfType<SystemMove>();

            // �C�� (���ʸ}�� ���� �b ����Ƽ�)
            foreach (SystemMove gridObject in gridObjects)
            {
                // �p�G(����O���ĤH��k)
                if (gridObject.HasEnemy())
                {
                    return false; // �Y����l���Ǫ��A��^ false
                }
            }


            return true; // �Y�Ҧ���l���S���Ǫ��A��^ true
        }


        /// <summary>
        /// ���ʵ������ͦ��ĤH�M�u�]
        /// </summary>

        public void MarbleEat()
        {
            countMarbleEat++;
        }

    }

}