using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace LEO
{ 
    /// <summary>
    /// ���a����t��
    /// �������B�u�]�o�g
    /// </summary>
public class SystemControl : MonoBehaviour
{
        #region ���
        // GameObject �C������
        // �s�񶥼h���O���αM�פ�������

        // �b�Y
        [Header("�b�Y")]
        public GameObject arrow;
        // ����t��
        [Header("����t��"), Range(0, 500)]
        public float speedTurn = 10.5f;
        // �u�]�w�m��
        [Header("�u�]�w�m��")]
        public GameObject marble;
        // �u�]�i�o�g���`��
        [Header("�u�]�i�o�g���`��"), Range(0, 50)]
        public int canShootMarbleTotal = 15;
        // �u�]�ͦ��I
        [Header("�u�]�ͦ��I")]
        public Transform traSpawnPoint;
        // �����ѼƦW��
        [Header("�����ѼƦW��")]
        public string parAttack = "Ĳ�o����";
        // �u�]�o�g�t��
        [Header("�u�]�o�g�t��"), Range(0, 5000)]
        public float speedMarble = 1000;
        [Header("�u�]�o�g����"), Range(0, 2)]
        public float intervalMarble = 0.5f;
        [Header("�u�]�ƶq")]
        public TextMeshProUGUI textMarbleCount;

        public Animator ani;

        /// <summary>
        /// ��_�o�g�u�]
        /// </summary>
        // HideInInspector ���ä��}�ݩ�
        [HideInInspector]
        public bool canShootMarble = true;

        /// <summary>
        /// �ഫ�ƹ�����v��
        /// </summary>
        private Camera cameraMouse;
        /// <summary>
        /// �y���ഫ����骫��
        /// </summary>
        private Transform traMouse;
        #endregion

        #region �ƥ�
        private void Awake()
        {
            ani = GetComponent<Animator>();

            textMarbleCount.text = "x" + canShootMarbleTotal;

            cameraMouse = GameObject.Find("�ഫ�ƹ�����v��").GetComponent<Camera>();

            // traMouse = GameObject.Find("�y���ഫ����骫��").GetComponent<Transform>();
            traMouse = GameObject.Find("�y���ഫ����骫��").transform;

            // ���z �����ϼh�I��(�ϼh1�A�ϼh2)
            Physics.IgnoreLayerCollision(3, 3);

        }

        private void Update()
        {
            ShootMarble();
            TurnCharacter();
        }
        #endregion

        #region ��k

        /// <summary>
        ///  ���ਤ��A�����⭱�V�u�]����m
        /// </summary>
        private void TurnCharacter()
        {
            // �p�G ����o�g �N���X
            if (!canShootMarble) return;
            // 1.�ƹ��y��
            Vector3 posMouse = Input.mousePosition;
            // print("<Color=yellow>�ƹ��y�СG" + posMouse + "</color>");
            // ����v����b�@��
            posMouse.z = 42;

            // 2.�ƹ��y���ର�@�ɮy��
            Vector3 pos = cameraMouse.ScreenToWorldPoint(posMouse);
            // �N�৹���@�ɮy�а��׳]�w�����⪺����
            pos.y = 0.5f;
            // 3.�@�ɮy�е����骫��
            traMouse.position = pos;

            // �������ܧ�.���V(�y���ഫ����骫��)
            transform.LookAt(traMouse);
        }

        /// <summary>
        ///  �o�g�u�]�A�ھڼu�]�`�Ƶo�g����
        /// </summary>
        private void ShootMarble()
        {
            // �p�G ����o�g�u�] �N���X
            if (!canShootMarble) return;

            // ���U �ƹ����� ��� �b�Y
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                arrow.SetActive(true);
            }

            // ��} �ƹ����� �ͦ��õo�g�u�]
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                // ����o�g�u�]
                canShootMarble = false;
                //print("��}����I");
                arrow.SetActive(false);
                StartCoroutine(spawnMarble());
            }
        }

        [SerializeField, Header("�o�g�u�]����")]
        private AudioClip soundShoot;

        private IEnumerator spawnMarble()
        {
            int total = canShootMarbleTotal;

            for (int i = 0; i < canShootMarbleTotal; i++)
            {
                // Object ���O�i�ٲ����g
                // �����z�L Object �����W�٨ϥ�
                // �ͦ�(�u�])�F traSpawnPoint
                // Quaternion.identity �s�ר�
                GameObject tempMarble = Instantiate(marble,traSpawnPoint.position, Quaternion.identity);

                // �Ȧs�u�] ���o���餸�� �K�[���O (����.�e�� * �t��)
                // transform.forward ���⪺�e��
                tempMarble.GetComponent<Rigidbody>().AddForce(transform.forward * speedMarble);

                // ���Ĩt��.�R�A����.���񭵮�(���ġA���q�d��)
                SystemSound.instance.PlaySound(soundShoot, new Vector2(0.7f, 1.2f));

                total--;

                if (total > 0) textMarbleCount.text = "x" + total;
                else if (total == 0) textMarbleCount.text = "";

                yield return new WaitForSeconds(intervalMarble);
            }

        }

        #endregion

    }

}
