// Author: Fatima Nadeem / Croft (Please credit before direct usage)

using UnityEngine;

public class TransformDamper : MonoBehaviour
{
    [SerializeField] Transform constrainedObject; // The transform to dampen

    [Range(0f, 1f)]
    [SerializeField] float dampPosition;
    [Range(0f, 1f)]
    [SerializeField] float dampRotation;

    // "Cache" values
    Transform parent; // Parent of contrained object
    Vector3 initialLocalPosition; // local position at game start
    Vector3 prevPosition; // global position in previous frame
    Quaternion initialLocalRotation; // local rotation at game start
    Quaternion prevRotation; // global rotation in previous frame

    void Start()
    {
        parent = constrainedObject.parent;
        initialLocalPosition = constrainedObject.localPosition;
        prevPosition = constrainedObject.position;
        initialLocalRotation = constrainedObject.localRotation;
        prevRotation = constrainedObject.rotation;
    }

    void Update()
    {
        // Interpolating global transform values between previous global
        // transform and what the contrained object's global transform should
        // be in relation to the parent's new transform values
        
        // Position
        prevPosition = Vector3.Lerp
            (parent.TransformPoint(initialLocalPosition),
            prevPosition, dampPosition);
        // Rotation
        prevRotation = Quaternion.Lerp
            (parent.rotation * initialLocalRotation,
            prevRotation, dampRotation);

        // Updating constrained object's position and rotation
        constrainedObject.SetPositionAndRotation(prevPosition, prevRotation);
    }
}
