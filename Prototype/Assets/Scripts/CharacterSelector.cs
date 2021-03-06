﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour {

	public Character[] characters;
	public GameObject abilityPanel;
	private KeyCode[] charCodes = {
		KeyCode.Alpha1,
		KeyCode.Alpha2,
		KeyCode.Alpha3,
	};

	void Start() {
		OnCharacterSelect (0);
	}
		
	public void OnCharacterSelect(int characterChoice)
	{
		abilityPanel.SetActive (true);

		Character selectedCharacter = characters [characterChoice];

		/* Destroy current character and instantiate new character */
		if (CharacterControl.instance != null && CharacterControl.instance.player != null) {
			Transform t = CharacterControl.instance.player.transform;
			Destroy (CharacterControl.instance.player);
			CharacterControl.instance.player = Instantiate (selectedCharacter.prefab, t.transform.position, t.transform.rotation);
		} else {
			CharacterControl.instance.player = Instantiate (selectedCharacter.prefab);
		}

		CharacterControl.instance.jump_velocity = selectedCharacter.jump_velocity;

		if (CharacterControl.instance.characterNumber >= 0) {
			CharacterControl.instance.iconContainers [CharacterControl.instance.characterNumber].color += new Color (0, 0, 0, 180);
		}
		CharacterControl.instance.iconContainers [characterChoice].color -= new Color (0, 0, 0, 180);
		CharacterControl.instance.characterNumber = characterChoice;

		WeaponMarker weaponMarker = CharacterControl.instance.player.GetComponentInChildren<WeaponMarker> ();
		AbilityCoolDown[] coolDownButtons = GetComponentsInChildren<AbilityCoolDown> ();


		for (int i = 0; i < coolDownButtons.Length; i++) {
			coolDownButtons [i].Initialize (selectedCharacter.characterAbilities [i], weaponMarker.gameObject);
		}

        FindObjectOfType<AudioManager>().Play("Transform");

    }
	public void Update()
	{
		for (int i = 0; i < charCodes.Length; i++) {
			if (Input.GetKeyDown (charCodes [i])) {
				int numberPressed = i;
				OnCharacterSelect (numberPressed);
			}
		}
	}

}
