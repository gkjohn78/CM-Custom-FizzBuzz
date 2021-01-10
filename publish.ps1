param($out_path)

If(!(test-path $out_path))
{
	New-Item -ItemType Directory -Force -Path $out_path
}

Get-ChildItem -Path $out_path -Include *.* -File -Recurse | foreach {$_.Delete()}

$ScriptDir = Split-Path $script:MyInvocation.MyCommand.Path

dotnet publish --configuration "Release" --output $out_path $ScriptDir\FizzBuzz.sln

