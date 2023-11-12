namespace CalastoneTestApp
{
    public class InputSanitizer : IInputSanitizer
    {
        public string Sanitize(string input)
        {
            return Regex.Replace(input, @"[,](?=(\d+))(?<=(\d))", "");
        }
    }
}
