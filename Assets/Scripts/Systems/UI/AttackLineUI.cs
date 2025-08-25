using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class AttackLineUI : Graphic
{
    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 startPoint;
    public Vector2 endPoint;
    public float thickness = 5;
   

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        Vector2 dir = (endPoint - startPoint).normalized;
        Vector2 normal = new Vector2(-dir.y, dir.x) * thickness * 0.5f;

        Vector2 p0 = startPoint - normal;
        Vector2 p1 = startPoint + normal;
        Vector2 p2 = endPoint + normal;
        Vector2 p3 = endPoint - normal;

        vh.AddVert(p0, color, Vector2.zero);
        vh.AddVert(p1, color, Vector2.zero);
        vh.AddVert(p2, color, Vector2.zero);
        vh.AddVert(p3, color, Vector2.zero);

        vh.AddTriangle(0, 1, 2);
        vh.AddTriangle(2, 3, 0);
    }

    public void SetPoints(Vector2 start, Vector2 end)
    {
        startPoint = start;
        endPoint = end;
        SetVerticesDirty();
    }
}
