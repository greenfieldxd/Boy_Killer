using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform bulletPosition;
    [SerializeField]Transform direction;
    [SerializeField] float moveSpeed = 2;
    [SerializeField] Bullet bullet;
    [SerializeField] GameObject ShotFX;



    private void Start()
    {
        ShotFX.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }
    public void Shot()
    {
        Player.Instance.MinusAmmo();
        Bullet newBullet = Instantiate(bullet, bulletPosition.position, bulletPosition.transform.rotation);
        newBullet.transform.DOMove(direction.position, moveSpeed);
        Instantiate(ShotFX, bulletPosition.position, Quaternion.identity);
    }
}
