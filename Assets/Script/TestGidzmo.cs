using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace TinyTower
{
    public class TestGidzmo : MonoBehaviour
    {
        void OnDrawGizmosSelected()
        {
            return;
            // Draw a semitransparent blue cube at the transforms position

            //Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));

            BoxCollider col = GetComponent<BoxCollider>();
            if( col != null)
            {
                Gizmos.color = new Color(0, 1, 0, 1.0f);

                Vector3 size = col.size;
                Vector3 scale = transform.localScale;


                Vector3 pos1 = transform.position - new Vector3(size.x / 2.0f, size.y / 2.0f, 0.0f) * scale.x;
                Vector3 pos2 = transform.position + new Vector3(-size.x / 2.0f, size.y / 2.0f, 0.0f) * scale.y;

                //pos1 = transform.TransformVector(pos1);
                //pos2 = transform.TransformVector(pos2);

                DrawThickLine(pos1, pos2, 2.0f);
            }
        }

        public void DrawThickLine(Vector3 start, Vector3 end, float thickness)
        {
            Camera c = Camera.current;
            if (c == null) return;

            // Only draw on normal cameras
            if (c.clearFlags == CameraClearFlags.Depth || c.clearFlags == CameraClearFlags.Nothing)
            {
                return;
            }

            // Only draw the line when it is the closest thing to the camera
            // (Remove the Z-test code and other objects will not occlude the line.)
            var prevZTest = Handles.zTest;
            Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;

            Handles.color = Gizmos.color;
            Handles.DrawAAPolyLine(thickness * 10, new Vector3[] { start, end });

            Handles.zTest = prevZTest;
        }

    }
}

