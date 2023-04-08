# Invalid Opcode Remover

The Invalid Opcode Remover is a tool that automatically removes invalid opcodes from .NET assemblies. Invalid opcodes are instructions that the .NET runtime cannot execute and that are typically inserted by obfuscation tools to confuse decompilers or to make it harder to analyze the code. Removing these opcodes can help make the code more readable and easier to work with.

The Invalid Opcode Remover works by analyzing the IL code of the assembly and removing any instructions that have an invalid opcode. It supports both 32-bit and 64-bit assemblies and can handle multiple input files at once. The tool is written in C# using the dnlib library, which provides a convenient API for reading and modifying .NET assemblies.

# Preview

[![name](https://i.imgur.com/w0icNxD.png)](https://i.imgur.com/w0icNxD.png)

# Usage

```OpcodeRemover.exe Assembly.dll```


# Dependencies

The Invalid Opcode Remover depends on the following libraries:

- dnlib (https://github.com/0xd4d/dnlib)

These libraries are included as NuGet packages and will be automatically downloaded and installed by Visual Studio or the .NET CLI when you build the project.

# License

The Invalid Opcode Remover is licensed under the MIT License. See the LICENSE file for more details.
