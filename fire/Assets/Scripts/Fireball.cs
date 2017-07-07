using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	public float speed = 10.0f;
	public float damage = 1;
	void Start () {
		
	}
	
	void Update () {
		transform.Translate (0, 0, speed * Time.deltaTime);
	}

	//当其他对象和这个触发器碰撞时调用这个方法
	void OnTriggerEnter(Collider other){
		PlayerCharacter player = other.GetComponent<PlayerCharacter> ();
		//检查other对象是否为PlayerCharacter
		if (player != null) {
			Debug.Log ("Player hit");
		}
		Destroy (this.gameObject);
	}
}
