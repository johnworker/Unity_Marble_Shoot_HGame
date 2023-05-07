using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LEO
{
    /// <summary>
    /// �u�]�t��
    /// 1.���ɶ��S���I��Ǫ��N���U��^��
    /// </summary>
    public class SystemMarble : MonoBehaviour
    {
        [SerializeField, Header("�Ǫ��ϼh")]
        private LayerMask layerEnemy;
        [SerializeField, Header("�X��S���I��Ǫ��n�^��"), Range(0, 10)]
        private float timeRecycle = 3;
        [SerializeField, Header("�^���t��")]
        private Vector3 v3SpeedRecycle;

        private float timer;
        private float timer_f;

        private SystemControl systemControl;

        private void Awake()
        {
            systemControl = FindObjectOfType<SystemControl>();

        }

        private void Update()
        {
            timer = Time.time;
            timer_f = Mathf.FloorToInt(timer);
            
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.collider.name.Contains("�Ǫ�") && timer == timeRecycle)
            {
                systemControl.marble.GetComponent<Rigidbody>().AddForce(transform.position.z * v3SpeedRecycle);
            }
        }

        
    }

}
