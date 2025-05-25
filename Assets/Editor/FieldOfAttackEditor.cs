using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Field_Of_Attack))]
public class FieldOfAttackEditor : Editor
{
    private void OnSceneGUI()
    {
        Field_Of_Attack foa = (Field_Of_Attack)target;
        Handles.color = Color.blue;
        Handles.DrawWireArc(foa.transform.position, Vector3.up, Vector3.forward, 360, foa.radius);

        Vector3 viewAngle01 = DirectionFromAngle(foa.transform.eulerAngles.y, -foa.angle / 2);
        Vector3 viewAngle02 = DirectionFromAngle(foa.transform.eulerAngles.y, foa.angle / 2);
        Handles.color = Color.magenta;
        Handles.DrawLine(foa.transform.position, foa.transform.position + viewAngle01 * foa.radius);
        Handles.DrawLine(foa.transform.position, foa.transform.position + viewAngle02 * foa.radius);

        if (foa.canAttackPlayer)
        {
            Handles.color = Color.red;
            Handles.DrawLine(foa.transform.position, foa.playerRef.transform.position);
        }
    }
    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
