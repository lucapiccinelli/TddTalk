namespace BirthdayGreetings.Tests.Docker
{
    public static class UnixStyle
    {
        public static string Path(string path) =>
            path.Replace(@"\", "/").Replace(@":/", "/");
    }
}