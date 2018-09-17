param($installPath, $toolsPath, $package, $project)

# set dll to copy to build dir
$wkdll = $project.ProjectItems.Item("wkhtmltox0.dll")

$copyToOutput = $wkdll.Properties.Item("CopyToOutputDirectory")
$copyToOutput.Value = 1

# and each of the dependencies
$dep1 = $project.ProjectItems.Item("libeay32.dll")
$dep2 = $project.ProjectItems.Item("libgcc_s_dw2-1.dll")
$dep3 = $project.ProjectItems.Item("mingwm10.dll")
$dep4 = $project.ProjectItems.Item("ssleay32.dll")

$copyToOutput1 = $dep1.Properties.Item("CopyToOutputDirectory")
$copyToOutput1.Value = 1
$copyToOutput2 = $dep2.Properties.Item("CopyToOutputDirectory")
$copyToOutput2.Value = 1
$copyToOutput3 = $dep3.Properties.Item("CopyToOutputDirectory")
$copyToOutput3.Value = 1
$copyToOutput4 = $dep4.Properties.Item("CopyToOutputDirectory")
$copyToOutput4.Value = 1