using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LEO
{
    /// <summary>
    /// �^���ϰ�
    /// </summary>
    public class RecycleArea : MonoBehaviour
    {
        /// <summary>
        /// �^���u�]�ƥ�
        /// </summary>
        public UnityEvent onRecycle;
        private void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains("�u�]"))
            {
                //print("�^���u�]");
                onRecycle.Invoke();
            }
        }


    }
}