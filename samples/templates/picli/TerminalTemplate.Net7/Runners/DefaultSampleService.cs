using System;

namespace TerminalTemplate.Net7.Runners
{
    /// <summary>
    /// The default <see cref="ISampleService"/>.
    /// </summary>
    public class DefaultSampleService : ISampleService
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
