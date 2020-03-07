using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notepad;
using IWshRuntimeLibrary;
using System.Net;
using System.Media;

namespace Ricard0overtaker
{
    class Program
    {
        public static readonly string ICO_LNK = "https://raw.githubusercontent.com/lmnyx/ricard0overtaker/master/icon.ico";
        public static readonly string BG_LNK = "https://raw.githubusercontent.com/lmnyx/ricard0overtaker/master/background.png";
        public static readonly string U_LNK = "https://github.com/lmnyx/ricard0overtaker/blob/master/u.wav?raw=true";

        static void Main(string[] args)
        {
            WebClient webdl = new WebClient();
            if (!System.IO.File.Exists(Path.GetTempPath() + "/ricardo_ico.ico"))
                webdl.DownloadFile(ICO_LNK, Path.GetTempPath() + "/ricardo_ico.ico");
            Console.WriteLine("Finished downloading Ricardo icon.");
            if(!System.IO.File.Exists(Path.GetTempPath() + "/ricardo_bg.png"))
                webdl.DownloadFile(BG_LNK, Path.GetTempPath() + "/ricardo_bg.png");
            Console.WriteLine("Finished downloading Ricardo background.");
            if (!System.IO.File.Exists(Path.GetTempPath() + "/ricardo_u.wav"))
                webdl.DownloadFile(U_LNK, Path.GetTempPath() + "/ricardo_u.wav");
            Console.WriteLine("Finished downloading U Got That.");
            Console.WriteLine("Reiconning links at desktop.");
            WshShell Shell = new WshShell();
            foreach (string lnk in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "*.lnk", SearchOption.AllDirectories))
            {
                WshShortcut cl = (WshShortcut)Shell.CreateShortcut(lnk);
                cl.IconLocation = Path.GetTempPath() + "/ricardo_ico.ico";
                cl.Save();
                Console.WriteLine(ConsoleColor.Green + lnk);
            }
            Console.WriteLine("Enough with lnks! Let's set wallpaper.");
            Wallpaper.GetBackgroud();
            Wallpaper.SetBackgroud(Path.GetTempPath() + "/ricardo_bg.png");
            SoundPlayer mw = new SoundPlayer(Path.GetTempPath() + "/ricardo_u.wav");
            NotepadHelper.ShowMessage("ur pc was danced till the death\nwe are now vibing at ur pc haha\nu got that", "ricard0overtaker::_overtaken");
            Console.WriteLine("Finished. Showed the notepad message.");
            mw.PlaySync();
        }
    }
}
