﻿using CmlLib.Core.Auth.Microsoft.OAuth;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XboxAuthNet.OAuth;

namespace CmlLib.Core.Auth.Microsoft.MsalClient
{
    public abstract class MsalOAuthApiBase : IMicrosoftOAuthApi
    {
        protected IPublicClientApplication MsalApplication { get; }

        public MsalOAuthApiBase(IPublicClientApplication app)
        {
            this.MsalApplication = app;
            this.Scopes = MsalMinecraftLoginHelper.DefaultScopes;
        }

        protected IEnumerable<string> Scopes { get; }

        public virtual async Task<IEnumerable<IAccount>> GetAccounts()
        {
            return await MsalApplication.GetAccountsAsync();
        }

        public async Task<MicrosoftOAuthResponse> GetOrRefreshTokens(MicrosoftOAuthResponse refreshToken)
        {
            var accounts = await GetAccounts();
            var result = await MsalApplication.AcquireTokenSilent(Scopes, accounts.FirstOrDefault())
                .ExecuteAsync();
            return MsalMinecraftLoginHelper.ToMicrosoftOAuthResponse(result);
        }

        public abstract Task<MicrosoftOAuthResponse> RequestNewTokens();

        public async Task InvalidateTokens()
        {
            await MsalMinecraftLoginHelper.RemoveAccounts(MsalApplication);
        }
    }
}
