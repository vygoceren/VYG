namespace VYG.Core.ExtensionMethods
{
    public static class FileExtensions
    {
        public static bool IsImage(this FileInfo file)
        {
            string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            return imageExtensions.Contains(file.Extension.ToLower());
        }

        public static double GetSizeInKilobytes(this FileInfo file)
        {
            return file.Length / 1024.0;
        }
    }
}
