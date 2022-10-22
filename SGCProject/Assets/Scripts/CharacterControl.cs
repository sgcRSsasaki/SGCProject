using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    // �L�����N�^�[�̈ړ��X�s�[�h�i�C���X�y�N�^�[�E�B���h�E�Œl��ݒ�j
public float speed;

// Rigidbody2D��ێ����郁���o�ϐ�
private Rigidbody2D rb2d;


// �W�����v��
public float jumpForce;


// �R���|�[�l���g�̏���������
void Start()
{
    // �Q�[���I�u�W�F�N�g�������Ă���Rigidbody2D�R���|�[�l���g��
    // �擾���ă����o�ϐ��ɕێ�
    rb2d = GetComponent<Rigidbody2D>();
}


// 1�t���[�����ɌĂяo�����
private void Update()
{
    // ���̃t���[���ŃX�y�[�X�L�[�������ꂽ��
    if (Input.GetKeyDown("space"))
    {
        // ������ɗ͂�������
        rb2d.AddForce(Vector2.up * jumpForce);
    }
}


// ��莞�Ԃ��ƂɌĂяo�����
void FixedUpdate()
{
    // �����L�[�̉�����Ă���󋵂��擾
    float moveHorizontal = Input.GetAxis("Horizontal");

    // AddForce���\�b�h�ɓn�����߂ɁAVector2�^�ɕϊ�
    Vector2 movement = new Vector2(moveHorizontal, 0);

    // AddForce���\�b�h�ŃL�����N�^�[��Rigidbody2D�R���|�[�l���g�ɗ͂�������
    rb2d.AddForce(movement * speed);
}
}