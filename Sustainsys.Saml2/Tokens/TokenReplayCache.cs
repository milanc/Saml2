

using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System;

namespace Sustainsys.Saml2.Tokens
{
	class TokenReplayCache : ITokenReplayCache
	{

        readonly MemoryCache cache = new MemoryCache(new MemoryCacheOptions());


        // Dummy object to store in cache.
        private static readonly object cacheObject = new object();

		public bool TryAdd(string securityToken, DateTime expiresOn)
		{

            cache.Set(securityToken, cacheObject, new DateTimeOffset(expiresOn));

            return true;
        }

        public bool TryFind(string securityToken)
		{
            return cache.Get(securityToken) != null;
		}
	}
}
