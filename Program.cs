using dnlib.DotNet.Emit;
using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpcodeRemover.Helper;
using Console = Colorful.Console;
using dnlib.DotNet.Writer;
using OpcodeRemover.Helper;

namespace OpcodeRemover
{
    internal class Program
    {
        public static string Art = @"
    ██╗███╗   ██╗██╗   ██╗ █████╗ ██╗     ██╗██████╗      ██████╗ ██████╗  ██████╗ ██████╗ ██████╗ ███████╗
    ██║████╗  ██║██║   ██║██╔══██╗██║     ██║██╔══██╗    ██╔═══██╗██╔══██╗██╔════╝██╔═══██╗██╔══██╗██╔════╝
    ██║██╔██╗ ██║██║   ██║███████║██║     ██║██║  ██║    ██║   ██║██████╔╝██║     ██║   ██║██║  ██║█████╗  
    ██║██║╚██╗██║╚██╗ ██╔╝██╔══██║██║     ██║██║  ██║    ██║   ██║██╔═══╝ ██║     ██║   ██║██║  ██║██╔══╝  
    ██║██║ ╚████║ ╚████╔╝ ██║  ██║███████╗██║██████╔╝    ╚██████╔╝██║     ╚██████╗╚██████╔╝██████╔╝███████╗
    ╚═╝╚═╝  ╚═══╝  ╚═══╝  ╚═╝  ╚═╝╚══════╝╚═╝╚═════╝      ╚═════╝ ╚═╝      ╚═════╝ ╚═════╝ ╚═════╝ ╚══════╝
";


        public static string Credits = "    Invalid Opcode Remover by Nakateru";
        static void Main(string[] args)
        {
            Console.Title = Credits;
            Console.WriteLine(Art, Color.Aqua);
            Console.WriteLine(Credits + Environment.NewLine, Color.Turquoise);

            if (args.Length == 0)
            {
                Prefix("!", "No Assembly has been found!", Color.Red); 
                Thread.Sleep(5000);
                Environment.Exit(1);
            }

            // Load the Assembly

            AssemblyDef assembly = AssemblyDef.Load(args[0]);
            Context context = new Context(assembly);
            context.moduleDefMD = ModuleDefMD.Load(args[0]);

            Helper.Fixer.Deobfuscate(context.moduleDef);

            var Options = new ModuleWriterOptions(assembly.ManifestModule);
            Options.Logger = DummyLogger.NoThrowInstance;
            assembly.Write(args[0].Replace(".exe", "_fixed.exe"), Options);
            Console.Beep(500, 500);

            Console.ReadKey();

        }

        public static void Prefix(string prefix, string suffix, Color color)
        {
            Console.Write("    {", color);
            Console.Write(prefix, Color.White);
            Console.Write("} ", color);
            Console.Write(suffix, color);
        }
    }
}
