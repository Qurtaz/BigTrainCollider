using Holoville.HOTween;
using Holoville.HOTween.Core;
using Holoville.HOTween.Path;
using Holoville.HOTween.Plugins;
using Holoville.HOTween.Plugins.Core;
using UnityEngine;

/// <summary>
/// Some example of how to create tweens with HOTween.
/// To learn more and find more examples, go to http://hotween.holoville.com
/// </summary>
public class HOPathController : HOPathDemoBrain
{
    //public Transform CubeTrans1;
	//public Sequence sequence;
	//public GameObject zwrotnicaObject;
   // public Transform CubeTrans2;
	public HOPathDemoBrain zwrotnica;
	private GameObject zwrotnicaObject;
    // ===================================================================================
    // UNITY METHODS ---------------------------------------------------------------------

    void Start()
    {

		zwrotnicaObject = GameObject.FindWithTag ("Last");
		if (zwrotnicaObject != null)
		{	
			zwrotnica = zwrotnicaObject.GetComponent <HOPathDemoBrain>();
		}
		if (zwrotnicaObject == null)
		{
			Debug.Log ("Cannot find 'HOPathDemoBrain' script");
		}
		//zwrotnicaObject.tag = "Non-active";

        // HOTWEEN INITIALIZATION
        // Must be done only once, before the creation of your first tween
        // (you can skip this if you want, and HOTween will be initialized automatically
        // when you create your first tween - using default values)
        HOTween.Init(true, true, true);

        // TWEEN CREATION
        // With each one is shown a different way you can create a tween,
        // so that in the end you can choose what you prefer

        // Tween the first transform using fast writing mode,
        // and applying an animation that will last 4 seconds


		sequence = new Sequence (new SequenceParms ());//.Loops(-1, LoopType.Yoyo));
		sequence.Append (
	    HOTween.To(CubeTrans1, 8, new TweenParms()
			.Prop( "position", CubeTrans1.GetComponent<HOPath>().MakePlugVector3Path().OrientToPath())
		    //.Prop("rotation", new Vector3(0, 0, 0), true)
			.Loops(-1, LoopType.Yoyo)
			.Ease(EaseType.Linear)));
	   // HOTween.To(CubeTrans2, 2, new TweenParms()
		//	.Prop( "position", CubeTrans2.GetComponent<HOPath>().MakePlugVector3Path(), true)
		//	.Loops(-1, LoopType.Yoyo)
		//	.Ease(EaseType.Linear));
	

    }

	void Update ()
	{
		if (zwrotnica.sequence.isComplete) {

			zwrotnicaObject.tag = "Non-active";
			sequence.Play();
			this.tag = "Last";
		}
	}


}
