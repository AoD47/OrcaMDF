using System.Collections;

namespace OrcaMDF.Core.Pages
{
	public class ExtentAllocationMap : RecordPage
	{
		protected bool[] ExtentMap = new bool[63904];

		public ExtentAllocationMap(byte[] bytes, MdfFile file)
			: base(bytes, file)
		{
			parseBitmap();
		}

		private void parseBitmap()
		{
			byte[] bitmap = Records[1].FixedLengthData;
			
			int index = 0;

			// Skip first 98 bytes and last 10
			foreach (byte b in bitmap)
			{
				var ba = new BitArray(new[] { b });

				for (int i = 0; i < 8; i++)
					ExtentMap[index++] = ba[i];
			}
		}
	}
}