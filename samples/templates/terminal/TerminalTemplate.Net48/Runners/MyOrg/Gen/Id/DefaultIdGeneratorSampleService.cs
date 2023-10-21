using System;

namespace TerminalTemplate.Net48.Runners.MyOrg.Gen.Id
{
    /// <summary>
    /// The default <see cref="IIdGeneratorSampleService"/>.
    /// </summary>
    public class DefaultIdGeneratorSampleService : IIdGeneratorSampleService
    {
        /// <inheritdoc/>
        public string GenerateLuid()
        {
            return Guid.NewGuid().ToString();
        }

        public string GenerateSuid()
        {
            return $"id{++counter}";
        }

        public static int counter;
    }
}
