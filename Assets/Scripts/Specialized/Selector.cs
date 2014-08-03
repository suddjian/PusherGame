using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// used to filter what gameObjects you perform actions on
public class Selector {

	public int layerMask = 0;
	public LinkedList<string> tags = new LinkedList<string>();
	public LinkedList<string> names = new LinkedList<string>();

	public Selector() {

	}

	public Selector(int layerMask) {
		this.layerMask = layerMask;
	}

	public Selector(string tag) {
		tags.AddFirst(tag);
	}

	public bool Match(GameObject obj) {
		return Utils.InLayerMask(obj.layer, layerMask)
				|| tags.Contains(obj.tag)
				|| names.Contains(obj.name);
	}

	public bool Match(Component c) {
		return Match (c.gameObject);
	}
}
