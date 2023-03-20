using UnityEngine;

[CreateAssetMenu(fileName = "ActorData", menuName = "actor", order = 0)]
public class ActorData : ScriptableObject
{
    public float speed = 45;
    
    public float groundTriggerRange = 0.02f;

    public float overHeadTriggerRange = 0.02f;

    public Vector3 groundOffset = new Vector3(0,0.01f ,0);
    
    public Vector3 overHeadOffset = new Vector3(0,0.01f ,0);

    public LayerMask groundLayerMask;

    public PhysicMaterial airPhysicMaterial;
    
    public PhysicMaterial groundPhysicMaterial;
}
