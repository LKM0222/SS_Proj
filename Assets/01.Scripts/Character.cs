using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] float speed;
    public void Move(Vector2 vec)
    {
        this.transform.position += new Vector3(vec.x, 0f, vec.y) * speed;
    }
}
