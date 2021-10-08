using UnityEngine;
public interface IRemoveable
{
    Vector3 GetPosition();
    void Reset(Vector3 originalPosition);
}
