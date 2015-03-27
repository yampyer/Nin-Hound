#pragma strict

public var speed:int = 6;

function Start () {
	GetComponent.<Rigidbody2D>().velocity.x = -speed;
	Destroy(this.gameObject, 5);
}
