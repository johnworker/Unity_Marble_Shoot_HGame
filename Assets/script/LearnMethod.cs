using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnMethod : MonoBehaviour
{

    // 自訂方法
    // 需要呼叫才會執行

    // Unity的入口
    // 開始事件 (藍色名稱)
    // 撥放遊戲後會執行一次
    // 初始化設定：初始金額、三條命等等等

    private void Start()
    {
        // 呼叫方法
        // 方法名稱
        Text();
        PrintColorText();
        print("傳回10方法結果：" + ReturnTen());
        print("商品總價：" + CalculatePrice());

        Shoot("子彈");                        //沒填會以預設執行參數
        Shoot("散彈");
        Shoot("冰球", "滋滋滋");              //參數覆蓋
        Shoot("能量球", "光柱");              //不指定執行結果錯誤
        Shoot("能量球", effect: "光柱");      //能量球,咻咻咻，指定 參數名稱: 光柱

        //近距離攻擊
        Attack(50);
        //遠距離攻擊
        Attack(20, "火球");
    }

    // 方法語法
    // 回傳類型 方法自訂名稱 (參數1, 參數2, ...) { 方法內容 }
    // ↗上述之參數通常不建議寫太多，但還是有少數遊戲是有寫超過10個參數
    // 無回傳 void
    // 方法名稱 Unity 習慣用大寫開頭
    private void Text()
    {
        // 輸出(內容)
        print("hello world");

    }

    #region 方法練習
    private void PrintColorText()
    {
        print("<color=yellow>黃色</color>");
        print("<color=red>紅色</color>");
        print("<color=#003366>藍色</color>");
    }

    // 傳回方法
    // 必須搭配return
    private int ReturnTen()
    {
        // 傳回 資料 (此資料類型必須與傳回類型相同)
        return 10;
    }

    // 商店系統：99元，計算全部的商品價格
    public int countProduct = 10;
    public int countPrice = 99;

    private int CalculatePrice()
    {
        return countProduct * countPrice;
    }

    #endregion




    #region 發射火球、發射雷電
    // 發射火球、發射雷電
    // 撥放音效
    private void shootBullet()
    {
        print("發射子彈");
        print("播放音效");
    }

    private void shootShotgun()
    {
        print("發射散彈");
        print("播放音效");
    }


    // 參數語法：參數類型 參數名稱 指定 預設值
    private void Shoot(string type, string sound = "碰碰碰", string effect = "煙霧")
    {
        print("發射：" + type);
        print("音效：" + sound);
        print("特效：" + effect);
    }

    #endregion

    // 方法的多載 overload
    // 定義：
    // 1.相同名稱的方法
    // 2.有不同數量的參數或者不同類型的參數
    private void TestMethod()
    {

    }

    private void TestMethod(int number)
    {

    }


    private void Attack(float atk)
    {
        print("持刀攻擊，攻擊力：" + atk);
    }

    private void Attack(float atk, string ball)
    {
        print("遠距離攻擊，攻擊力：" + atk);
        print("發射：" + ball);
    }

}
