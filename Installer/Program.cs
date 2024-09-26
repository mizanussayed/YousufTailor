using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

var certificateUrl = "https://salesforceapptest.banglalink.net/TOSAPI/software/TOS_BL_New.pfx";
var appinstallerUrl = "https://salesforceapptest.banglalink.net/TOSAPI/software/TOS_New.appinstaller";
var password = "BL@2024@2034";

var tempPath = Path.GetTempPath();
var certificatePath = Path.Combine(tempPath, "TOS_BL_New.pfx");
var appinstallerPath = Path.Combine(tempPath, "TOS_New.appinstaller");

try
{
    // Download and save the certificate
    Console.WriteLine("Downloading certificate...");
    await DownloadFileAsync(certificateUrl, certificatePath);
    Console.WriteLine($"Certificate downloaded to {certificatePath}");

    // Install the certificate
    Console.WriteLine("Installing certificate...");
    InstallCertificate(certificatePath, password);
    Console.WriteLine("Certificate installed successfully");

    // Download and save the .appinstaller file
    Console.WriteLine("Downloading appinstaller...");
    await DownloadFileAsync(appinstallerUrl, appinstallerPath);
    Console.WriteLine($"Appinstaller downloaded to {appinstallerPath}");

    // Run the .appinstaller file
    Console.WriteLine("Running appinstaller...");
    Process.Start("explorer.exe", appinstallerPath);
    Console.WriteLine("Appinstaller process started");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    Console.ReadLine();
}

static async Task DownloadFileAsync(string url, string destinationPath)
{
    using var client = new HttpClient();
    using HttpResponseMessage response = await client.GetAsync(url);
    using Stream stream = await response.Content.ReadAsStreamAsync();
    using var fs = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None);
    await stream.CopyToAsync(fs);
}

static void InstallCertificate(string certificatePath, string password)
{
    var certificate = new X509Certificate2(certificatePath, password);
    using var store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
    store.Open(OpenFlags.ReadWrite);
    store.Add(certificate);
    store.Close();
}

