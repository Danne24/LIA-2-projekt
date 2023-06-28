namespace Zhipster.Internal.Api.Location.Helpers
{
	public static class FirstLetterIsCapitalHelper
	{
		public static string MakeFirstLetterBig(string stringToFormat)
		{
			if (stringToFormat == null || stringToFormat.Length == 0)
			{
				return string.Empty;
			}

			else if (stringToFormat.Length == 1)
			{
				stringToFormat = stringToFormat.ToUpper().Trim();
			}

			else
			{
				stringToFormat = stringToFormat.ToLower();
				stringToFormat = char.ToUpper(stringToFormat[0]) + stringToFormat.Substring(1).Trim();
			}

			return stringToFormat;
		}
	}
}