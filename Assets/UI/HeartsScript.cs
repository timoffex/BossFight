using UnityEngine;
using System.Collections;

public class HeartsScript : MonoBehaviour {

	public GameObject heartPrefab;
	public float hpPerHeart = 10f;


	private ArrayList hearts;
	private float lastHP;

	void Start () {
		hearts = new ArrayList ();
	}

	void Update () {
		var player = GameObject.FindGameObjectWithTag ("Player");
		var combat = player.GetComponent<Combat> ();

		if (combat != null) {
			if (lastHP != combat.health) {
				RedrawHearts ();
				lastHP = combat.health;
			}
		}
	}


	void RedrawHearts () {
		foreach (GameObject heart in hearts)
			Destroy (heart);

		hearts.Clear ();


		var player = GameObject.FindGameObjectWithTag ("Player");

		var combat = player.GetComponent<Combat> ();

		if (combat != null) {
			var numHearts = (int) (combat.health / hpPerHeart);


			for (int i = 0; i < numHearts; i++) {
				var heart = Instantiate (heartPrefab, transform) as GameObject;
				hearts.Add (heart);
			}

			PositionHearts ();
		}
	}


	void PositionHearts () {

		var heartSize = heartPrefab.GetComponent<RectTransform> ().rect.size;


		var rect = GetComponent<RectTransform> ();
		var min = rect.offsetMin;
		var max = rect.offsetMax;
		var width = max.x - min.x;



		var heartSpacing = width / (hearts.Count + 1f);

		if (heartSpacing > heartSize.x * 1.2f)
			heartSpacing = heartSize.x * 1.2f;

		var minX = width / 2f - heartSpacing * (hearts.Count + 1f) / 2f;


		for (int i = 0; i < hearts.Count; i++) {
			var heart = hearts[i] as GameObject;
			var heartRect = heart.GetComponent<RectTransform> ();

			heartRect.anchorMin = new Vector2(0, 0.5f);
			heartRect.anchorMax = new Vector2(0, 0.5f);

			var newPos = new Vector2 (minX + heartSpacing*(i+1), 0);

			var extents = heartRect.rect.size * 0.5f;
			heartRect.offsetMin = newPos - extents;
			heartRect.offsetMax = newPos + extents;
		}
	}
}
