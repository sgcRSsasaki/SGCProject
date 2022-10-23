using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    // キャラクターの移動スピード（インスペクターウィンドウで値を設定）
public float speed;

// Rigidbody2Dを保持するメンバ変数
private Rigidbody2D rb2d;


// ジャンプ力
public float jumpForce;


// コンポーネントの初期化処理
void Start()
{
    // ゲームオブジェクトが持っているRigidbody2Dコンポーネントを
    // 取得してメンバ変数に保持
    rb2d = GetComponent<Rigidbody2D>();
}


// 1フレーム毎に呼び出される
private void Update()
{
    // そのフレームでスペースキーが押されたか
    if (Input.GetKeyDown("space"))
    {
        // 上方向に力を加える
        rb2d.AddForce(Vector2.up * jumpForce);
    }
}


// 一定時間ごとに呼び出される
void FixedUpdate()
{
    // 横矢印キーの押されている状況を取得
    float moveHorizontal = Input.GetAxis("Horizontal");

    // AddForceメソッドに渡すために、Vector2型に変換
    Vector2 movement = new Vector2(moveHorizontal, 0);

    // AddForceメソッドでキャラクターのRigidbody2Dコンポーネントに力を加える
    rb2d.AddForce(movement * speed);
}
}