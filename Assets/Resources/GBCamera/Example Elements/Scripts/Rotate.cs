using UnityEngine;
using UnityEngine.Serialization;

namespace Camara_GBA.GBCamera.Example_Elements.Scripts
{

namespace GBCamera
{

public class Rotate : MonoBehaviour {

	[FormerlySerializedAs("_rotationAxis")] [Tooltip ("Axis of rotation - use 0 or 1 only")]
	public Vector3 rotationAxis = new Vector3 (0,1,0);
	[FormerlySerializedAs("_rotationSpeed")] [Tooltip ("Speed of rotation in degrees per second")]
	public float rotationSpeed = 90;
	
	private Transform _transform;

	private void Start () {
	
		// cache the transform
		_transform = transform;
	}


	private void Update ()
	{
		_transform.Rotate (rotationAxis * rotationSpeed * Time.deltaTime);
	}
}

}
}
