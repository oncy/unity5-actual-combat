using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour {

	public float speed = 3.0f;
	//对象移动的范围
	public float maxZ = 16.0f;
	public float minZ = -16.0f;
	//当前对象往哪个方向移动
	private int _direction = 1;

	void Start () {
		
	}
	
	void Update () {
		transform.Translate (0, 0, _direction * speed * Time.deltaTime);

		bool bounced = false;
		//切换来回方向
		if (transform.position.z > maxZ || transform.position.z < minZ) {
			_direction = -_direction;
			bounced = true;
		}
		if (bounced) {
			transform.Translate (0, 0, _direction * speed * Time.deltaTime);
		}
	}
}