using System;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.ComponentModel;
using Y.FileQueryEngine.Win32.Constants;
using Y.FileQueryEngine.Win32.Structures;

namespace Y.FileQueryEngine.Win32
{
    internal class Win32Api
    {
        private const string KERNEL32DLL = "kernel32.dll";

        private const string USER32DLL = "user32.dll";

        #region dll imports

        /// <summary>
        /// Creates the file specified by 'lpFileName' with desired access, share mode, security attributes,
        /// creation disposition, flags and attributes.
        /// </summary>
        /// <param name="lpFileName">Fully qualified path to a file</param>
        /// <param name="dwDesiredAccess">Requested access (write, read, read/write, none)</param>
        /// <param name="dwShareMode">Share mode (read, write, read/write, delete, all, none)</param>
        /// <param name="lpSecurityAttributes">IntPtr to a 'SECURITY_ATTRIBUTES' structure</param>
        /// <param name="dwCreationDisposition">Action to take on file or device specified by 'lpFileName' (CREATE_NEW,
        /// CREATE_ALWAYS, OPEN_ALWAYS, OPEN_EXISTING, TRUNCATE_EXISTING)</param>
        /// <param name="dwFlagsAndAttributes">File or device attributes and flags (typically FILE_ATTRIBUTE_NORMAL)</param>
        /// <param name="hTemplateFile">IntPtr to a valid handle to a template file with 'GENERIC_READ' access right</param>
        /// <returns>IntPtr handle to the 'lpFileName' file or device or 'INVALID_HANDLE_VALUE'</returns>
        [DllImport(KERNEL32DLL, SetLastError = true)]
        public static extern IntPtr CreateFile(string lpFileName,
            uint dwDesiredAccess,
            uint dwShareMode,
            IntPtr lpSecurityAttributes,
            uint dwCreationDisposition,
            uint dwFlagsAndAttributes,
            IntPtr hTemplateFile);

        /// <summary>
        /// Closes the file specified by the IntPtr 'hObject'.
        /// </summary>
        /// <param name="hObject">IntPtr handle to a file</param>
        /// <returns>'true' if successful, otherwise 'false'</returns>
        [DllImport(KERNEL32DLL, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(
            IntPtr hObject);

        /// <summary>
        /// Fills the 'BY_HANDLE_FILE_INFORMATION' structure for the file specified by 'hFile'.
        /// </summary>
        /// <param name="hFile">Fully qualified name of a file</param>
        /// <param name="lpFileInformation">Out BY_HANDLE_FILE_INFORMATION argument</param>
        /// <returns>'true' if successful, otherwise 'false'</returns>
        [DllImport(KERNEL32DLL, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetFileInformationByHandle(
            IntPtr hFile,
            out BY_HANDLE_FILE_INFORMATION lpFileInformation);

        /// <summary>
        /// Deletes the file specified by 'fileName'.
        /// </summary>
        /// <param name="fileName">Fully qualified path to the file to delete</param>
        /// <returns>'true' if successful, otherwise 'false'</returns>
        [DllImport(KERNEL32DLL, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteFile(
            string fileName);

        /// <summary>
        /// Read data from the file specified by 'hFile'.
        /// </summary>
        /// <param name="hFile">IntPtr handle to the file to read</param>
        /// <param name="lpBuffer">IntPtr to a buffer of bytes to receive the bytes read from 'hFile'</param>
        /// <param name="nNumberOfBytesToRead">Number of bytes to read from 'hFile'</param>
        /// <param name="lpNumberOfBytesRead">Number of bytes read from 'hFile'</param>
        /// <param name="lpOverlapped">IntPtr to an 'OVERLAPPED' structure</param>
        /// <returns>'true' if successful, otherwise 'false'</returns>
        [DllImport(KERNEL32DLL)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadFile(
            IntPtr hFile,
            IntPtr lpBuffer,
            uint nNumberOfBytesToRead,
            out uint lpNumberOfBytesRead,
            IntPtr lpOverlapped);

        /// <summary>
        /// Writes the 
        /// </summary>
        /// <param name="hFile">IntPtr handle to the file to write</param>
        /// <param name="bytes">IntPtr to a buffer of bytes to write to 'hFile'</param>
        /// <param name="nNumberOfBytesToWrite">Number of bytes in 'lpBuffer' to write to 'hFile'</param>
        /// <param name="lpNumberOfBytesWritten">Number of bytes written to 'hFile'</param>
        /// <param name="overlapped">IntPtr to an 'OVERLAPPED' structure</param>
        /// <returns>'true' if successful, otherwise 'false'</returns>
        [DllImport(KERNEL32DLL, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WriteFile(
            IntPtr hFile,
            IntPtr bytes,
            uint nNumberOfBytesToWrite,
            out uint lpNumberOfBytesWritten,
            int overlapped);

        /// <summary>
        /// Writes the data in 'lpBuffer' to the file specified by 'hFile'.
        /// </summary>
        /// <param name="hFile">IntPtr handle to file to write</param>
        /// <param name="lpBuffer">Buffer of bytes to write to file 'hFile'</param>
        /// <param name="nNumberOfBytesToWrite">Number of bytes in 'lpBuffer' to write to 'hFile'</param>
        /// <param name="lpNumberOfBytesWritten">Number of bytes written to 'hFile'</param>
        /// <param name="overlapped">IntPtr to an 'OVERLAPPED' structure</param>
        /// <returns>'true' if successful, otherwise 'false'</returns>
        [DllImport(KERNEL32DLL, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WriteFile(
            IntPtr hFile,
            byte[] lpBuffer,
            uint nNumberOfBytesToWrite,
            out uint lpNumberOfBytesWritten,
            int overlapped);

        /// <summary>
        /// Sends the 'dwIoControlCode' to the device specified by 'hDevice'.
        /// </summary>
        /// <param name="hDevice">IntPtr handle to the device to receive 'dwIoControlCode'</param>
        /// <param name="dwIoControlCode">Device IO Control Code to send</param>
        /// <param name="lpInBuffer">Input buffer if required</param>
        /// <param name="nInBufferSize">Size of input buffer</param>
        /// <param name="lpOutBuffer">Output buffer if required</param>
        /// <param name="nOutBufferSize">Size of output buffer</param>
        /// <param name="lpBytesReturned">Number of bytes returned in output buffer</param>
        /// <param name="lpOverlapped">IntPtr to an 'OVERLAPPED' structure</param>
        /// <returns>'true' if successful, otherwise 'false'</returns>
        [DllImport(KERNEL32DLL, ExactSpelling = true, SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeviceIoControl(
            IntPtr hDevice,
            UInt32 dwIoControlCode,
            IntPtr lpInBuffer,
            Int32 nInBufferSize,
            out USN_JOURNAL_DATA lpOutBuffer,
            Int32 nOutBufferSize,
            out uint lpBytesReturned,
            IntPtr lpOverlapped);

        /// <summary>
        /// Sends the control code 'dwIoControlCode' to the device driver specified by 'hDevice'.
        /// </summary>
        /// <param name="hDevice">IntPtr handle to the device to receive 'dwIoControlCode</param>
        /// <param name="dwIoControlCode">Device IO Control Code to send</param>
        /// <param name="lpInBuffer">Input buffer if required</param>
        /// <param name="nInBufferSize">Size of input buffer </param>
        /// <param name="lpOutBuffer">Output buffer if required</param>
        /// <param name="nOutBufferSize">Size of output buffer</param>
        /// <param name="lpBytesReturned">Number of bytes returned</param>
        /// <param name="lpOverlapped">Pointer to an 'OVERLAPPED' struture</param>
        /// <returns></returns>
        [DllImport(KERNEL32DLL, ExactSpelling = true, SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeviceIoControl(
            IntPtr hDevice,
            UInt32 dwIoControlCode,
            IntPtr lpInBuffer,
            Int32 nInBufferSize,
            IntPtr lpOutBuffer,
            Int32 nOutBufferSize,
            out uint lpBytesReturned,
            IntPtr lpOverlapped);

        /// <summary>
        /// Sets the number of bytes specified by 'size' of the memory associated with the argument 'ptr' 
        /// to zero.
        /// </summary>
        /// <param name="ptr"></param>
        /// <param name="size"></param>
        [DllImport(KERNEL32DLL)]
        public static extern void ZeroMemory(IntPtr ptr, int size);

        [DllImport(USER32DLL, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(out POINT pt);

        [DllImport(USER32DLL, CharSet = CharSet.Auto)]
        public static extern Int32 GetWindowLong(IntPtr hWnd, Int32 nIndex);

        [DllImport(USER32DLL, CharSet = CharSet.Auto)]
        public static extern Int32 SetWindowLong(IntPtr hWnd, Int32 nIndex, Int32 newVal);

        #endregion

        #region functions

        /// <summary>
        /// Writes the data in 'text' to the alternate stream ':Description' of the file 'currentFile.
        /// </summary>
        /// <param name="currentfile">Fully qualified path to a file</param>
        /// <param name="text">Data to write to the ':Description' stream</param>
        public static void WriteAlternateStream(string currentfile, string text)
        {
            string AltStreamDesc = currentfile + ":Description";
            IntPtr txtBuffer = IntPtr.Zero;
            IntPtr hFile = IntPtr.Zero;
            DeleteFile(AltStreamDesc);
            string descText = text.TrimEnd(' ');

            try
            {
                hFile = CreateFile(AltStreamDesc, Win32ApiConstant.GENERIC_WRITE, 0, IntPtr.Zero,
                                       Win32ApiConstant.CREATE_ALWAYS, 0, IntPtr.Zero);
                if (-1 != hFile.ToInt32())
                {
                    txtBuffer = Marshal.StringToHGlobalUni(descText);
                    uint nBytes, count;
                    nBytes = (uint)descText.Length;
                    bool bRtn = WriteFile(hFile, txtBuffer, sizeof(char) * nBytes, out count, 0);
                    if (!bRtn)
                    {
                        if ((sizeof(char) * nBytes) != count)
                        {
                            throw new Exception(string.Format("Bytes written {0} should be {1} for file {2}.",
                                count, sizeof(char) * nBytes, AltStreamDesc));
                        }
                        else
                        {
                            throw new Exception("WriteFile() returned false");
                        }
                    }
                }
                else
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
            }
            catch (Exception exception)
            {
                //string msg = string.Format("Exception caught in WriteAlternateStream()\n  '{0}'\n  for file '{1}'.",
                //    exception.Message, AltStreamDesc);
                //Console.WriiteLine(msg);
                throw;
            }
            finally
            {
                CloseHandle(hFile);
                hFile = IntPtr.Zero;
                Marshal.FreeHGlobal(txtBuffer);
                GC.Collect();
            }
        }

        /// <summary>
        /// Adds the ':Description' alternate stream name to the argument 'currentFile'.
        /// </summary>
        /// <param name="currentfile">The file whose alternate stream is to be read</param>
        /// <returns>A string value representing the value of the alternate stream</returns>
        public static string ReadAlternateStream(string currentfile)
        {
            string AltStreamDesc = currentfile + ":Description";
            string returnstring = ReadAlternateStreamEx(AltStreamDesc);
            return returnstring;
        }

        /// <summary>
        /// Reads the stream represented by 'currentFile'.
        /// </summary>
        /// <param name="currentfile">Fully qualified path including stream</param>
        /// <returns>Value of the alternate stream as a string</returns>
        public static string ReadAlternateStreamEx(string currentfile)
        {
            string returnstring = string.Empty;
            IntPtr hFile = IntPtr.Zero;
            IntPtr buffer = IntPtr.Zero;
            try
            {
                hFile = CreateFile(currentfile, Win32ApiConstant.GENERIC_READ, 0, IntPtr.Zero, Win32ApiConstant.OPEN_EXISTING, 0, IntPtr.Zero);
                if (-1 != hFile.ToInt32())
                {
                    buffer = Marshal.AllocHGlobal(1000 * sizeof(char));
                    ZeroMemory(buffer, 1000 * sizeof(char));
                    uint nBytes;
                    bool bRtn = ReadFile(hFile, buffer, 1000 * sizeof(char), out nBytes, IntPtr.Zero);
                    if (bRtn)
                    {
                        if (nBytes > 0)
                        {
                            returnstring = Marshal.PtrToStringAuto(buffer);
                            //byte[] byteBuffer = new byte[nBytes];
                            //for (int i = 0; i < nBytes; i++)
                            //{
                            //    byteBuffer[i] = Marshal.ReadByte(buffer, i);
                            //}
                            //returnstring = Encoding.Unicode.GetString(byteBuffer, 0, (int)nBytes);
                        }
                        else
                        {
                            throw new Exception("ReadFile() returned true but read zero bytes");
                        }
                    }
                    else
                    {
                        if (nBytes <= 0)
                        {
                            throw new Exception("ReadFile() read zero bytes.");
                        }
                        else
                        {
                            throw new Exception("ReadFile() returned false");
                        }
                    }
                }
                else
                {
                    Exception excptn = new Win32Exception(Marshal.GetLastWin32Error());
                    if (!excptn.Message.Contains("cannot find the file"))
                    {
                        throw excptn;
                    }
                }
            }
            catch (Exception exception)
            {
                //string msg = string.Format("Exception caught in ReadAlternateStream(), '{0}'\n  for file '{1}'.",
                //    exception.Message, currentfile);
                //Console.WriteLine(msg);
                //Console.WriteLine(exception.Message);
                throw;
            }
            finally
            {
                CloseHandle(hFile);
                hFile = IntPtr.Zero;
                if (buffer != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(buffer);
                }
                GC.Collect();
            }
            return returnstring;
        }

        /// <summary>
        /// Read the encrypted alternate stream specified by 'currentFile'.
        /// </summary>
        /// <param name="currentfile">Fully qualified path to encrypted alternate stream</param>
        /// <returns>The un-encrypted value of the alternate stream as a string</returns>
        public static string ReadAlternateStreamEncrypted(string currentfile)
        {
            string returnstring = string.Empty;
            IntPtr buffer = IntPtr.Zero;
            IntPtr hFile = IntPtr.Zero;
            try
            {
                hFile = CreateFile(currentfile, Win32ApiConstant.GENERIC_READ, 0, IntPtr.Zero, Win32ApiConstant.OPEN_EXISTING, 0, IntPtr.Zero);
                if (-1 != hFile.ToInt32())
                {
                    buffer = Marshal.AllocHGlobal(1000 * sizeof(char));
                    ZeroMemory(buffer, 1000 * sizeof(char));
                    uint nBytes;
                    bool bRtn = ReadFile(hFile, buffer, 1000 * sizeof(char), out nBytes, IntPtr.Zero);
                    if (0 != nBytes)
                    {
                        returnstring = DecryptLicenseString(buffer, nBytes);
                    }
                }
                else
                {
                    Exception excptn = new Win32Exception(Marshal.GetLastWin32Error());
                    if (!excptn.Message.Contains("cannot find the file"))
                    {
                        throw excptn;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception caught in ReadAlternateStreamEncrypted()");
                Console.WriteLine(exception.Message);
            }
            finally
            {
                CloseHandle(hFile);
                hFile = IntPtr.Zero;
                if (buffer != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(buffer);
                }
                GC.Collect();
            }
            return returnstring;
        }

        /// <summary>
        /// Writes the value of 'LicenseString' as an encrypted stream to the file:stream specified
        /// by 'currentFile'.
        /// </summary>
        /// <param name="currentFile">Fully qualified path to the alternate stream</param>
        /// <param name="LicenseString">The string value to encrypt and write to the alternate stream</param>
        public static void WriteAlternateStreamEncrypted(string currentFile, string LicenseString)
        {
            RC2CryptoServiceProvider rc2 = null;
            CryptoStream cs = null;
            MemoryStream ms = null;
            uint count = 0;
            IntPtr buffer = IntPtr.Zero;
            IntPtr hFile = IntPtr.Zero;
            try
            {
                Encoding enc = Encoding.Unicode;

                byte[] ba = enc.GetBytes(LicenseString);
                ms = new MemoryStream();

                rc2 = new RC2CryptoServiceProvider();
                rc2.Key = GetBytesFromHexString("7a6823a42a3a3ae27057c647db812d0");
                rc2.IV = GetBytesFromHexString("827d961224d99b2d");

                cs = new CryptoStream(ms, rc2.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(ba, 0, ba.Length);
                cs.FlushFinalBlock();

                buffer = Marshal.AllocHGlobal(1000 * sizeof(char));
                ZeroMemory(buffer, 1000 * sizeof(char));
                uint nBytes = (uint)ms.Length;
                Marshal.Copy(ms.GetBuffer(), 0, buffer, (int)nBytes);

                DeleteFile(currentFile);
                hFile = CreateFile(currentFile, Win32ApiConstant.GENERIC_WRITE, 0, IntPtr.Zero,
                                       Win32ApiConstant.CREATE_ALWAYS, 0, IntPtr.Zero);
                if (-1 != hFile.ToInt32())
                {
                    bool bRtn = WriteFile(hFile, buffer, nBytes, out count, 0);
                }
                else
                {
                    Exception excptn = new Win32Exception(Marshal.GetLastWin32Error());
                    if (!excptn.Message.Contains("cannot find the file"))
                    {
                        throw excptn;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("WriteAlternateStreamEncrypted()");
                Console.WriteLine(exception.Message);
            }
            finally
            {
                CloseHandle(hFile);
                hFile = IntPtr.Zero;
                if (cs != null)
                {
                    cs.Close();
                    cs.Dispose();
                }

                rc2 = null;
                if (ms != null)
                {
                    ms.Close();
                    ms.Dispose();
                }
                if (buffer != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(buffer);
                }
            }
        }

        /// <summary>
        /// Encrypt the string 'LicenseString' argument and return as a MemoryStream.
        /// </summary>
        /// <param name="LicenseString">The string value to encrypt</param>
        /// <returns>A MemoryStream which contains the encrypted value of 'LicenseString'</returns>
        private static MemoryStream EncryptLicenseString(string LicenseString)
        {
            Encoding enc = Encoding.Unicode;

            byte[] ba = enc.GetBytes(LicenseString);
            MemoryStream ms = new MemoryStream();

            RC2CryptoServiceProvider rc2 = new RC2CryptoServiceProvider();
            rc2.Key = GetBytesFromHexString("7a6823a42a3a3ae27057c647db812d0");
            rc2.IV = GetBytesFromHexString("827d961224d99b2d");

            CryptoStream cs = new CryptoStream(ms, rc2.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(ba, 0, ba.Length);

            cs.Close();
            cs.Dispose();
            rc2 = null;
            return ms;
        }

        /// <summary>
        /// Given an IntPtr to a bufer and the number of bytes, decrypt the buffer and return an 
        /// unencrypted text string.
        /// </summary>
        /// <param name="buffer">An IntPtr to the 'buffer' containing the encrypted string</param>
        /// <param name="nBytes">The number of bytes in 'buffer' to decrypt</param>
        /// <returns></returns>
        private static string DecryptLicenseString(IntPtr buffer, uint nBytes)
        {
            byte[] ba = new byte[nBytes];
            for (int i = 0; i < nBytes; i++)
            {
                ba[i] = Marshal.ReadByte(buffer, i);
            }
            MemoryStream ms = new MemoryStream(ba);

            RC2CryptoServiceProvider rc2 = new RC2CryptoServiceProvider();
            rc2.Key = GetBytesFromHexString("7a6823a42a3a3ae27057c647db812d0");
            rc2.IV = GetBytesFromHexString("827d961224d99b2d");

            CryptoStream cs = new CryptoStream(ms, rc2.CreateDecryptor(), CryptoStreamMode.Read);
            string licenseString = string.Empty;
            byte[] ba1 = new byte[4096];
            int irtn = cs.Read(ba1, 0, 4096);
            Encoding enc = Encoding.Unicode;
            licenseString = enc.GetString(ba1, 0, irtn);

            cs.Close();
            cs.Dispose();
            ms.Close();
            ms.Dispose();
            rc2 = null;
            return licenseString;
        }

        /// <summary>
        /// Gets the byte array generated from the value of 'hexString'.
        /// </summary>
        /// <param name="hexString">Hexadecimal string</param>
        /// <returns>Array of bytes generated from 'hexString'.</returns>
        public static byte[] GetBytesFromHexString(string hexString)
        {
            int numHexChars = hexString.Length / 2;
            byte[] ba = new byte[numHexChars];
            int j = 0;
            for (int i = 0; i < ba.Length; i++)
            {
                string hex = new string(new char[] { hexString[j], hexString[j + 1] });
                ba[i] = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                j = j + 2;
            }
            return ba;
        }

        #endregion
    }
}
