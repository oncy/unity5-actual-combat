using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour {

	private Camera _camera;

	void Start () {
		//访问相同对象上附加的其他组件
		_camera = GetComponent<Camera> ();
		//隐藏屏幕中心的光标
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void OnGUI(){
		int size = 12;
		float posX = _camera.pixelWidth / 2 - size / 4;
		float posY = _camera.pixelHeight / 2 - size / 2;
		//GUI.Label()命令在屏幕上显示文本
		GUI.Label (new Rect (posX, posY, size, size), "*");
	}
	
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			//屏幕中心
			Vector3 point = new Vector3 (_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
			//使用ScreenPointToRay()在摄像机所在位置创建射线
			Ray ray = _camera.ScreenPointToRay(point);
			RaycastHit hit;
			//Raycast给引用的变量填充信息
			if (Physics.Raycast (ray, out hit)) {
				//获取射击中的对象
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
				//检查对象上是否有ReactiveTarget组件
				if(target != null){
					//调用target方法
					target.ReactToHit();
					//Debug.Log ("Target hit");
				}
				else{
				//运行协程来响应击中
					StartCoroutine(SphereIndicator(hit.point));
				}
			}
		}
	}
	private IEnumerator SphereIndicator(Vector3 pos){
		
		//协程使用IEnumerator方法
		GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		sphere.transform.position = pos;

		//yield关键字告诉协程在何处停止
		yield return new WaitForSeconds(1);

		//移除gameobject并清除
		Destroy(sphere);
	}
}
