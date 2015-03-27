#pragma strict

private var X:float;
var offset : int;
var FollowCamera : boolean;

function Start () {
	X= Camera.main.transform.position.x;
}

function Update () {
	if(FollowCamera){
		transform.position.x = (Camera.main.transform.position.x - X)/offset;
	} else {
		transform.position.x = (X - Camera.main.transform.position.x)/offset;
	}
}