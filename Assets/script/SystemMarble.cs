using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LEO
{
    /// <summary>
    /// 彈珠系統
    /// 1.長時間沒有碰到怪物就往下方回收
    /// </summary>
    public class SystemMarble : MonoBehaviour
    {
        [SerializeField, Header("怪物圖層")]
        private LayerMask layerEnemy;
        [SerializeField, Header("幾秒沒有碰到怪物要回收"), Range(0, 10)]
        private float timeRecycle = 3;
        [SerializeField, Header("回收速度")]
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
            if (!collision.collider.name.Contains("怪物") && timer == timeRecycle)
            {
                systemControl.marble.GetComponent<Rigidbody>().AddForce(transform.position.z * v3SpeedRecycle);
            }
        }

        
    }

}
