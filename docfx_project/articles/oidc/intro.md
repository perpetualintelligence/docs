![pi-banner](https://en.gravatar.com/userimage/152742631/4ab9cb340649391354d65b592b744114.png)

# protocols:oidc
[![status: preview](https://img.shields.io/badge/status-preview-yellow)]()
[![src: private](https://img.shields.io/badge/src-private-red)]()
[![usage: free](https://img.shields.io/badge/usage-free-green)]()
[![License: Apache](https://img.shields.io/badge/License-Apache-yellow.svg)](https://opensource.org/licenses/MIT)

[![Issues](https://img.shields.io/github/issues/perpetualintelligence/protocols)](https://github.com/perpetualintelligence/protocols/issues)
![Deployment](https://vsrm.dev.azure.com/perpetualintelligence/_apis/public/Release/badge/4c5f1531-e837-40e9-9e5e-47abaa3fab37/2/2)
[![Nuget](https://img.shields.io/nuget/vpre/PerpetualIntelligence.Protocols)](https://www.nuget.org/packages/PerpetualIntelligence.Protocols)

The OAuth 2.0 and OpenID Connect 1.0 well-known configuration. For more information see [OAuth 2.0 Authorization Framework](https://datatracker.ietf.org/doc/html/rfc6749) and [OpenID Connect](https://openid.net/connect/) standards.
 
> **Note:** The OAuth 2.1 protocol spec is in progress. Its new features will be supported once the spec is finalized. See [OAuth 2.1 Authorization Protocol](https://datatracker.ietf.org/doc/html/draft-ietf-oauth-v2-1-02) for more details.

The Perpetual Intelligence `oidc` protocol implementation supports following well-known configurations. This document also defines additional configurations to enable enhanced authentication and authorization capabilities.

* The ***Field*** identifies the code element that defines a configuration
* The ***Value*** is the configuration value itself
* The [![standard](https://img.shields.io/badge/-std-blue)]() identifies a configuration, value, parameter, protocol or name as defined by the OAuth or OpenID Connect specification
* The [![infra](https://img.shields.io/badge/-infra-red)]() identifies a configuration, value, parameter, protocol or name as defined by the Perpetual Intelligence infrastructure.

### Access Token Types 
`PerpetualIntelligence.Protocols.Oidc.AccessTokenTypes`
| Field | Value | Description 
|-|-|-|
| Jwt | `urn:pi:protocols:oidc:at:jwt` | Self-contained Json Web Token. See [JSON Web Token (JWT)](https://datatracker.ietf.org/doc/html/rfc7519) for more information. |
| Opaque | `urn:pi:protocols:oidc:at:opaque` | Opaque token do not embed any identifiable information.

### Acr Values 
`PerpetualIntelligence.Protocols.Oidc.AcrValues`
| Field | Value | Description 
|-|-|-|
| AllowedChargeables | `urn:pi:protocols:oidc:acr:achrgs` | The allowed chargeables. |
| SubscribedChargeables | `uurn:pi:protocols:oidc:acr:schrgs` | The subscribed chargeables. |
| IdentityProvider | `urn:pi:protocols:oidc:acr:idp` | The IDP or an Identity Provider.
| Tenant | `urn:pi:protocols:oidc:acr:tenant` | The tenant for multi-tenancy.

### Application Types [![standard](https://img.shields.io/badge/-std-blue)]()
`PerpetualIntelligence.Protocols.Oidc.ApplicationTypes`
| Field | Value | Description 
|-|-|-|
| Native | `native` | The Native application such as a JAVAScript or a Blazor WebAssembly. |
| Mobile | `mobile` | The Mobile application. |
| Web | `web` | The Web application. |

### Custom Claim Value Types
`PerpetualIntelligence.Protocols.Oidc.ClaimValueTypes`
| Field | Value | Description 
|-|-|-|
| Json | `urn:pi:protocols:oidc:claimvalue:json` | A URI that represents Json data type. |

### Client Assertion Types
`PerpetualIntelligence.Protocols.Oidc.ClientAssertionTypes`
| Field | Value | Description 
|-|-|-|
| JwtBearer | `urn:ietf:params:oauth:client-assertion-type:jwt-bearer` | JSON Web Token (JWT) Profile for OAuth 2.0 Client Authentication and Authorization Grants. |
| SamlBearer | `urn:ietf:params:oauth:client-assertion-type:saml2-bearer` | Security Assertion Markup Language (SAML) 2.0 Profile for OAuth 2.0 Client Authentication and Authorization Grants. |

### Code Challenge Methods
`PerpetualIntelligence.Protocols.Oidc.CodeChallengeMethods`
| Field | Value | Description 
|-|-|-|
| Plain | `plain` | [![ToDo](https://img.shields.io/badge/-ToDo-red)]() |
| Sha256 | `S256` | [![ToDo](https://img.shields.io/badge/-ToDo-red)]() |

### Constants 
`PerpetualIntelligence.Protocols.Oidc.Constants`
| Field | Value | Description 
|-|-|-|
| AuthenticationType | `urn:pi:protocols:imlx:identity:auth` | The authentication type used to create the 'System.Security.Claims.ClaimsPrincipal'.[![ToDo](https://img.shields.io/badge/-ToDo-red)]()  |
| AuthenticationHeaderBearer | `Bearer` | The bearer token in authorization header. |
| BearerTokenType | `Bearer` | The bearer token type. |
| CorsPolicyName | `urn:pi:protocols:imlx:identity:cors` | The default CORS policy name. |
| LogoutToken | `logout_token` | The back channel logout token. |
| OpenIDConnect | `oidc` | The OpenID Connect authentication protocol. |

###  Discovery
`PerpetualIntelligence.Protocols.Oidc.Discovery`
| Field | Value | Description 
|-|-|-|
| AcrValuesSupported | `acr_values_supported` |  |
| AuthorizationEndpoint | `authorization_endpoint` |  |
| AuthorizationResponseIssParameterSupported | `authorization_response_iss_parameter_supported` |  |
| BackChannelLogoutSessionSupported | `backchannel_logout_session_supported` |  |
| BackChannelLogoutSupported | `backchannel_logout_supported` |  |
| CheckSessionIframe | `check_session_iframe` |  |
| ClaimsLocalesSupported | `claims_locales_supported` |  |
| ClaimsParameterSupported | `claims_parameter_supported` |  |
| ClaimsSupported | `claims_supported` |  |
| ClaimTypesSupported | `claim_types_supported` |  |
| CodeChallengeMethodsSupported | `code_challenge_methods_supported` |  |
| DeviceAuthorizationEndpoint | `device_authorization_endpoint` |  |
| DiscoveryEndpoint | `.well-known/openid-configuration` |  |
| DisplayValuesSupported | `display_values_supported` |  |
| EndSessionEndpoint | `end_session_endpoint` |  |
| FrontChannelLogoutSessionSupported | `frontchannel_logout_session_supported` |  |
| FrontChannelLogoutSupported | `frontchannel_logout_supported` |  |
| GrantTypesSupported | `grant_types_supported` |  |
| IdTokenEncryptionAlgorithmsSupported | `id_token_encryption_alg_values_supported` |  |
| IdTokenEncryptionEncValuesSupported | `id_token_encryption_enc_values_supported` |  |
| IdTokenSigningAlgorithmsSupported | `id_token_signing_alg_values_supported` |  |
| IntrospectionEndpoint | `introspection_endpoint` |  |
| Issuer | `issuer` |  |
| JwksUri | `jwks_uri` |  |
| MtlsEndpointAliases | `mtls_endpoint_aliases` |  |
| OpPolicyUri | `op_policy_uri` |  |
| OpTosUri | `op_tos_uri` |  |
| RegistrationEndpoint | `registration_endpoint` |  |
| RequestObjectEncryptionAlgorithmsSupported | `request_object_encryption_alg_values_supported` |  |
| RequestObjectEncryptionEncValuesSupported | `request_object_encryption_enc_values_supported` |  |
| RequestObjectSigningAlgorithmsSupported | `request_object_signing_alg_values_supported` |  |
| RequestParameterSupported | `request_parameter_supported` |  |
| RequestUriParameterSupported | `request_uri_parameter_supported` |  |
| RequireRequestUriRegistration | `require_request_uri_registration` |  |
| ResponseModesSupported | `response_modes_supported` |  |
| ResponseTypesSupported | `response_types_supported` |  |
| RevocationEndpoint | `revocation_endpoint` |  |
| ScopesSupported | `scopes_supported` |  |
| ServiceDocumentation | `service_documentation` |  |
| SubjectTypesSupported | `subject_types_supported` |  |
| TlsClientCertificateBoundAccessTokens | `tls_client_certificate_bound_access_tokens` |  |
| TokenEndpoint | `token_endpoint` |  |
| TokenEndpointAuthenticationMethodsSupported | `token_endpoint_auth_methods_supported` |  |
| TokenEndpointAuthSigningAlgorithmsSupported | `token_endpoint_auth_signing_alg_values_supported` |  |
| UILocalesSupported | `ui_locales_supported` |  |
| UserInfoEncryptionAlgorithmsSupported | `userinfo_encryption_alg_values_supported` |  |
| UserInfoEncryptionEncValuesSupported | `userinfo_encryption_enc_values_supported` |  |
| UserInfoEndpoint | `userinfo_endpoint` |  |
| UserInfoSigningAlgorithmsSupported | `userinfo_signing_alg_values_supported` |  |

### Display Modes 
`PerpetualIntelligence.Protocols.Oidc.DisplayModes`
| Field | Value | Description 
|-|-|-|
| Page | `page` | The Authorization Server SHOULD display the authentication and consent UI consistent with a full User Agent page view. If the display parameter is not specified, this is the default display mode. |
| Popup | `popup` | The Authorization Server SHOULD display the authentication and consent UI consistent with a popup User Agent window. The popup User Agent window should be of an appropriate size for a login-focused dialog and should not obscure the entire window that it is popping up over. |
| Touch | `touch` | The Authorization Server SHOULD display the authentication and consent UI consistent with a device that leverages a touch interface. |
| Wap | `wap` | The Authorization Server SHOULD display the authentication and consent UI consistent with a "feature phone" type display. |

### Errors 
`PerpetualIntelligence.Protocols.Oidc.Errors`
| Field | Value | Description 
|-|-|-|
| AccessDenied | `access_denied` |  |
| AccountSelectionRequired | `account_selection_required` |  |
| AuthorizationPending | `authorization_pending` |  |
| ConsentRequired | `consent_required` |  |
| ExpiredToken | `expired_token` |  |
| InsufficientScope | `insufficient_scope` |  |
| InteractionRequired | `interaction_required` |  |
| InvalidClient | `invalid_client` |  |
| InvalidEndpoint | `invalid_endpoint` |  |
| InvalidGrant | `invalid_grant` |  |
| InvalidRequest | `invalid_request` |  |
| InvalidRequestObject | `invalid_request_object` |  |
| InvalidRequestUri | `invalid_request_uri` |  |
| InvalidScope | `invalid_scope` |  |
| InvalidTarget | `invalid_target` |  |
| InvalidToken | `invalid_token` |  |
| LoginRequired | `login_required` |  |
| RegistrationNotSupported | `registration_not_supported` |  |
| RequestNotSupported | `request_not_supported` |  |
| RequestUriNotSupported | `request_uri_not_supported` |  |
| ServerError | `server_error` |  |
| SlowDown | `slow_down` |  |
| TemporarilyUnavailable | `temporarily_unavailable` |  |
| UnexpectedError | `unexpected_error` |  |
| UnauthorizedClient | `unauthorized_client` |  |
| UnauthorizedOrigin | `unauthorized_origin` |  |
| UnauthorizedSubject | `unauthorized_subject` |  |
| UnsupportedGrantType | `unsupported_grant_type` |  |
| UnsupportedResponseType | `unsupported_response_type` |  |
| MissingToken | `missing_token` |  |
| UnsupportedTokenType | `unsupported_token_type` |  |

### Events 
`PerpetualIntelligence.Protocols.Oidc.Events`
| Field | Value | Description 
|-|-|-|
| BackChannelLogout | `http://schemas.openid.net/event/backchannel-logout` |  |

### Grant Types 
`PerpetualIntelligence.Protocols.Oidc.GrantTypes`
| Field | Value | Description 
|-|-|-|
| AuthorizationCode | `authorization_code` | The authorization code grant. |
| ClientCredentials | `client_credentials` | The client credential grant. |
| DeviceCode | `urn:ietf:params:oauth:grant-type:device_code` | The device authorization grant. |
| Hybrid | `hybrid` | The hybrid grant. |
| Implicit | `implicit` | The implicit grant. |
| JwtBearer | `urn:ietf:params:oauth:grant-type:jwt-bearer` | The JSON Web Token (JWT) Profile Client authentication and authorization grant. |
| RefreshToken | `refresh_token` | The refresh token grant. |
| ResourceOwnerPassword | `password` | The resource owner password grant. |
| Saml2Bearer | `urn:ietf:params:oauth:grant-type:saml2-bearer` | The SAML 2.0 profile for OAuth 2.0 client authenticaiton and authorization grant. |
| TokenExchange | `urn:ietf:params:oauth:grant-type:token-exchange` | The OAuth 2.0 token exchange grant. |

### Jwt Claim Types  
`PerpetualIntelligence.Protocols.Oidc.JwtClaimTypes`
| Field | Value | Description 
|-|-|-|
| AccessTokenHash | `at_hash` | Access Token hash value. Its value is the base64url encoding of the left-most half of the hash of the octets of the ASCII representation of the access_token value, where the hash algorithm used is the hash algorithm used in the alg Header Parameter of the ID Token's JOSE Header. For instance, if the alg is RS256, hash the access_token value with SHA-256, then take the left-most 128 bits and base64url encode them. The at_hash value is a case sensitive string. |
| Actor | `act` | The "act" (actor) claim provides a means within a JWT to express that delegation has occurred and identify the acting party to whom authority has been delegated.The "act" claim value is a JSON object and members in the JSON object are claims that identify the actor. The claims that make up the "act" claim identify and possibly provide additional information about the actor. |
| Address | `address` | End-User's preferred postal address. The value of the address member is a JSON structure containing some or all of the members defined in http://openid.net/specs/openid-connect-basic-1_0-32.html#AddressClaim . [![ToDo](https://img.shields.io/badge/-ToDo-red)]() |
| Application | `urn:pi:protocols:oidc:jwtclaimtypes:application` | [![ToDo](https://img.shields.io/badge/-ToDo-red)]() |
| Audience | `aud` | Audience(s) that this ID Token is intended for. It MUST contain the OAuth 2.0 client_id of the Relying Party as an audience value. It MAY also contain identifiers for other audiences. In the general case, the aud value is an array of case sensitive strings. In the common special case when there is one audience, the aud value MAY be a single case sensitive string. |
| AuthenticationContextClassReference | `acr` | Authentication Context Class Reference. String specifying an Authentication Context Class Reference value that identifies the Authentication Context Class that the authentication performed satisfied. The value "0" indicates the End-User authentication did not meet the requirements of ISO/IEC 29115 level 1. Authentication using a long-lived browser cookie, for instance, is one example where the use of "level 0" is appropriate. Authentications with level 0 SHOULD NOT be used to authorize access to any resource of any monetary value. (This corresponds to the OpenID 2.0 PAPE nist_auth_level 0.) An absolute URI or an RFC 6711 registered name SHOULD be used as the acr value; registered names MUST NOT be used with a different meaning than that which is registered. Parties using this claim will need to agree upon the meanings of the values used, which may be context-specific. The acr value is a case sensitive string. |
| AuthenticationMethod | `amr` | Authentication Methods References. JSON array of strings that are identifiers for authentication methods used in the authentication. |
| AuthenticationTime | `auth_time` | Time when the End-User authentication occurred. Its value is a JSON number representing the number of seconds from 1970-01-01T0:0:0Z as measured in UTC until the date/time. When a max_age request is made or when auth_time is requested as an Essential Claim, then this Claim is REQUIRED; otherwise, its inclusion is OPTIONAL. |
| AuthorizationCodeHash | `c_hash` | Code hash value. Its value is the base64url encoding of the left-most half of the hash of the octets of the ASCII representation of the code value, where the hash algorithm used is the hash algorithm used in the alg Header Parameter of the ID Token's JOSE Header. For instance, if the alg is HS512, hash the code value with SHA-512, then take the left-most 256 bits and base64url encode them. The c_hash value is a case sensitive string. |
| AuthorizedParty | `azp` | The party to which the ID Token was issued. If present, it MUST contain the OAuth 2.0 Client ID of this party. This Claim is only needed when the ID Token has a single audience value and that audience is different than the authorized party. It MAY be included even when the authorized party is the same as the sole audience. The azp value is a case sensitive string containing a StringOrURI value. |
| BirthDate | `birthdate` | End-User's birthday, represented as an ISO 8601:2004 [ISO8601‑2004] YYYY-MM-DD format. The year MAY be 0000, indicating that it is omitted. To represent only the year, YYYY format is allowed. Note that depending on the underlying platform's date related function, providing just year can result in varying month and day, so the implementers need to take this factor into account to correctly process the dates. |
| ClientId | `client_id` | OAuth 2.0 Client Identifier valid at the Authorization Server. |
| Confirmation | `cnf` | The confirmation. |
| Email | `email` | End-User's preferred e-mail address. Its value MUST conform to the RFC 5322 [RFC5322] addr-spec syntax. The relying party MUST NOT rely upon this value being unique. |
| EmailVerified | `email_verified` | "true" if the End-User's e-mail address has been verified; otherwise "false". |
| Events | `events` | Defines a set of event statements that each may add additional claims to fully describe a single logical event that has occurred. |
| Expiration | `exp` | The exp (expiration time) claim identifies the expiration time on or after which the token MUST NOT be accepted for processing, specified as the number of seconds from 1970-01-01T0:0:0Z |
| FamilyName | `family_name` | Surname(s) or last name(s) of the End-User. Note that in some cultures, people can have multiple family names or no family name; all can be present, with the names being separated by space characters. |
| Gender | `gender` | End-User's gender. Values defined by this specification are "female" and "male". Other values MAY be used when neither of the defined values are applicable. |
| GivenName | `given_name` | Given name(s) or first name(s) of the End-User. Note that in some cultures, people can have multiple given names; all can be present, with the names being separated by space characters. |
| Id | `id` | An identifier. |
| IdentityProvider | `idp` | The identity provider |
| IssuedAt | `iat` | The iat (issued at) claim identifies the time at which the JWT was issued, , specified as the number of seconds from 1970-01-01T0:0:0Z |
| Issuer | `iss` | Issuer Identifier for the Issuer of the response. The iss value is a case sensitive URL using the https scheme that contains scheme, host, and optionally, port number and path components and no query or fragment components. |
| JwtId | `jti` | JWT ID. A unique identifier for the token, which can be used to prevent reuse of the token. These tokens MUST only be used once, unless conditions for reuse were negotiated between the parties; any such negotiation is beyond the scope of this specification. |
| Locale | `locale` | End-User's locale, represented as a BCP47 [RFC5646] language tag. This is typically an ISO 639-1 Alpha-2 [ISO639‑1] language code in lowercase and an ISO 3166-1 Alpha-2 [ISO3166‑1] country code in uppercase, separated by a dash. For example, en-US or fr-CA. As a compatibility note, some implementations have used an underscore as the separator rather than a dash, for example, en_US; Relying Parties MAY choose to accept this locale syntax as well. |
| MayAct | `may_act` | The "may_act" claim makes a statement that one party is authorized to become the actor and act on behalf of another party. The claim value is a JSON object and members in the JSON object are claims that identify the party that is asserted as being eligible to act for the party identified by the JWT containing the claim. |
| MiddleName | `middle_name` | Middle name(s) of the End-User. Note that in some cultures, people can have multiple middle names; all can be present, with the names being separated by space characters. Also note that in some cultures, middle names are not used. |
| Name | `name` | End-User's full name in displayable form including all name parts, possibly including titles and suffixes, ordered according to the End-User's locale and preferences. |
| NickName | `nickname` | Casual name of the End-User that may or may not be the same as the given_name. For instance, a nickname value of Mike might be returned alongside a given_name value of Michael. |
| Nonce | `nonce` | String value used to associate a Client session with an ID Token, and to mitigate replay attacks. The value is passed through unmodified from the Authentication Request to the ID Token. If present in the ID Token, Clients MUST verify that the nonce Claim Value is equal to the value of the nonce parameter sent in the Authentication Request. If present in the Authentication Request, Authorization Servers MUST include a nonce Claim in the ID Token with the Claim Value being the nonce value sent in the Authentication Request. Authorization Servers SHOULD perform no other processing on nonce values used. The nonce value is a case sensitive string. |
| NotBefore | `nbf` | The time before which the JWT MUST NOT be accepted for processing, specified as the number of seconds from 1970-01-01T0:0:0Z. |
| Permission | `urn:pi:protocols:oidc:jwtclaimtypes:permission` |  |
| PhoneNumber | `phone_number` | End-User's preferred telephone number. E.164 (https://www.itu.int/rec/T-REC-E.164/e) is RECOMMENDED as the format of this Claim, for example, +1 (425) 555-1212 or +56 (2) 687 2400. If the phone number contains an extension, it is RECOMMENDED that the extension be represented using the RFC 3966 [RFC3966] extension syntax, for example, +1 (604) 555-1234;ext=5678. |
| PhoneNumberVerified | `phone_number_verified` | True if the End-User's phone number has been verified; otherwise false. When this Claim Value is true, this means that the OP took affirmative steps to ensure that this phone number was controlled by the End-User at the time the verification was performed. |
| Picture | `picture` | URL of the End-User's profile picture. This URL MUST refer to an image file (for example, a PNG, JPEG, or GIF image file), rather than to a Web page containing an image. |
| PreferredUserName | `preferred_username` | Shorthand name by which the End-User wishes to be referred to at the RP, such as janedoe or j.doe. This value MAY be any valid JSON string including special characters such as @, /, or whitespace. The relying party MUST NOT rely upon this value being unique. |
| Profile | `profile` | URL of the End-User's profile page. The contents of this Web page SHOULD be about the End-User. |
| ReferenceTokenId | `reference_token_id` | The reference token identifier. |
| Role | `urn:pi:protocols:oidc:jwtclaimtypes:role` | The role. |
| Scope | `scope` | OpenID Connect requests MUST contain the "openid" scope value. If the openid scope value is not present, the behavior is entirely unspecified. Other scope values MAY be present. Scope values used that are not understood by an implementation SHOULD be ignored. |
| SessionId | `sid` | Session identifier. This represents a Session of an OP at an RP to a User Agent or device for a logged-in End-User. Its contents are unique to the OP and opaque to the RP. |
| StateHash | `s_hash` | State hash value. Its value is the base64url encoding of the left-most half of the hash of the octets of the ASCII representation of the state value, where the hash algorithm used is the hash algorithm used in the alg Header Parameter of the ID Token's JOSE Header. For instance, if the alg is HS512, hash the code value with SHA-512, then take the left-most 256 bits and base64url encode them. The c_hash value is a case sensitive string. |
| Subject | `sub` | Unique Identifier for the End-User at the Issuer. |
| Tenant | `urn:pi:protocols:oidc:jwtclaimtypes:tenant` |  |
| UpdatedAt | `updated_at` | Time the End-User's information was last updated. Its value is a JSON number representing the number of seconds from 1970-01-01T0:0:0Z as measured in UTC until the date/time. |
| WebSite | `website` | URL of the End-User's Web page or blog. This Web page SHOULD contain information published by the End-User or an organization that the End-User is affiliated with. |
| ZoneInfo | `zoneinfo` | String from the time zone database (http://www.twinsun.com/tz/tz-link.htm) representing the End-User's time zone. For example, Europe/Paris or America/Los_Angeles. |

### Jwt Header Types 
`PerpetualIntelligence.Protocols.Oidc.JwtHeaderTypes`
| Field | Value | Description 
|-|-|-|
| AccessToken | `urn:pi:protocols:oidc:jwttyp:at` | OAuth 2.0 access token |
| AuthorizationRequest | `urn:pi:protocols:oidc:jwttyp:ar` | JWT secured authorization request. |

### Login Methods 
`PerpetualIntelligence.Protocols.Oidc.LoginMethods`
| Field | Value | Description 
|-|-|-|
| Otp | `urn:pi:protocols:oidc:login:otp` | The one-time passcode. |
| Password | `urn:pi:protocols:oidc:login:pwd` | The user password. |
| Pin | `urn:pi:protocols:oidc:login:pin` | The personal identificaiton number or a pattern. |

### Parameters 
`PerpetualIntelligence.Protocols.Oidc.Parameters`
| Field | Value | Description 
|-|-|-|
| AccessToken | `access_token` |  |
| AcrValues | `acr_values` |  |
| ActorToken | `actor_token` |  |
| ActorTokenType | `actor_token_type` |  |
| Algorithm | `alg` |  |
| Assertion | `assertion` |  |
| Audience | `audience` |  |
| ClientAssertion | `client_assertion` |  |
| ClientAssertionType | `client_assertion_type` |  |
| ClientId | `client_id` |  |
| ClientSecret | `client_secret` |  |
| Code | `code` |  |
| CodeChallenge | `code_challenge` |  |
| CodeChallengeMethod | `code_challenge_method` |  |
| CodeVerifier | `code_verifier` |  |
| DeviceCode | `device_code` |  |
| Display | `display` |  |
| Error | `error` |  |
| ErrorDescription | `error_description` |  |
| ExpiresIn | `expires_in` |  |
| GrantType | `grant_type` |  |
| IdToken | `id_token` |  |
| IdTokenHint | `id_token_hint` |  |
| IssuedTokenType | `issued_token_type` |  |
| Issuer | `iss` |  |
| Key | `key` |  |
| LoginHint | `login_hint` |  |
| MaxAge | `max_age` |  |
| Nonce | `nonce` |  |
| Password | `password` |  |
| PostLogoutRedirectUri | `post_logout_redirect_uri` |  |
| Prompt | `prompt` |  |
| RedirectUri | `redirect_uri` |  |
| RefreshToken | `refresh_token` |  |
| Request | `request` |  |
| RequestedTokenType | `requested_token_type` |  |
| RequestUri | `request_uri` |  |
| Resource | `resource` |  |
| ResponseMode | `response_mode` |  |
| ResponseType | `response_type` |  |
| Scope | `scope` |  |
| Sid | `sid` |  |
| State | `state` |  |
| SubjectToken | `subject_token` |  |
| SubjectTokenType | `subject_token_type` |  |
| TokenType | `token_type` |  |
| UiLocales | `ui_locales` |  |
| UserName | `username` |  |

### Prompt Modes 
`PerpetualIntelligence.Protocols.Oidc.PromptModes`
| Field | Value | Description 
|-|-|-|
| Consent | `consent` | The Authorization Server SHOULD prompt the End-User for consent before returning information to the Client. If it cannot obtain consent, it MUST return an error, typically consent_required. |
| Login | `login` | The Authorization Server SHOULD prompt the End-User for reauthentication. If it cannot reauthenticate the End-User, it MUST return an error, typically login_required. |
| None | `none` | The Authorization Server MUST NOT display any authentication or consent user interface pages. An error is returned if an End-User is not already authenticated or the Client does not have pre-configured consent for the requested Claims or does not fulfill other conditions for processing the request. The error code will typically be login_required, interaction_required, or another code defined in Section 3.1.2.6. This can be used as a method to check for existing authentication and/or consent. |
| SelectAccount | `select_account` | The Authorization Server SHOULD prompt the End-User to select a user account. This enables an End-User who has multiple accounts at the Authorization Server to select amongst the multiple accounts that they might have current sessions for. If it cannot obtain an account selection choice made by the End-User, it MUST return an error, typically account_selection_required. |

### Response Modes 
`PerpetualIntelligence.Protocols.Oidc.ResponseModes`
| Field | Value | Description 
|-|-|-|
| FormPost | `form_post` | In this mode, Authorization Response parameters are encoded as HTML form values that are auto-submitted in the User Agent, and thus are transmitted via the HTTP POST method to the Client, with the result parameters being encoded in the body using the application/x-www-form-urlencoded format. The action attribute of the form MUST be the Client's Redirection URI. The method of the form attribute MUST be POST. Because the Authorization Response is intended to be used only once, the Authorization Server MUST instruct the User Agent (and any intermediaries) not to store or reuse the content of the response. Any technique supported by the User Agent MAY be used to cause the submission of the form, and any form content necessary to support this MAY be included, such as submit controls and client-side scripting commands.However, the Client MUST be able to process the message without regard for the mechanism by which the form submission was initiated. |
| Fragment | `fragment` | In this mode, Authorization Response parameters are encoded in the fragment added to the redirect_uri when redirecting back to the Client. |
| Query | `query` | In this mode, Authorization Response parameters are encoded in the query string added to the redirect_uri when redirecting back to the Client. |

### Response Types 
`PerpetualIntelligence.Protocols.Oidc.ResponseTypes`
| Field | Value | Description 
|-|-|-|
| Code | `code` | When supplied as the value for the response_type parameter, a successful response MUST include an authorization code. |
| CodeIdToken | `code id_token` | When supplied as the value for the response_type parameter, a successful response MUST include both an authorization code and an id_token. The default Response Mode for this Response Type is the fragment encoding and the query encoding MUST NOT be used. Both successful and error responses SHOULD be returned using the supplied Response Mode, or if none is supplied, using the default Response Mode. |
| CodeIdTokenToken | `code id_token token` | When supplied as the value for the response_type parameter, a successful response MUST include an authorization code, an id_token, an access_token, and an access_token Type. The default Response Mode for this Response Type is the fragment encoding and the query encoding MUST NOT be used. Both successful and error responses SHOULD be returned using the supplied Response Mode, or if none is supplied, using the default Response Mode. |
| CodeToken | `code token` | When supplied as the value for the response_type parameter, a successful response MUST include an access_token, an access_token Type, and an authorization code. The default Response Mode for this Response Type is the fragment encoding and the query encoding MUST NOT be used. Both successful and error responses SHOULD be returned using the supplied Response Mode, or if none is supplied, using the default Response Mode. |
| IdToken | `id_token` | When supplied as the value for the response_type parameter, a successful response MUST include an id_token. |
| IdTokenToken | `id_token token` | When supplied as the value for the response_type parameter, a successful response MUST include an access_token, an access_token Type, and an id_token. The default Response Mode for this Response Type is the fragment encoding and the query encoding MUST NOT be used. Both successful and error responses SHOULD be returned using the supplied Response Mode, or if none is supplied, using the default Response Mode. |
| Token | `token` | When supplied as the value for the response_type parameter, a successful response MUST include an access_token. |

### Standard Scopes 
`PerpetualIntelligence.Protocols.Oidc.StandardScopes`
| Field | Value | Description 
|-|-|-|
| Address | `address` | This scope value requests access to the address claim. |
| Api | `urn:pi:protocols:oidc:scope:api` | This scope value requests access to the Perpetual Intelligence's api claim. |
| Application | `urn:pi:protocols:oidc:scope:app` | This scope value requests access to the Perpetual Intelligence's allowed_apps and subscribed_apps. |
| Email | `email` | This scope value requests access to the Perpetual Intelligence's allowed_apps and subscribed_apps. |
| OfflineAccess | `offline_access` | This scope value requests that an OAuth 2.0 Refresh Token be issued that can be used to obtain an Access Token that grants access to the End-User's UserInfo Endpoint even when the End-User is not present (not logged in). |
| OpenId | `openid` | Informs the Authorization Server that the Client is making an OpenID Connect request. If the openid scope value is not present, the behavior is entirely unspecified. |
| Permission | `urn:pi:protocols:oidc:scope:perm` | This scope value requests access to the Perpetual Intelligence's allowed_perms and subscribed_perms. |
| Phone | `phone` | This scope value requests access to the phone_number and phone_number_verified claims. |
| Profile | `profile` | This scope value requests access to the End-User's default profile claims, which are: name, family_name, given_name, middle_name, nickname, preferred_username, profile, picture, website, gender, birthdate, zoneinfo, locale, and updated_at. |
| Role | `urn:pi:protocols:oidc:scope:role` | This scope value requests access to the Perpetual Intelligence's allowed_roles and active_role. |
| Tenant | `urn:pi:protocols:oidc:scope:tenant` | This scope value requests access to the Perpetual Intelligence's tenant claim. |

### Client Authentication Methods 
`PerpetualIntelligence.Protocols.Oidc.TokenEndpointAuthMethods`
| Field | Value | Description 
|-|-|-|
| Basic | `client_secret_basic` | The client uses HTTP Basic as defined in OAuth 2.0. |
| None | `none` | The client is a public client as defined in OAuth 2.0, and does not have a client secret. |
| PostBody | `client_secret_post` | The client uses the HTTP POST parameters as defined in OAuth 2.0, Section 2.3.1. |
| PrivateKeyJwt | `private_key_jwt` | The client uses the JWT Assertion profile with its own private key. |
| SecretKeyJwt | `client_secret_jwt` | The client uses the JWT Assertion profile with a symmetric secret issued by the server. |
| SelfSignedTlsClientAuth | `self_signed_tls_client_auth` | Indicates that client authentication to the authorization server will occur with mutual TLS utilizing the PKI method of associating a self-signed certificate to a client. |
| TlsClientAuth | `tls_client_auth` | Indicates that client authentication to the authorization server will occur with mutual TLS utilizing the PKI method of associating a certificate to a client. |

### Token Types  
`PerpetualIntelligence.Protocols.Oidc.TokenTypes`
| Field | Value | Description 
|-|-|-|
| AccessToken | `urn:ietf:params:oauth:token-type:access_token` | Indicates that the token is an OAuth 2.0 access token issued by the given authorization server. |
| IdToken | `urn:ietf:params:oauth:token-type:id_token` | Indicates that the token is an ID Token issued by the given authorization server. |
| Jwt | `urn:ietf:params:oauth:token-type:jwt` | Indicates that the token is a JWT. |
| RefreshToken | `urn:ietf:params:oauth:token-type:refresh_token` | Indicates that the token is an OAuth 2.0 refresh token issued by the given authorization server. |
| Saml1 | `urn:ietf:params:oauth:token-type:saml1` | Indicates that the token is a base64url-encoded SAML 1.1. |
| Saml2 | `urn:ietf:params:oauth:token-type:saml2` | Indicates that the token is a base64url-encoded SAML 2.0. |

### User Code Types  
`PerpetualIntelligence.Protocols.Oidc.UserCodeTypes`
| Field | Value | Description 
|-|-|-|
| AlphaNumeric | `urn:pi:protocols:oidc:ucode:anum` | Alphanumeric code. |
| Numeric | `urn:pi:protocols:oidc:ucode:num` | Numeric code. |
