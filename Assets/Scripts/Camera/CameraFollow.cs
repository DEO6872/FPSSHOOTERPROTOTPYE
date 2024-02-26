using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cameraTarget;

    [SerializeField] private float targetDistance;
    [SerializeField] private float smoothness;
    [SerializeField] private float cameraHeight;

    void LateUpdate()
    {
        float playerX = player.transform.position.x;
        float playerZ = player.transform.position.z;

        float x = transform.position.x - playerX;
        float y = CameraHeight();
        float z = transform.position.z - playerZ;

        Vector3 direction = new Vector3(x, 0, z);
        Vector3 playerPosition = new Vector3(playerX, 0, playerZ);
        Vector3 targetPosition = direction.normalized * targetDistance + playerPosition + new Vector3(0, y, 0);

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime);
        transform.LookAt(cameraTarget.transform.position);
    }

    float CameraHeight()
    {
        float x = transform.eulerAngles.x;
        Ray ray = new Ray(transform.position, Quaternion.Euler(x, 0, 0) * Vector3.down);
        RaycastHit hitData;
        Physics.Raycast(ray, out hitData);

        float y = hitData.point.y + cameraHeight;

        return y;
    }
}
