using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererHelper : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public List<Transform> positions;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.positionCount = positions.Count;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; 1 < positions.Count; i++)
        {
            lineRenderer.SetPosition(i, positions[1].position);
        }
    }
}
