using UnityEngine;

namespace Lean.Touch
{
	/// <summary>This component will constrain the current <b>transform.position</b> to the specified collider.
	/// NOTE: If you're using a MeshCollider then it must be marked as <b>convex</b>.</summary>
	[HelpURL(LeanTouch.PlusHelpUrlPrefix + "LeanConstrainToCollider")]
	[AddComponentMenu(LeanTouch.ComponentPathPrefix + "Constrain To Collider")]
	public class LeanConstrainToCollider : MonoBehaviour
	{
		/// <summary>The collider this transform will be constrained to.</summary>
		[Tooltip("The collider this transform will be constrained to.")]
		[UnityEngine.Serialization.FormerlySerializedAs("Target")]
		public Collider Collider;

		protected virtual void LateUpdate()
		{
			if (Collider != null)
			{
				var oldPosition = transform.position;
				var newPosition = Collider.ClosestPoint(oldPosition);

				if (Mathf.Approximately(oldPosition.x, newPosition.x) == false ||
					Mathf.Approximately(oldPosition.y, newPosition.y) == false ||
					Mathf.Approximately(oldPosition.z, newPosition.z) == false)
				{
					transform.position = newPosition;
				}
			}
		}
	}
}