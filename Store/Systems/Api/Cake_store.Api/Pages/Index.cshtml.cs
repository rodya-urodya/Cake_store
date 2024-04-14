﻿using Cake_store.Common;
using Cake_store.Services.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Cake_store.Api.Settings;
using System.Reflection;

namespace Cake_store.Api.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public bool OpenApiEnabled => settings.Enabled;

        [BindProperty]
        public string Version => Assembly.GetExecutingAssembly().GetAssemblyVersion();

        [BindProperty]
        public string IdentityServerUrl => identitySettings.Url;

        [BindProperty]
        public string HelloMessage => apiSettings.HelloMessage;


        private readonly SwaggerSettings settings;
        private readonly ApiSpecialSettings apiSettings;
        private readonly IdentitySettings identitySettings;

        public IndexModel(SwaggerSettings settings, ApiSpecialSettings apiSettings, IdentitySettings identitySettings)
        {
            this.settings = settings;
            this.apiSettings = apiSettings;
            this.identitySettings = identitySettings;
        }

        public void OnGet()
        {

        }
    }
}