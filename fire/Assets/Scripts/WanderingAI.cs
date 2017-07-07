using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour {
	//移动速度的值和对墙壁做出反应的距离
	public float speed = 3.0f;
	public float obstacleRange = 5.0f;
	//用于跟踪敌人是否存在
	private bool _alive;
	[SerializeField] private GameObject fireballPrefab;
	private GameObject _fireball;

	void Start () {
		//初始化
		_alive = true;
	}

	void Update () {
		if (_alive) {
			//每帧持续向前移动，不管旋转
			transform.Translate (0, 0, speed * Time.deltaTime);
		}
		//和角色相同位置的射线，并且方向相同
		Ray ray = new Ray(transform.position , transform.forward);
		RaycastHit hit;
		//使用沿着射线的长度发射射线
		if (Physics.SphereCast (ray, 0.75f, out hit)) {
			GameObject hitObject = hit.transform.gameObject;
			//检查玩家
			if(hitObject.GetComponent<PlayerCharacter>()){
				if (_fireball == null) {
					_fireball = Instantiate (fireballPrefab) as GameObject;
					_fireball.transform.position = transform.TransformPoint (Vector3.forward * 1.5f);
					_fireball.transform.rotation = transform.rotation;
				}
			}
			else if (hit.distance < obstacleRange) {
				//转向一个半随机的新方向
				float angle = Random.Range (-110, 110);
				transform.Rotate (0, angle, 0);
			}
		}
	}


	public void SetAlive(bool alive){
		_alive = alive;
	}
		 
}


