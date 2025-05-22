using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float angle;

    //anim
    public Animator charAnim;
    public string charState_Walk => "isWalk";

    public void Move(Vector2 vec)
    {
        //atan2 -> 백터의 방향(각도) 구함, rad2dig -> 라디안을 도(degree)로 변환환
        angle = Mathf.Atan2(vec.x, vec.y) * Mathf.Rad2Deg;

        this.transform.position += new Vector3(vec.x, 0f, vec.y) * speed;
        this.transform.rotation = Quaternion.Euler(0f, angle, 0f);        
    }
}
