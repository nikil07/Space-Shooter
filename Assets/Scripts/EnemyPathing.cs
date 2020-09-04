using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{

    List<Transform> wavePoints;
    float moveSpeed;
    WaveConfig waveConfig;

    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        wavePoints = waveConfig.getWaypoints();
        transform.position = wavePoints[waypointIndex].transform.position;
        moveSpeed = waveConfig.getMoveSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        pathing();
    }

    public void SetWaveConfig(WaveConfig waveConfig) {
        this.waveConfig = waveConfig;
    }

    private void pathing() {
        if (waypointIndex <= wavePoints.Count - 1)
        {
            
            var targetPosition = wavePoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
