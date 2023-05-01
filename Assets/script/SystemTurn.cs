using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace LEO{ 
public class SystemTurn : SystemFinal
{
        #region ���
        /// <summary>
        /// �ĤH�^�X
        /// </summary>
        public UnityEvent onTurnEnemy;

        // �ݭn���a���u�]���
        private SystemControl systemControl;
        // �ݭn���D�X���Ǫ��b���W
        private SystemSpawn systemSpawn;
        // �ݭn���D�^���ϰ�
        private RecycleArea recycleArea;

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

        #endregion

        private void Awake()
        {
            systemControl = GameObject.Find("���p�j").GetComponent<SystemControl>();
            systemSpawn = GameObject.Find("�ͦ��Ǫ��t��").GetComponent<SystemSpawn>();
            recycleArea = GameObject.Find("�^���ϰ�").GetComponent<RecycleArea>();
            textFloorCount = GameObject.Find("�h�ƼƦr").GetComponent<TextMeshProUGUI>();
            

            recycleArea.onRecycle.AddListener(RecycleMarble);

            systemFinal = FindObjectOfType<SystemFinal>();
        }

        [SerializeField, Header("�S�����ʪ���åB����ͦ����ɶ�"), Range(0, 3)]
        private float noMoveObjectAndDelaySpawn = 1;

        /// <summary>
        ///  �^���u�]
        /// </summary>

        private void RecycleMarble()
        {
            totleCountMarble = systemControl.canShootMarbleTotal;

            totalRecycleMarble++;
            // print("<color=yellow>�u�]�^���ƶq�G" + totalRecycleMarble + "</color>");

            if(totalRecycleMarble == totleCountMarble)
            {
                // print("�^�������A���ĤH�^�X");
                onTurnEnemy.Invoke();

                // �p�G�S���ĤH�N���ʵ����åͦ��ĤH�P�u�]
                if(FindObjectsOfType<SystemMove>().Length == 0)
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

            if(isFloorCountMax)
            {
                if(FindObjectOfType<SystemMove>().Length == 0)
                {
                    systemFinal.ShowFinalAndUndateSubTitle("���߬D�����d���\!");
                }
            }
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