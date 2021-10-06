using System;

using BenchmarkDotNet.Attributes;


namespace DotNetBenchmarks
{
    public enum NameEnums
    {
        Brown,
        Fox,
        Jump,
        Over,
        Dog
    }


    public sealed class NamedConstantValue<TValue>
    {
        public string Name { get; }
        public TValue Value { get; }


        public NamedConstantValue(string name, TValue value)
        {
            this.Name = name;
            this.Value = value;
        }
    }


    public static class NamedConstant
    {
        public static readonly NamedConstantValue<int> Brown = new("Brown", 0);
        public static readonly NamedConstantValue<int> Fox = new("Fox", 1);
        public static readonly NamedConstantValue<int> Jump = new("Jump", 2);
        public static readonly NamedConstantValue<int> Over = new("Over", 3);
        public static readonly NamedConstantValue<int> Dog = new("Dog", 4);
    }


    [MemoryDiagnoser]
    public class EnumNameConversionBenchmark
    {
        private NameEnums name = NameEnums.Brown;
        private NamedConstantValue<int> namedConstant = NamedConstant.Brown;
        
        [Benchmark]
        public string toString()
        {
            return name.ToString();
        }


        [Benchmark]
        public string enumGetName()
        {
            return Enum.GetName(typeof(NameEnums), name);
        }


        [Benchmark]
        public string nameOfWithSwitches()
        {
            return name switch
            {
                NameEnums.Brown => nameof(NameEnums.Brown),
                NameEnums.Fox => nameof(NameEnums.Fox),
                NameEnums.Jump => nameof(NameEnums.Jump),
                NameEnums.Over => nameof(NameEnums.Over),
                NameEnums.Dog => nameof(NameEnums.Dog),
                _ => throw new ArgumentOutOfRangeException(nameof(name), name, null)
            };
        }
        
        
        [Benchmark(Description = "class instance with name value")]
        public string namedConstantName()
        {
            return namedConstant.Name;
        }
    }
}
