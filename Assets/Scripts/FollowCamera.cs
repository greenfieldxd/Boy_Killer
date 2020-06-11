using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] float delay = 3.5f;
    [SerializeField] float offset = 5f;

    [SerializeField] GameObject player;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x + offset, transform.position.y, transform.position.z), delay * Time.deltaTime);
    }
}
