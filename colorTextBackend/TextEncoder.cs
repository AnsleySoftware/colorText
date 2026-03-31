namespace colorTextBackend
{
    public class TextEncoder
    {
        //First thing we need is a variable to hold a string, primarily for testing.
        private string _text = "test text";
        //we'll also need a list to hold all of our color hex codes:
        List<string> colors = new List<string>();

        //Then we need a method to perform the actual encoding.
        //I prefer a little verbosity in my names for the sake of clarity...
        //we'll also need a paramter for a string to take in input later...
        private List<string> EncodeTextToColor(string input)
        {
            //for now input will equal _text.
            input = _text;
            //now we need a for loop that can cut through that text in blocks of 3 characters.
            for (int i = 0; i < input.Length; i += 3)
            {
                //now it's time to start pulling out int values from the characters of the string using ascii
                int r = (int)input[i];
                int g = (i + 1 < input.Length) ? (int)input[i + 1] : 0;
                int b = (i + 2 < input.Length) ? (int)input[i + 2] : 0;
                //now that we have these ints extracted, we'll have to also expose their hex code for our later UI code to use.
                string hex = $"#{r.ToString("X2")}{g.ToString("X2")}{b.ToString("X2")}";
                //then add that hex color to the list. Later the UI will use this for display!
                colors.Add(hex);
            }
            return colors;
        }
    }
}
