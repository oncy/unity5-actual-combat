using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	public enum RotationAxes
	{
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}

	public float sensitivityHor = 9.0f;
	public float sensitivityVert = 9.0f;
	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;

	private float _rotationX = 0;

	public RotationAxes axes = RotationAxes.MouseXAndY;

	void Start(){
		Rigidbody body = GetComponent<Rigidbody> ();
		//检查这个组件是否存在
		if (body != null) {
			body.freezeRotation = true;
		}
	}
		

	void Update () {
		if (axes == RotationAxes.MouseX) {
			transform.Rotate (0, Input.GetAxis ("Mouse X") * sensitivityHor, 0);
		} else if (axes == RotationAxes.MouseY) {
			_rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
			//垂直角度限制最小值和最大值
			_rotationX = Mathf.Clamp (_rotationX, minimumVert, maximumVert);
			//保持Y的角度一样
			float rotationY = transform.localEulerAngles.y;
			//使用存的储存旋转值创建新的Vector
			transform.localEulerAngles = new Vector3 (_rotationX, rotationY, 0);

		}
		else{
			_rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp (_rotationX, minimumVert, maximumVert);
			//delta是旋转变化量
			float delta = Input.GetAxis ("Mouse X") * sensitivityHor;
			//使用delta递增旋转角度
			float rotationY = transform.localEulerAngles.y + delta;

			transform.localEulerAngles = new Vector3 (_rotationX, rotationY, 0);
		}

	}

}
