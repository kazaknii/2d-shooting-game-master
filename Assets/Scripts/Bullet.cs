using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f; // 弾の速度

    // Update is called once per frame
    void Update()
    {
        // 弾が上に動く
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }
}
