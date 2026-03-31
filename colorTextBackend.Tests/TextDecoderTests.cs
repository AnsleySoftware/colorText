namespace colorTextBackend.Tests
{
    public class TextDecoderTests
    {
        [Fact]
        public void DecodeColorToText_HEY_ReturnsCorrectString()
        {
            TextDecoder decoder = new TextDecoder();
            List<string> toDecode = new List<string> { "#484559" };
            string expected = "HEY";
            string result = decoder.DecodeColorToText(toDecode);
            Assert.Equal(expected, result);
        }

        [Fact]

        public void DecodeColorToText_HI_ReturnsCorrectString()
        {
            TextDecoder decoder = new TextDecoder();
            List<string> toDecode = new List<string> { "#484900" };
            string expected = "HI";
            string result = decoder.DecodeColorToText(toDecode);
            Assert.Equal(expected, result);
        }

        [Fact]

        public void DecodeColorToText_A_ReturnsCorrectString()
        {
            TextDecoder decoder = new TextDecoder();
            List<string> toDecode = new List<string> { "#410000" };
            string expected = "A";
            string result = decoder.DecodeColorToText(toDecode);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DecodeColorToText_HI_JOHN_ReturnsCorrectString()
        {
            TextDecoder decoder = new TextDecoder();
            List<string> toDecode = new List<string> { "#484920", "#4A4F48", "#4E0000" };
            string expected = "HI JOHN";
            string result = decoder.DecodeColorToText(toDecode);
            Assert.Equal(expected, result);
        }
    }
}
