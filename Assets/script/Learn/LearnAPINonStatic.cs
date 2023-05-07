using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 學習 非靜態 API
/// API 文件上沒有 static
/// </summary>
public class LearnAPINonStatic : MonoBehaviour
{
    public Transform transA;
    public Light lightA;

    private void Start()
    {
        // 非靜態屬性 properties
        // 1.取得 get
        // 條件：
        // -該類別欄位類型
        // -實體物件
        // -欄位存放該實體物件

        // 欄位名稱.非靜態屬性名稱
        print(" A 物件的座標：" + transA.position);
        print("燈光顏色：" + lightA.color);

        // 2.設定 set
        // 欄位名稱.非靜態屬性名稱 指定 值;
        transA.position = new Vector3(1.7f, 0.5f, -10);
        lightA.color = new Color(1, 0, 0);
    }
}
