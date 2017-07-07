using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour {
	//通过射击脚本调用的方法
	public void ReactToHit(){
		WanderingAI behavior = GetComponent<WanderingAI> ();
		//检查角色是否有WanderingAI脚本
		if(behavior != null){
			behavior.SetAlive (false);
		}
		StartCoroutine (Die ());
	}
	//推掉敌人后1.5秒后销毁
	private IEnumerator Die(){
		this.transform.Rotate (-75, 0, 0);
		yield return new WaitForSeconds (1.5F);
		Destroy (this.gameObject);
	}
}
 