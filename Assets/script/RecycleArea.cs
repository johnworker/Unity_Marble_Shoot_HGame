using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LEO
{
    /// <summary>
    /// 回收區域
    /// </summary>
    public class RecycleArea : MonoBehaviour
    {
        /// <summary>
        /// 回收彈珠事件
        /// </summary>
        public UnityEvent onRecycle;
        private void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains("彈珠"))
            {
                //print("回收彈珠");
                onRecycle.Invoke();
            }
        }


    }
}