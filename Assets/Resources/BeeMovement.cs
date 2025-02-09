using UnityEngine;
using System.Collections;

public class BeeMovement : MonoBehaviour
{
    public Transform[] waypoints; // Küplerin konumlarý
    public float speed = 10f;
    private int currentTarget = 0;

    private LineRenderer lineRenderer;

    void Start()
    {
        
  

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.001f;
        lineRenderer.endWidth = 0.001f;
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.red;

        StartCoroutine(MoveBee());
    }

    IEnumerator MoveBee()
    {
        while (currentTarget < waypoints.Length)
        {
            Vector3 targetPos = waypoints[currentTarget].position;
            while (Vector3.Distance(transform.position, targetPos) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
                yield return null;
            }

            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.position);

            currentTarget++;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
