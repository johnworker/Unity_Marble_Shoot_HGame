using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LEO
{
    /// <summary>
    /// �i�H�Y���u�]�t��
    /// </summary>
    public class SystemMarbleEat : MonoBehaviour
    {
        private string nameMarblePlayer = "�u�]";
        private SystemTurn systemTurn;

        private void Awake()
        {
            // �z�L�����M�䪫��<����>()
            // *�j�M�����������W�u�঳�@��
            systemTurn = FindObjectOfType<SystemTurn>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains(nameMarblePlayer))
            {
                systemTurn.MarbleEat();
                Destroy(gameObject);
            }
        }
    }
}
