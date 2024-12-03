using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace MyFirstAzureWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string SecretValue { get; private set; }

        public async Task OnGetAsync()
        {
            var client = new SecretClient(new Uri("https://Said-vault.vault.azure.net/"), new DefaultAzureCredential());
            KeyVaultSecret secret = await client.GetSecretAsync("etickets-admin");
            SecretValue = secret.Value; // Store the secret value in a public property
        }
    }
}
