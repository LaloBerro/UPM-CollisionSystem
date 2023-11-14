using UnityEngine;

namespace CollisionSystem.Core.View
{
    public class CollisionDetectorView : MonoBehaviour
    {
        protected void InvokeCollisionEventIfIsTrigger(GameObject collideGameObject)
        {
            ICollisionTriggerView collisionTriggerView = collideGameObject.GetComponent<ICollisionTriggerView>();

            collisionTriggerView?.Collide();
        }
    }
}