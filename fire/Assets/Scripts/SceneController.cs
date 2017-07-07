using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

	//序列化变量，用于链接预设对象
	[SerializeField] private GameObject enemyPrefab;
	//跟踪敌人实例
	private GameObject _enemy;

	void Start () {
		
	}

	//只有没有敌人才会产生新敌人
	void Update () {
		if (_enemy = null) {
			//复制预设对象
			_enemy = Instantiate (enemyPrefab) as GameObject;
			_enemy.transform.position = new Vector3 (0, 1, 0);
			float angle = Random.Range (0, 36);
			_enemy.transform.Rotate (0, angle, 0);
		}
	}
}
