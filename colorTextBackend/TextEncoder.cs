namespace colorTextBackend
{
    public class TextEncoder
    {
        
        List<string> colors = new List<string>();

        public List<string> EncodeTextToColor(string input)
        {
            
            for (int i = 0; i < input.Length; i += 3)
            {
                
                int r = (int)input[i];
                int g = (i + 1 < input.Length) ? (int)input[i + 1] : 0;
                int b = (i + 2 < input.Length) ? (int)input[i + 2] : 0;
                string hex = $"#{r.ToString("X2")}{g.ToString("X2")}{b.ToString("X2")}";
                colors.Add(hex);
            }
          
            return colors;
        }
    }
}
