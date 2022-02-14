namespace SOLID
{
	// 2. OCP

	public enum SwitchType
	{
		Mechanical,
		Optical,
		Membrane,
		Scissor
	}

	public class Keyboard
	{
		private uint _keyNumber;
		private SwitchType _switchType;

		public Keyboard(uint keyNumber, SwitchType switchType)
		{
			_keyNumber = keyNumber;
			_switchType = switchType;
		}

		public uint KeyNumber => _keyNumber;
		public SwitchType SwitchType => _switchType;
	}

	public class RGBKeyboard : Keyboard
	{
		private uint _RgbZones;

		public RGBKeyboard(uint keyNumber, SwitchType switchType, uint rgbZones) : base(keyNumber, switchType)
		{
			_RgbZones = rgbZones;
		}

		public uint RgbZones => _RgbZones;
	}

	public class KeyboardWithTouchPanel : Keyboard
	{
		private readonly float _touchPanelSize;
		private readonly bool _multiTouchSupport;

		public KeyboardWithTouchPanel(
			uint keyNumber,
			SwitchType switchType,
			float touchPanelSize,
			bool multiTouchSupport
		) : base(keyNumber, switchType)
		{
			_touchPanelSize = touchPanelSize;
			_multiTouchSupport = multiTouchSupport;
		}

		public float TouchPanelSize => _touchPanelSize;
		public bool MultiTouchSupport => _multiTouchSupport;
	}
}