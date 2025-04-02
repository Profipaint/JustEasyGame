using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineEffect : MonoBehaviour
{
    [Tooltip("Effect duration in seconds")]
    public float effectDuration = 1;
    private float timer;

    public LineRenderer lineRenderer;

    public void SetPosition(Vector3 pos1, Vector3 pos2)
    {
        lineRenderer.SetPosition(0, pos1);
        lineRenderer.SetPosition(1, pos2);

        timer = effectDuration;
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            Color c = lineRenderer.startColor;
            c.a = timer / effectDuration; // get the value from 0 to 1
            lineRenderer.startColor = c;
            lineRenderer.endColor = c;
        } else
        {
            Destroy(this.gameObject);
            //print("Line renderer effect was automatically destroyed!");
        }
    }
}
