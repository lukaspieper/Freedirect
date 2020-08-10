using Nuke.Common;

partial class Build
{
    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Parameter("DotCover coverage filter (default: '+:module=*;class=*;function=*;-:module=xunit.assert;')")]
    readonly string DotCoverFilter = "+:module=*;class=*;function=*;-:module=xunit.assert;";

    [Parameter("Minimal value for CodeMetrics' MaintainabilityIndex. If a member is rated lower, the process fails")]
    readonly int MaintainabilityIndexMinimum = 60;

    // TODO: Check if the number of warnings from the previous GitHub Actions run can be retrieved.
    [Parameter("Maximal number of Roslyn analyzers warnings. If the number is higher, the process fails")]
    readonly int RoslynAnalyzersWarningThreshold;
}