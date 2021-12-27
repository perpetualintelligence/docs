![pi-banner](https://en.gravatar.com/userimage/152742631/4ab9cb340649391354d65b592b744114.png)

# protocols:imlx
[![status: preview](https://img.shields.io/badge/status-preview-yellow)]()
[![src: private](https://img.shields.io/badge/src-private-red)]()
[![usage: paid](https://img.shields.io/badge/usage-paid-green)]()
[![License: Apache](https://img.shields.io/badge/License-TOS-yellow.svg)](https://opensource.org/licenses/MIT)

[![Issues](https://img.shields.io/github/issues/perpetualintelligence/protocols)](https://github.com/perpetualintelligence/protocols/issues)
![Deployment](https://vsrm.dev.azure.com/perpetualintelligence/_apis/public/Release/badge/4c5f1531-e837-40e9-9e5e-47abaa3fab37/2/2)
[![Nuget](https://img.shields.io/nuget/vpre/PerpetualIntelligence.Protocols)](https://www.nuget.org/packages/PerpetualIntelligence.Protocols)

The Perpetual Intelligence `imlx` well-known configuration. `imlx` is our managed service abstraction for identity, multi-language, licensing, rbac, multi-tenancy, and adaptive UX components. 
 
> **Note:** These configurations are part of the Perpetual Intelligence infrastructure. Please do not use it directly in your application code.

The Perpetual Intelligence `oidc` protocol implementation supports following well-known configurations. This document also defines additional configurations to enable enhanced authentication and authorization capabilities.

* The ***Field*** identifies the code element that defines a configuration
* The ***Value*** is the configuration value itself
* The [![infra](https://img.shields.io/badge/-infra-red)]() identifies a configuration, value, parameter, protocol or name defined by the Perpetual Intelligence infrastructure. *Infrastructure components are subject to change without any advance notice. Please do not use it directly in your application code.*

### API Constants 
`PerpetualIntelligence.Protocols.Imlx.ApiConstants`
| Field | Value | Description 
|-|-|-|
| ApiServerHttpClient | `urn:pi:protocols:imlx:api:serverhttp` | The named HTTP client for an API server. |
| ClientAppHttpClient | `urn:pi:protocols:imlx:api:clienthttp` | The named HTTP client for the client application.
| ContentTypeForm | `application/x-www-form-urlencoded` | The API form content type.
| ContentTypeHtml | `text/html; charset=UTF-8` | The API HTML content type.
| ContentTypeJson | `application/json` | The API JSON content type.
| ContentTypeMultipart | `multipart/form-data` | The API Multipart content type.
| LocalhostEndpoint | `urn:pi:protocols:imlx:api:localhost` | The localhost endpoint.
| ProductionEndpoint | `urn:pi:protocols:imlx:api:production` | The production endpoint.
| LivePayment [![infra](https://img.shields.io/badge/-infra-red)]() | `urn:pi:protocols:imlx:payment:live` | The live mode of payments.
| TestPayment [![infra](https://img.shields.io/badge/-infra-red)]() | `urn:pi:protocols:imlx:payment:test` | The test mode of payments.
| VersionV1Url [![infra](https://img.shields.io/badge/-infra-red)]() | `v1` | The v1 version identifier in the URL.
| VersionV1 [![infra](https://img.shields.io/badge/-infra-red)]() | `1.0` | The v1 version identifier.

### Cl Args 
`PerpetualIntelligence.Protocols.Imlx.ClArgs`
| Field | Value | Description 
|-|-|-|
| ControllerAsService | `piargcontrollerasservice` | Command line argument to use controller as a service. |
| EnableLogger | `piargenablelogger` | Command line argument to enable logger. |

### Endpoints 
`PerpetualIntelligence.Protocols.Imlx.Endpoints`
| Field | Value | Description 
|-|-|-|
| Authorize | `urn:pi:protocols:imlx:eps:auth` | The authorization endpoint. |
| AuthorizeCallback | `urn:pi:protocols:imlx:eps:authcb` | The authorization callback endpoint. |
| CheckSession | `urn:pi:protocols:imlx:eps:check` | The check session endpoint. |
| DeviceAuthorization | `urn:pi:protocols:imlx:eps:device` | The device authorization endpoint. |
| DiscoveryConfiguration | `urn:pi:protocols:imlx:eps:config` | The discovery well known configuration. |
| DiscoveryWebKeys | `urn:pi:protocols:imlx:eps:jwks` | The discovery json web keys endpoint. |
| EndSession | `urn:pi:protocols:imlx:eps:end` | The end session endpoint. |
| EndSessionCallback | `urn:pi:protocols:imlx:eps:endcb` | The end session callback endpoint. |
| Introspection | `urn:pi:protocols:imlx:eps:introspect` | The introspection callback endpoint. |
| Revocation | `urn:pi:protocols:imlx:eps:revoke` | The revocation callback endpoint. |
| Token | `urn:pi:protocols:imlx:eps:token` | The token endpoint. |
| UserInfo | `urn:pi:protocols:imlx:eps:userinfo` | [![ToDo](https://img.shields.io/badge/-todo-red)]() |


### Image Provider Types 
`PerpetualIntelligence.Protocols.Imlx.ImageProviderTypes`
| Field | Value | Description 
|-|-|-|
| Upload | `urn:pi:protocols:imlx:imgpvd:upload` | The image is uploaded. |
| Url | `urn:pi:protocols:imlx:imgpvd:url` | The image is a URL. |

### Local Storage Keys  
`PerpetualIntelligence.Protocols.Imlx.LocalStorageKeys`
| Field | Value | Description 
|-|-|-|
| IsDiagnostic | `urn:pi:protocols:imlx:localstoragekeys:isdiagnostic` | Determines the diagnostic state from the local storage. |

### Org Constants  
`PerpetualIntelligence.Protocols.Imlx.OrgConstants`
| Field | Value | Description 
|-|-|-|
| Copyright | `Copyright (c) 2021. All Rights Reserved. Perpetual Intelligence L.L.C.` | The copyright. |
| DoNotReplyEmail | `donotreply@perpetualintelligence.com` | The do not reply email. |
| FullName | `Perpetual Intelligence L.L.C.` | The full name. |
| Imlx | `urn:pi:protocols:imlx` | The imlx protocol. |
| LogoUrl | `https://en.gravatar.com/userimage/152742631/5c2800c8660bdabbfdcc1bf9497964d4.png` | The logo. |
| PrivacyUrl | `https://perpetualintelligence.com/legal/privacy` | The privacy URL. |
| ShortName | `Perpetual Intelligence` | The short name. |
| TermsUrl | `https://perpetualintelligence.com/legal/terms` | The terms URL. |

### Runtime Options   
`PerpetualIntelligence.Protocols.Imlx.RuntimeOptions`
| Field | Value | Description 
|-|-|-|
| ApiServerLocalhostEndpoint | `` | The Api server production endpoint. |
| ApiServerProductionEndpoint | `` | The Api server production endpoint. |
| CheckEntityProperties | `` | The option to check the entity properties. |
| CheckStore | `` | The option to check whether the store exits and if it does not create it automatically. Note check for the store is a performance hit. Enable this option manually to ensure all stores exist and disable it in the production modes. |
| ClientAppLocalhostEndpoint | `` | The client app localhost endpoint. |
| ClientAppProductionEndpoint | `` | The client app production endpoint. |
| DefaultUrlPathVersion | `` | The default Uri path version. |
| EndpointConfiguration | `` | The endpoint mode. |
| PaymentMode | `` | The payment mode. |
| PaymentProvider | `` | The payment provider. |
| UseTestData | `` | The configuration to enable the use of test data. |

### SwaggerConstants   
`PerpetualIntelligence.Protocols.Imlx.SwaggerConstants`
| Field | Value | Description 
|-|-|-|
| V1IdentityGroup | `` | V1 version of Perpetual Intelligence Identity service. |
| V1InternalGroup | `` | V1 version of Perpetual Intelligence internal services. |
| V1OidcGroup | `` | V1 version of Perpetual Intelligence OpenId Connect service. |
