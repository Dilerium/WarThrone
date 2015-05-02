var target : Transform;
var distance = 5;

var xSpeed = 250.0;
var ySpeed = 120.0;

var yMinLimit = -40;
var yMaxLimit = 80;

private var x = 0.0;
private var y = 0.0;

@script AddComponentMenu("Camera-Control/Mouse Orbit")

function Start () {
    var angles = transform.eulerAngles;
    x = angles.y;
    y = angles.x;

	// Make the rigid body not change rotation
   	if (rigidbody)
		rigidbody.freezeRotation = true;
}

function LateUpdate () {
    if (target) {
        x += Input.GetAxis("Mouse X") * xSpeed * 0.02;
        y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02;
 		
 		y = ClampAngle(y, yMinLimit, yMaxLimit);
 		       
        var rotation = Quaternion.Euler(y, x, 0);
        var position = rotation * Vector3(0, 2, -distance) + target.position;
        
        transform.rotation = rotation;
        transform.position = position;
    }
}

function ClampAngle (angle : float, min : float, max : float) {
	if (angle < min){
		angle = 0;
		distance = 5;
	}
	if(angle < (min + 50)){
		distance = 1;
	}
	if(angle > (min + 49)){
		distance = 5;
	}
	if (angle > max){
		angle = max;
	}
	return Mathf.Clamp (angle, min, max);
}