using UnityEngine;

public static class ExtensionClass 
{
    public static Vector3 VectorToVector3(this Vector3 vector3, Vector vector)
    {
        return new Vector3(vector.x, vector.y, vector.z);
    }
}
