namespace TerminalTemplate.Net48.Runners.MyOrg.Gen.Id
{
    /// <summary>
    /// The sample id generator service to demonstrate the custom DI injection for CLI terminal.
    /// </summary>
    public interface IIdGeneratorSampleService
    {
        /// <summary>
        /// Generates a long GUID.
        /// </summary>
        public string GenerateLuid();

        /// <summary>
        /// Generates a short GUID.
        /// </summary>
        /// <returns></returns>
        public string GenerateSuid();
    }
}
