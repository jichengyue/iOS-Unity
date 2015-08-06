using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public  GameObject   mClickEffectPrefab;
	public  GameObject   mClickEffect;
	public 	float walkSpeed = 2f;
	public 	Light light;
	public MovementMotor movement;

	private Vector3[] mPath;
	private bool bWalking = false;
	private int mPathIndex = 0;

	// Use this for initialization
	void Start ()
	{
//		GameObject.Find ("Main Camera").GetComponent<SceneCamera> ().player = this.gameObject;
	}

	// Update is called once per frame
	void Update ()
	{
//		Debug.Log ("Horizontal value: " + Input.GetAxis ("Horizontal"));

		Vector3 direction = Input.GetAxis ("Horizontal") * transform.right + 
							Input.GetAxis ("Vertical") * transform.forward;
		movement.movementDirection = direction.normalized;

//		GetComponent<Rigidbody> ().AddForce (direction.normalized * walkSpeed, ForceMode.Acceleration);

//		transform.position = transform.position + 
//							walkSpeed * direction * Time.deltaTime ;

		if (bWalking) {
				bWalking = Walking ();
		} else {
		}
	}

	public void WalkTo (Vector3 pos, bool withClickEffect = true)
	{

		if ((this.transform.position - pos).magnitude < 0.001f) {
			return;
		}

		Vector3[] corners = CalcPathCorners (this.transform.position, pos);

		if (corners.Length >= 2) {
			bWalking = true;
			mPath = corners;
			bWalking = true;
//			Animation anim = GetComponent<Animation> ();
//			anim.CrossFade ("run_forward", 0.3f);
			mPathIndex = 0;
			transform.position = mPath [0];
			if (mClickEffect != null && withClickEffect) {
					mClickEffect.SetActive (true);
					pos.y += 0.5f;
					mClickEffect.transform.position = pos;
					Invoke ("HideClickEffect", 1.5f);
			}
		}
	}

	private void HideClickEffect ()
	{
		if (mClickEffect != null) {
			mClickEffect.SetActive (false);
		}
	}

	private bool Walking ()
	{
		bool re = true;

		Vector3 curSegSrc = mPath [mPathIndex];
		Vector3 curSegDst = mPath [mPathIndex + 1];
		Vector3 curPos = transform.position;

		Vector3 normalDir = (curSegDst - curSegSrc);
		normalDir.Normalize ();

		curPos += (normalDir * walkSpeed * Time.deltaTime);

		float over = (curPos - curSegSrc).magnitude - (curSegDst - curSegSrc).magnitude;
		if (over > 0) {
				mPathIndex ++;
				if (mPathIndex > mPath.Length - 2) {
						curPos = mPath [mPath.Length - 1];
						transform.position = curPos;
						re = false;
						Animation anim = GetComponent<Animation> ();
//						anim.CrossFade ("idle", 0.3f);
				} else {
						curSegSrc = mPath [mPathIndex];
						curSegDst = mPath [mPathIndex + 1];
						normalDir = (curSegDst - curSegSrc);
						normalDir.Normalize ();
						curPos = curSegSrc + normalDir * over;

						transform.position = curPos;
				}
		} else {
				transform.position = curPos;
		}
		return re;
	}


	Vector3[] CalcPathCorners (Vector3 src, Vector3 dst)
	{
		Vector3[] corners = null;
		NavMeshPath path = new NavMeshPath ();
		//if (NavMesh.CalculatePath(src, dst, -1, path)){
		if (false) {
				corners = path.corners;
		} else {
				corners = new Vector3[2]{src, dst};
		}
		return corners;
	}

	void WalkForward()
	{
		transform.position = transform.position + walkSpeed * transform.forward * Time.deltaTime ;
	}
}
