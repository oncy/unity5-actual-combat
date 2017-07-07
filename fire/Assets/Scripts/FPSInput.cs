using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {

	public float speed = 6.0f;
	//用于引用CharacterController的变量
	public float gravity = -9.8f;
	private CharacterController _charactercontroller;

	void Start () {
		//使用附加到相同对象上的其他组件
		_charactercontroller = GetComponent<CharacterController> ();
	}

	void Update () {
		float deltaX = Input.GetAxis ("Horizontal") * speed;
		float deltaZ = Input.GetAxis ("Vertical") * speed;
		Vector3 movement = new Vector3 (deltaX, 0 ,deltaZ);
		//将对象移动的速度限制为和沿着轴移动的速度一样
		movement = Vector3.ClampMagnitude (movement, speed);

		movement.y = gravity;

		movement *= Time.deltaTime;
		//把movement向量从本地变量从本地变换为全局坐标
		movement = transform.TransformDirection(movement);
		//告知CharacterController通过movement向量移动
		_charactercontroller.Move(movement);

	}
}
