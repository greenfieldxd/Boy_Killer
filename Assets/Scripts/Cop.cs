using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cop : MonoBehaviour
{
    [SerializeField] GameObject deathFX;

    private void Start()
    {
        GameManager.Instance.AddLevelPoints();

        deathFX.transform.localScale = new Vector3(5, 5, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(deathFX, transform.position, Quaternion.identity);
        Destroy(gameObject);

        GameManager.Instance.AddScore();
    }
}
