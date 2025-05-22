using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Data
    [SerializeField] float speed = 0.01f;
    [SerializeField] float angle = 0f;

    // Obj
    [SerializeField] GameObject mainCharacterObj;

    // anim
    public Animator charAnim;
    public string charState_Walk => "isWalk";

    // Moving Method
    public void Move(Vector2 vec)
    {
        //atan2 -> 백터의 방향(각도) 구함, rad2dig -> 라디안을 도(degree)로 변환환
        angle = Mathf.Atan2(vec.x, vec.y) * Mathf.Rad2Deg;

        this.transform.position += new Vector3(vec.x, 0f, vec.y) * speed;
        mainCharacterObj.transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }

    // Collider
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trigger")
        {
            Debug.Log("Trigger");
        }
    }
}
