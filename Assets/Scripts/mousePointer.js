#pragma strict
var depth = 10.0;

function Start () {
	// hide cursor (not working)
	Screen.showCursor = false;
	var depth = 10.0;
}

function Update () {
	var mousePos = Input.mousePosition;
    var wantedPos = Camera.main.ScreenToWorldPoint (Vector3 (mousePos.x, mousePos.y, depth));
    transform.position = wantedPos;
}