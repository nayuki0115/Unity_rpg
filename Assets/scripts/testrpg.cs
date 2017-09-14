using UnityEngine;
using System.Collections;

public class testrpg : MonoBehaviour {

	public GameObject cat = null;
	public GUIText guitext = null;
	public GUIText loading = null;
	//public GameObject innercore = null;
	//public GameObject outercore = null;
	public GameObject actorA = null;

	public Texture2D speak2 = null;
	public Texture2D e1 = null;
	public Texture2D e2 = null;
	public GUIStyle exitstyle = null;

	private bool showdialog = false;
	private bool showtell = false;
	
	private Texture2D bg = null;
	private Texture2D cross1 = null;
	private Texture2D cross2= null;

	public Rect windowRect0 = new Rect(20, 20, 120, 50);
	public Rect windowRect1 = new Rect(30, 30, 120, 50);

	// Use this for initialization
	void Start () {
		cross1 = e1;
		cross2 = e2;
		//innercore.particleEmitter.emit=false;
		//outercore.particleEmitter.emit=false;	
	}

	void OnGUI(){
				if (showdialog) {
						bg = speak2;
						cross1 = e1;
						cross2 = e2;
						exitstyle.normal.background = cross1;
						exitstyle.hover.background = cross2;
						GUI.DrawTexture (new Rect (800,350,244,144), bg, ScaleMode.StretchToFill, true, 1);
						GUILayout.BeginArea (new Rect (1050,350,15,50));
						GUILayout.BeginVertical();

						windowRect0 = GUI.Window(0, windowRect0, DoMyWindow, "My Window");
						
						if (GUILayout.Button ("", exitstyle)) {
								showdialog = false;
								bg = null;
								cross1 = null;
								cross2 = null;
								loading.text=" ";
						}
						GUILayout.EndVertical ();
						GUILayout.EndArea ();
				}

			
				if (showtell) {
					bg = speak2;
					cross1 = e1;
					cross2 = e2;
					exitstyle.normal.background = cross1;
					exitstyle.hover.background = cross2;
					GUI.DrawTexture (new Rect (800,350,244,144), bg, ScaleMode.StretchToFill, true, 1);
					GUILayout.BeginArea (new Rect (1050,350,15,50));
					GUILayout.BeginVertical();

					windowRect1 = GUI.Window(0, windowRect1, DoWindow, "Window");
			
						if (GUILayout.Button ("", exitstyle)) {
							showtell = false;
							bg = null;
							cross1 = null;
							cross2 = null;
							loading.text=" ";
							}
						GUILayout.EndVertical ();
						GUILayout.EndArea ();
				}

		}

	void DoMyWindow(int windowID) {
		GUI.Label(new Rect (10, 20, 350, 200),"貓：美麗的女孩,我已經餓了好幾天了,可以給予我食物充飢嗎?");
		GUI.Label(new Rect (10, 50, 350, 200),"Unity娘：當然可以!我身上剛好有麵包,如果不嫌棄請拿去吃吧~");
		GUI.Label(new Rect (10, 80, 350, 200),"貓：真是漂亮又善良的女孩,請問妳一個人是要前往何處?");
		GUI.Label(new Rect (10, 110, 350, 200),"Unity娘：我要透過旅行增強自己的實力,總有一天復甦我曾經輝煌過的國家!!");
		GUI.Label(new Rect (10, 140, 350, 200),"貓：想不到您有如此遠大的目標,請讓我追隨於您,成為您微薄的力量!");
		GUI.Label(new Rect (10, 170, 350, 200),"Unity娘：好的,請多多指教");
		GUI.Label(new Rect (10, 200, 350, 200),"貓：我才是請您多多指教");


		if (GUI.Button (new Rect (50, 230, 100, 20), "成就達成")) {
						print ("成就達成 獲得同伴一名");
						loading.text="得到提示，直走下山找泉水";
				}

		GUI.DragWindow(new Rect(0, 0, 11000, 11000));
	}


	void DoWindow(int windowID){
		GUI.Label(new Rect (10, 20, 350, 200),"精靈：竟然有人可以找到這裡!!");
		GUI.Label(new Rect (10, 50, 350, 200),"Unity娘：是貓他要我到這來的!!");
		GUI.Label(new Rect (10, 80, 350, 200),"精靈：原來是你貓的朋友");
		GUI.Label(new Rect (10, 110, 350, 200),"Unity娘：是的!");
		GUI.Label(new Rect (10, 140, 350, 200),"精靈：這個泉水具有神奇的力量，可以幫助到你的");
		GUI.Label(new Rect (10, 170, 350, 200),"Unity娘：好的,謝謝你");
		GUI.Label(new Rect (10, 200, 350, 200),"精靈：不會");
		
		
		if (GUI.Button (new Rect (50, 230, 100, 20), "成就達成")) {
			print ("成就達成 獲得泉水");
			loading.text="獲得泉水";
		}
		
		GUI.DragWindow(new Rect(0, 0, 10000, 10000));

		}

	// Update is called once per frame
	void Update () {
	}
	void OnControllerColliderHit(ControllerColliderHit hit){
				if (hit.gameObject == cat) {
						//Debug.Log("ActorB hit");
						guitext.text = "cat hit";
						//cat.animation.Play ("jump_pose");
						showdialog = true;
			
						//saudio.PlayOneShot (audioclip1);
				}

				if (hit.gameObject == actorA) {
						guitext.text = "ActorA hit";
						actorA.animation.Play ("Actor A Jump");
						showtell=true;
				}
		}
}
