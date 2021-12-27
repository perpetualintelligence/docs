
## Endpoints
The table below summarizes the [OAuth 2.0](https://oauth.net/2/) and [OpenID Connect](https://openid.net/developers/specs/) authorization server endpoints. All [OneImlx](http://localhost:8080/articles/oneimlx.html) endpoints implements `IAuthServerHandler<TContext, TResult>` interface and <xref href="System.Collections.Immutable.ImmutableArray`1" altProperty="name"/>.

| Endpoint | OneImlx Endpoint Id | Protocol |
|----------|-----|----------|
| authorize | urn:oneimlx:auth | [OAuth 2.0 Authorization Framework](https://datatracker.ietf.org/doc/html/rfc6749#section-4.2.1) | 
| check_session or check_session_iframe | urn:oneimlx:checksession | [OpenID Connect Session Management](https://openid.net/specs/openid-connect-session-1_0.html) | 
| device_authorization | urn:oneimlx:device | [OAuth 2.0 Device Authorization Grant](https://datatracker.ietf.org/doc/html/rfc8628) | 
| discovery or .well-known | urn:oneimlx:discovery | [OpenID Connect Discovery](https://openid.net/specs/openid-connect-discovery-1_0.html) | 
| end_session | urn:oneimlx:endsession | [OpenID Connect Session Management](https://openid.net/specs/openid-connect-session-1_0.html) | 
| introspect | urn:oneimlx:introspect | [OAuth 2.0 Token Introspection](https://datatracker.ietf.org/doc/html/rfc7662#section-2) | 
| jwks | urn:oneimlx:jwks | [OAuth 2.0 JSON Web Key (JWK)](https://datatracker.ietf.org/doc/html/rfc7517) | 
| revoke | urn:oneimlx:revoke | [OAuth 2.0 Token Revocation](https://datatracker.ietf.org/doc/html/rfc7009#section-2.1) | 
| token | urn:oneimlx:token | [OAuth 2.0 Authorization Framework](https://datatracker.ietf.org/doc/html/rfc6749#section-3.2) | 
| user_info | urn:oneimlx:userinfo | [OpenID Connect User Info](https://openid.net/specs/openid-connect-core-1_0.html#UserInfo) | 

