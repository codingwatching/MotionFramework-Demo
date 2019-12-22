﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MotionFramework.Audio;

namespace Hotfix
{
	[Window(EWindowType.UISetting, EWindowLayer.Panel)]
	public class UISetting : UIWindow
	{
		private Slider _volumeSlider;
		private Toggle _musicToggle;
		private Toggle _soundToggle;

		public override void OnCreate()
		{
			AddButtonListener("UISetting/Mask", OnClickClose);
			AddButtonListener("UISetting/Window/Button (Save)", OnClickClose);

			_volumeSlider = GetUIComponent<Slider>("UISetting/Window/Content/Control Area (Slider)/Slider");
			_volumeSlider.onValueChanged.AddListener(OnSliderValueChange);
			_musicToggle = GetUIComponent<Toggle>("UISetting/Window/Content/Control Area (Toggles)/Toggle 1");
			_musicToggle.onValueChanged.AddListener(OnMusicToggleValueChange);
			_soundToggle = GetUIComponent<Toggle>("UISetting/Window/Content/Control Area (Toggles)/Toggle 2");
			_soundToggle.onValueChanged.AddListener(OnSoundToggleValueChange);
		}
		public override void OnDestroy()
		{
		}
		public override void OnRefresh()
		{
			_volumeSlider.value = AudioPlayerSetting.AudioVolume;
			_musicToggle.isOn = !AudioPlayerSetting.MusicMute;
			_soundToggle.isOn = !AudioPlayerSetting.SoundMute;
		}
		public override void OnUpdate()
		{
		}

		private void OnClickClose()
		{
			UIManager.Instance.CloseWindow(EWindowType.UISetting);
		}
		private void OnSliderValueChange(float value)
		{
			AudioPlayerSetting.AudioVolume = value;
		}
		private void OnMusicToggleValueChange(bool value)
		{
			AudioPlayerSetting.MusicMute = !value;
		}
		private void OnSoundToggleValueChange(bool value)
		{
			AudioPlayerSetting.SoundMute = !value;
		}
	}
}