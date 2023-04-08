using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Collections.Generic;
using System;
using System.Drawing;

namespace OpcodeRemover.Helper
{
    internal class Fixer
    {
        public static void Deobfuscate(ModuleDef module)
        {
            foreach (TypeDef typeDef in module.GetTypes())
            {
                foreach (MethodDef methodDef in typeDef.Methods)
                {
                    if (methodDef.HasBody && methodDef.Body.HasInstructions)
                    {
                        Instruction firstInstruction = methodDef.Body.Instructions[0];

                        //Program.Prefix("!", methodDef.FullName + " -> " + firstInstruction + "\n", Color.Aqua);

                        if (firstInstruction.ToString().Contains("box System.Math"))
                        {
                            methodDef.Body.Instructions.RemoveAt(0);
                            Program.Prefix("~", $"{methodDef.Name} -> Removed Invalid Opcode\n", Color.Green);
                        }

                    }
                }
            }


        }
    }
}
