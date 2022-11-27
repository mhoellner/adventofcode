using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace SourceGenerators
{
    [Generator]
    public class MonadAluSourceGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            // no need
        }

        public void Execute(GeneratorExecutionContext context)
        {
            var file = context.AdditionalFiles.Single();
            var lines = file.GetText(context.CancellationToken)!.Lines;
            const string bodyIndent = "            ";
            var body = new StringBuilder();
            body.Append($"// using input from {file.Path}\r\n");
            foreach (var line in lines)
            {
                var inputs = line.ToString().Split(' ');
                body.Append($"{bodyIndent}// {line}\r\n");
                switch (inputs[0])
                {
                    case "inp":
                    {
                        body.Append($"{bodyIndent}{inputs[1]} = long.Parse(modelNumber[index].ToString());\r\n");
                        body.Append($"{bodyIndent}index++;\r\n");
                        break;
                    }
                    case "add":
                    {
                        body.Append($"{bodyIndent}{inputs[1]} += {inputs[2]};\r\n");
                        break;
                    }
                    case "mul":
                    {
                        body.Append($"{bodyIndent}{inputs[1]} *= {inputs[2]};\r\n");
                        break;
                    }
                    case "div":
                    {
                        body.Append($"{bodyIndent}{inputs[1]} /= {inputs[2]};\r\n");
                        break;
                    }
                    case "mod":
                    {
                        body.Append($"{bodyIndent}{inputs[1]} %= {inputs[2]};\r\n");
                        break;
                    }
                    case "eql":
                    {
                        body.Append($"{bodyIndent}{inputs[1]} = {inputs[1]} == {inputs[2]} ? 1 : 0;\r\n");
                        break;
                    }
                }
            }
            var source = $@"// <auto-generated/>

namespace AdventOfCode._2021._24
{{
    public static partial class MonadArithmeticLogicUnit
    {{
        public static bool ValidModelNumber(string modelNumber)
        {{
            if (modelNumber.Contains(""0"")) return false;

            long w = 0, x = 0, y = 0, z = 0;
            int index = 0;

            {body}
            return z == 0;
        }}
    }}
}}";
            var sourceText = SourceText.From(source, Encoding.UTF8);
            context.AddSource("MonadArithmeticLogicUnit.g.cs", sourceText);
        }
    }
}