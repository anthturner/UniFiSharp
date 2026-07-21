[CmdletBinding()]
param(
    [string] $ConfigFile,
    [string] $Site,
    [switch] $LegacyApi,
    [switch] $ReversibleWrites
)

$passwordPointer = [IntPtr]::Zero

if ($ConfigFile) {
    $resolvedConfigFile = Resolve-Path -LiteralPath $ConfigFile -ErrorAction Stop
    $settings = Get-Content -LiteralPath $resolvedConfigFile -Raw | ConvertFrom-Json
    $deviceAddress = [string] $settings.url
    $username = [string] $settings.username
    $password = [string] $settings.password

    if (-not $PSBoundParameters.ContainsKey('Site') -and $settings.site) {
        $Site = [string] $settings.site
    }
    if (-not $PSBoundParameters.ContainsKey('LegacyApi') -and $null -ne $settings.modernApi) {
        $LegacyApi = -not [bool] $settings.modernApi
    }
    if (-not $PSBoundParameters.ContainsKey('ReversibleWrites') -and $null -ne $settings.reversibleWrites) {
        $ReversibleWrites = [bool] $settings.reversibleWrites
    }

    foreach ($requiredSetting in 'url', 'username', 'password') {
        if ([string]::IsNullOrWhiteSpace([string] $settings.$requiredSetting)) {
            throw "The required '$requiredSetting' setting is missing from '$resolvedConfigFile'."
        }
    }
}
else {
    $deviceAddress = Read-Host "UniFi controller IP address or URL"
    $username = Read-Host "Username"
    $securePassword = Read-Host "Password" -AsSecureString
    $passwordPointer = [Runtime.InteropServices.Marshal]::SecureStringToBSTR($securePassword)
    $password = [Runtime.InteropServices.Marshal]::PtrToStringBSTR($passwordPointer)
}

if ([string]::IsNullOrWhiteSpace($Site)) { $Site = 'default' }
if ($deviceAddress -notmatch '^https?://') { $deviceAddress = "https://$deviceAddress" }
try {
    $env:UNIFI_DEVICE_URL = $deviceAddress.TrimEnd('/') + '/'
    $env:UNIFI_DEVICE_USERNAME = $username
    $env:UNIFI_DEVICE_PASSWORD = $password
    $env:UNIFI_DEVICE_SITE = $Site
    $env:UNIFI_DEVICE_MODERN_API = if ($LegacyApi) { 'false' } else { 'true' }
    $env:UNIFI_DEVICE_REVERSIBLE_WRITES = if ($ReversibleWrites) { 'true' } else { 'false' }
    dotnet test "$PSScriptRoot\UniFiSharp.DeviceTests\UniFiSharp.DeviceTests.csproj" --nologo --logger "console;verbosity=normal"
    exit $LASTEXITCODE
} finally {
    if ($passwordPointer -ne [IntPtr]::Zero) {
        [Runtime.InteropServices.Marshal]::ZeroFreeBSTR($passwordPointer)
    }
    $password = $null
    Remove-Item Env:UNIFI_DEVICE_URL, Env:UNIFI_DEVICE_USERNAME, Env:UNIFI_DEVICE_PASSWORD, Env:UNIFI_DEVICE_SITE, Env:UNIFI_DEVICE_MODERN_API, Env:UNIFI_DEVICE_REVERSIBLE_WRITES -ErrorAction SilentlyContinue
}
