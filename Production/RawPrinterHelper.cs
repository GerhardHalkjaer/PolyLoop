using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Production
{

    public class RawPrinterHelper
    {
        // Structure and API declarations:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true)]
        private static extern bool OpenPrinter(string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", SetLastError = true)]
        private static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true)]
        private static extern bool StartDocPrinter(IntPtr hPrinter, int level, [In] DOCINFOA di);

        [DllImport("winspool.Drv", SetLastError = true)]
        private static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", SetLastError = true)]
        private static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", SetLastError = true)]
        private static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", SetLastError = true)]
        private static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

        /// <summary>
        /// Sends raw bytes to the specified printer.
        /// </summary>
        /// <param name="printerName">Name of the printer.</param>
        /// <param name="pBytes">Pointer to the bytes to send.</param>
        /// <param name="dwCount">Number of bytes to send.</param>
        /// <returns>True if successful; otherwise, false.</returns>
        public static bool SendBytesToPrinter(string printerName, IntPtr pBytes, int dwCount)
        {
            IntPtr hPrinter = IntPtr.Zero;
            DOCINFOA di = new DOCINFOA
            {
                pDocName = "Raw Document",
                pDataType = "RAW"
            };
            bool success = false;
            int dwWritten = 0;

            if (OpenPrinter(printerName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    if (StartPagePrinter(hPrinter))
                    {
                        success = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }

            return success;
        }

        /// <summary>
        /// Sends a byte array to the specified printer.
        /// </summary>
        /// <param name="printerName">Name of the printer.</param>
        /// <param name="bytes">Byte array to send.</param>
        /// <returns>True if successful; otherwise, false.</returns>
        public static bool SendBytesToPrinter(string printerName, byte[] bytes)
        {
            IntPtr unmanagedBytes = Marshal.AllocCoTaskMem(bytes.Length);
            Marshal.Copy(bytes, 0, unmanagedBytes, bytes.Length);
            bool success = SendBytesToPrinter(printerName, unmanagedBytes, bytes.Length);
            Marshal.FreeCoTaskMem(unmanagedBytes);
            return success;
        }

        /// <summary>
        /// Sends a string to the specified printer using ASCII encoding.
        /// </summary>
        /// <param name="printerName">Name of the printer.</param>
        /// <param name="data">String data to send.</param>
        /// <returns>True if successful; otherwise, false.</returns>
        public static bool SendStringToPrinter(string printerName, string data)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(data);
            return SendBytesToPrinter(printerName, bytes);
        }
    }

}
