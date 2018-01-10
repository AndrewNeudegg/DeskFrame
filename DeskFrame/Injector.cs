// An incredible note of thanks goes to the hard work done by Gerald Degeneve, found here: https://www.codeproject.com/articles/856020/draw-behind-desktop-icons-in-windows. 
// While the author had detected SHELLDLL_DefView, they did not have the skills to extract the *undocumented* '0x052C' Progman Win message.


using System;
using DeskFrameLib;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace DeskFrame
{
    /// <summary>
    /// Injects a .net windows form into the child of the WorkerW view as to sit above the SHELLDLL_DefView.
    /// </summary>
    public class Injector : IDisposable
    {
        private Form _activeForm = null;
        private IDeskFrameView _activeView = null;
        private bool _hasInjected = false;

        public Injector(IDeskFrameView view)
        {
            // Todo: Init.
            // Todo: Windows Version Detect.
            _activeView = view;
            _activeForm = view.view;
            // Spawn in workerw.
            SpawnWorkerw();
            // Get the workerw.
            IntPtr workerw = GetWorkerw();
            // Assign our form as a child.
            Loadin(workerw, _activeForm);
            _hasInjected = true;
        }

        ~Injector()
        {
            Deconstruct();
        }



        public void RunDeskFrame()
        {
            Application.Run(_activeForm);
        }

        private void Deconstruct()
        {
            // Todo: Safe close.
            // Kill Explorer.exe and restart.

            // Check we need to do something.
            if (!_hasInjected)
            {
                return;
            }

            // Ensure we aren't running on empty.
            if (_activeForm != null)
            {
                // Permit advanced warning of close.
            }

            KillExplorerShell();
            StartExplorerShell();
        }


        /// <summary>
        /// Starts a new instance of explorer.
        /// </summary>
        private void StartExplorerShell()
        {
            ProcessStartInfo explorerInfo = new ProcessStartInfo();
            explorerInfo.FileName = @"cmd";
            explorerInfo.Arguments = "/C start cmd.exe";
            explorerInfo.WindowStyle = ProcessWindowStyle.Hidden;
            // As soon as we have started cmd, wait a bit then kill it.
            Process explorer = Process.Start(explorerInfo);
            Thread.Sleep(50);
            explorer.Kill();
        }

        private void KillExplorerShell()
        {
            // Simple find and kill all explorer instances.
            // If we don't some of these processes will become orphaned and unkillable.
            foreach (Process p in Process.GetProcessesByName("explorer"))
            {
                p.Kill();
            }
        }

        private void Loadin(IntPtr workerw, Form form)
        {
            WinLib.SetParent(form.Handle, workerw);
        }



        /// <summary>
        /// Spawns the workerw child using the undocumented 0x052C command.
        /// </summary>
        /// <returns></returns>
        private IntPtr SpawnWorkerw()
        {
            IntPtr progman = WinLib.FindWindow("Progman", null);
            IntPtr result = IntPtr.Zero;
            // Sending 0x052C to progman will spawn the workerw process if it is not already present.
            WinLib.SendMessageTimeout(progman,
                                   0x052C,
                                   new IntPtr(0),
                                   IntPtr.Zero,
                                   WinLib.SendMessageTimeoutFlags.SMTO_NORMAL,
                                   500, // *Lowered value
                                   out result);
            return result;
        }


        /// <summary>
        /// Gets the IntPtr for Worker, correcting for misalignment.
        /// </summary>
        /// <returns></returns>
        private IntPtr GetWorkerw()
        {
            // We enumerate all Windows, until we find one, that has the SHELLDLL_DefView 
            // as a child. 
            // If we found that window, we take its next sibling and assign it to workerw.
            IntPtr workerw = IntPtr.Zero;
            WinLib.EnumWindows(new WinLib.EnumWindowsProc((tophandle, topparamhandle) =>
            {
                IntPtr p = WinLib.FindWindowEx(tophandle,
                                            IntPtr.Zero,
                                            "SHELLDLL_DefView",
                                            IntPtr.Zero);

                if (p != IntPtr.Zero)
                {
                    // Gets the WorkerW Window after the current one.
                    workerw = WinLib.FindWindowEx(IntPtr.Zero,
                                               tophandle,
                                               "WorkerW",
                                               IntPtr.Zero);
                }

                return true;
            }), IntPtr.Zero);
            return workerw;
        }

        public void Dispose()
        {
            Deconstruct();
        }
    }
}




