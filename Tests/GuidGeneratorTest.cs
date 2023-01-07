using System;
using Xunit.Abstractions;

namespace Tests
{

    //using IclassFixture passing the context (in this case GuiGenerator), it will have always the same context instead of instaciante a new class every time
    public class GuidGeneratorTestOne :IClassFixture<GuidGenerator>
	{
		private readonly GuidGenerator _guiGenerator;
		private readonly ITestOutputHelper _output;

        public GuidGeneratorTestOne(ITestOutputHelper outputHelper, GuidGenerator guiGenerator)
        {
            this._output = outputHelper;
            _guiGenerator = guiGenerator;
        }


        [Fact]
        public void GuidTestOne()
        {
            var guid = _guiGenerator.RamdomGuid;
            _output.WriteLine($"the guid was: {guid}");
        }

        [Fact]
        public void GuidTestOneTwo()
        {
            var guid = _guiGenerator.RamdomGuid;
            _output.WriteLine($"the guid was: {guid}");
        }

    }



    //here i'm using this context collection so I can use the same context between multiple test class 
    [CollectionDefinition("generation")]
    public class GuidGeneratorDefinition : ICollectionFixture<GuidGenerator>
    {

    }

    //here I just need to define the context name definition
    [Collection("generation")]
    public class GuidGeneratorTestTwo
    {
        private readonly GuidGenerator _guiGenerator;
        private readonly ITestOutputHelper _output;

        public GuidGeneratorTestTwo(ITestOutputHelper outputHelper, GuidGenerator guiGenerator)
        {
            this._output = outputHelper;
            _guiGenerator = guiGenerator;
        }


        [Fact]
        public void GuidTestOne()
        {  
            var guid = _guiGenerator.RamdomGuid;
            _output.WriteLine($"the guid was: {guid}");
        }

        [Fact]
        public void GuidTestOneTwo()
        {
            var guid = _guiGenerator.RamdomGuid;
            _output.WriteLine($"the guid was: {guid}");
        }
    }
    //here I just need to define the context name definition, in this case it will have the same context as GuidGeneratorTestTwo
    [Collection("generation")]
    public class GuidGeneratorTestThree{
        private readonly GuidGenerator _guiGenerator;
        private readonly ITestOutputHelper _output;

        public GuidGeneratorTestThree(ITestOutputHelper outputHelper, GuidGenerator guiGenerator)
        {
            this._output = outputHelper;
            _guiGenerator = guiGenerator;
        }


        [Fact]
        public void GuidTestOne()
        {
            var guid = _guiGenerator.RamdomGuid;
            _output.WriteLine($"the guid was: {guid}");
        }

        [Fact]
        public void GuidTestOneTwo()
        {
            var guid = _guiGenerator.RamdomGuid;
            _output.WriteLine($"the guid was: {guid}");
        }
    }



    public class GuidGenerator
	{
		public Guid RamdomGuid { get; } = Guid.NewGuid();
	}
}

