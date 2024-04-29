namespace MGM.Management.AppServices.Extensions
{
    public static class FileExtensions
    {
        static readonly List<byte> bmp = [0x42, 0x4D];
        static readonly List<byte> png = [0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A];

        static readonly List<(List<byte> magic, string extension)> imageFormats =
        [
            (bmp, "bmp"),
            (png, "png")
        ];

        public static void ExportToFile(this byte[] buffer, string path, string fileName, string extension)
        {
            
            var file = Path.Combine(path, string.Format("{0}.{1}", fileName, extension));
            if (File.Exists(file))
                File.Delete(file);

            File.WriteAllBytes(file, buffer);
        }

        public static void DeleteFile(string path, string fileName, string extension)
        {
            var file = Path.Combine(path, string.Format("{0}.{1}", fileName, extension));
            if (File.Exists(file))
                File.Delete(file);
        }

        public static string? TryGetExtension(byte[] array)
        {
            foreach (var (magic, extension) in imageFormats)
            {
                if (array.IsImage(magic))
                {
                    if (magic == bmp || magic == png)
                        return extension;
                }
            }

            return default;
        }

        private static bool IsImage(this byte[] array, List<byte> comparer, int offset = 0)
        {
            int arrayIndex = offset;
            foreach (byte c in comparer)
            {
                if (arrayIndex > array.Length - 1 || array[arrayIndex] != c)
                    return false;
                ++arrayIndex;
            }
            return true;
        }
    }
}
