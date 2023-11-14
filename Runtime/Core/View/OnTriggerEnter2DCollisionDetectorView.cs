using UnityEngine;

namespace CollisionSystem.Core.View
{
    public class OnTriggerEnter2DCollisionDetectorView : CollisionDetectorView
    {
        private void OnTriggerEnter2D(Collider2D collider)
        {
            InvokeCollisionEventIfIsTrigger(collider.gameObject);
        }
    }
}