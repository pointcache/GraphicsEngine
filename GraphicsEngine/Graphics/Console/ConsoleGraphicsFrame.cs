﻿namespace GraphicsEngine.Graphics.Console
{
	public class ConsoleGraphicsFrame
		: IConsoleGraphicsFrame
	{
		public const byte DefaultClearValue = 32;

		public ConsoleGraphicsFrame(int width, int height)
		{
			Width = width;
			Height = height;

			CharacterBuffer = new ConsoleCharacterBuffer(width, height);
			ColorBuffer = new ConsoleColorBuffer(width, height);
		}

		public ConsoleCharacterBuffer CharacterBuffer { get; private set; }
		public ConsoleColorBuffer ColorBuffer { get; private set; }
		public int Width { get; private set; }
		public int Height { get; private set; }

		IConsoleCharacterBuffer IConsoleGraphicsFrame.CharacterBuffer
		{
			get { return CharacterBuffer; }
		}

		IConsoleColorBuffer IConsoleGraphicsFrame.ColorBuffer
		{
			get { return ColorBuffer; }
		}

		public void ClearBuffers(byte? clearValue = null)
		{
			for (var x = 0; x < Width; x++)
			{
				for (var y = 0; y < Height; y++)
				{
					CharacterBuffer[x, y] = clearValue.HasValue ? clearValue.Value : DefaultClearValue;
					ColorBuffer[x, y] = clearValue.HasValue ? clearValue.Value : DefaultClearValue;
				}
			}
		}
	}
}