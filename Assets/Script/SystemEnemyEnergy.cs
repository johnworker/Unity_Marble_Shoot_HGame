using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemEnemyEnergy : MonoBehaviour
{
    void Awake()
    {
        Physics.IgnoreLayerCollision(7, 8);     // �Ǫ��B�Ǫ������I��
    }

}
