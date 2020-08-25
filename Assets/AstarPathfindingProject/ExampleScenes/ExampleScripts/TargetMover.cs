using UnityEngine;
using System.Linq;

namespace Pathfinding {
	/// <summary>
	/// Moves the target in example scenes.
	/// This is a simple script which has the sole purpose
	/// of moving the target point of agents in the example
	/// scenes for the A* Pathfinding Project.
	///
	/// It is not meant to be pretty, but it does the job.
	/// </summary>
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_target_mover.php")]
	public class TargetMover : MonoBehaviour {
		public LayerMask mask;

		public Transform target;
		IAstarAI[] ais;

		public bool use2D;

		Camera cam;

		public void Start () {
			cam = Camera.main;
			ais = FindObjectsOfType<MonoBehaviour>().OfType<IAstarAI>().ToArray();
		}

		void Update () {
			UpdateTargetPosition();
		}

		public void UpdateTargetPosition () {
			//Vector3 newPosition = Vector3.zero;

			/*if (use2D) {
				newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
				newPosition.z = 0;
			} else {
				// Fire a ray through the scene at the mouse position and place the target where it hits
				RaycastHit hit;
				if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, mask)) {
					newPosition = hit.point;
				}
			}*/

			//target.position = newPosition;
			for (int i = 0; i < ais.Length; i++) {
				if (ais[i] != null) ais[i].SearchPath();
			}
		}
	}
}
