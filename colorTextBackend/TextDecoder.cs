using System.ComponentModel;
using System.Text;

namespace colorTextBackend
{
    public class TextDecoder
    {
        //First thing we need is a reference to the encoder.
        TextEncoder encoder = new TextEncoder();
        List<string> colorsToDecode = new List<string>();

        public string DecodeColorToText(List<string> colorsToDecode)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < colorsToDecode.Count; i++)
            {
                string stripped = colorsToDecode[i].TrimStart('#');
                string rHex = stripped.Substring(0, 2);
                string gHex = stripped.Substring(2, 2);
                string bHex = stripped.Substring(4, 2);
                int rValue = Convert.ToInt32(rHex, 16);
                int gValue = Convert.ToInt32(gHex, 16);
                int bValue = Convert.ToInt32(bHex, 16);

                if (rValue != 0) result.Append((char)rValue);
                if (gValue != 0) result.Append((char)gValue);
                if (bValue != 0) result.Append((char)bValue);
            }
            return result.ToString();
        }
    }
}
