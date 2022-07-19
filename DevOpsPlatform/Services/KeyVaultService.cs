using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace DevOpsPlatform.Services
{
    public static class KeyVaultService
    {
        public static string GetSecret(string secretName, string vaultName)
        {
            SecretClientOptions options = new SecretClientOptions()
            {
                Retry =
                {
                    Delay= TimeSpan.FromSeconds(2),
                    MaxDelay = TimeSpan.FromSeconds(16),
                    MaxRetries = 5,
                    Mode = RetryMode.Exponential
                }
            };

            var client = new SecretClient(new Uri($"https://{vaultName}.vault.azure.net/"), new DefaultAzureCredential(), options);

            KeyVaultSecret secret = client.GetSecret(secretName);

            return secret.Value;
        }
    }
}
