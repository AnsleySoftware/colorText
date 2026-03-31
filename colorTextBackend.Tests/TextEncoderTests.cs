namespace colorTextBackend.Tests
{
    public class TextEncoderTests
    {
        [Fact]
        public void EncodeTextToColor_HEY_ReturnsSingleCorrectHexColor()
        {
            TextEncoder encoder = new TextEncoder();
            string input = "HEY";
            List<string> expected = new List<string> { "#484559" };

            List<string> result = encoder.EncodeTextToColor(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void EncodeTextToColor_HI_ReturnsSingleCorrectHexColor()
        {
            TextEncoder encoder = new TextEncoder();
            string input = "HI";
            List<string> expected = new List<string> { "#484900" };

            List<string> result = encoder.EncodeTextToColor(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void EncodeTextToColor_A_ReturnsSingleCorrectHexColor()
        {
            TextEncoder encoder = new TextEncoder();
            string input = "A";
            List<string> expected = new List<string> { "#410000" };

            List<string> result = encoder.EncodeTextToColor(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void EncodeTextToColor_HI_JOHN_ReturnsMultipleCorrectHexColor()
        {
            TextEncoder encoder = new TextEncoder();
            string input = "HI JOHN";
            List<string> expected = new List<string> { "#484920", "#4A4F48", "#4E0000" };

            List<string> result = encoder.EncodeTextToColor(input);
            Assert.Equal(expected, result);
        }
    }
}