﻿using System.Text.Json.Serialization;

namespace CmlLib.Core.Bedrock.Auth.Models
{
    public class BedrockTokenExtraData
    {
        [JsonPropertyName("XUID")]
        public string? XboxUserId { get; set; }

        [JsonPropertyName("identity")]
        public string? Identity { get; set; }

        [JsonPropertyName("displayName")]
        public string? DisplayName { get; set; }

        [JsonPropertyName("titleId")]
        public string? TitleId { get; set; }
    }

    public class BedrockTokenPayload
    {
        [JsonPropertyName("extraData")]
        public BedrockTokenExtraData? ExtraData { get; set; }

        [JsonPropertyName("nbf")]
        public long NotBefore { get; set; }

        [JsonPropertyName("randomNonce")]
        public long RandomNonce { get; set; }

        [JsonPropertyName("iss")]
        public string? Issuer { get; set; }

        [JsonPropertyName("exp")]
        public long Expire { get; set; }

        [JsonPropertyName("iat")]
        public long IssuedAt { get; set; }

        [JsonPropertyName("identityPublicKey")]
        public string? IdentityPublicKey { get; set; }
    }
}
