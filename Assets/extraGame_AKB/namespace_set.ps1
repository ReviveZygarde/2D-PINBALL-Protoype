# Define the namespace
$namespace = "extraGame_AKB"

# Find all C# files in the specified directory and its subdirectories
$files = Get-ChildItem -Path "." -Filter "*.cs" -Recurse

# Loop through each file
foreach ($file in $files) {
    # Read the content of the file
    $content = Get-Content $file.FullName -Raw
    
    # Check if the namespace declaration is missing
    if (-not $content.Contains("namespace $namespace")) {
        # Add the namespace declaration at the beginning of the file
        $newContent = "namespace $namespace`r`n{`r`n" + $content + "`r`n}`r`n"

        # Write the updated content back to the file
        Set-Content -Path $file.FullName -Value $newContent
    }
}
