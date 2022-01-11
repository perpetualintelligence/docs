https://docs.microsoft.com/en-us/azure/role-based-access-control/overview reference

[OneImlx](/articles/repos/oneimlx/intro.md) is an authentication and authorization system providing fine-grained access management to resources.

## Access Management
Access management for resources is critical for any organization, whether on-premise, cloud, or hybrid environments. Perpetual Intelligence [OneImlx](/articles/repos/oneimlx/intro.md) framework provides state-of-the-art access control that helps you manage:
- who has access to resources (users or subjects)?
- what can they do with those resources (permissions)?
- what areas do they have access to (groups)?

The framework supports multi-tiered access control systems designed to limit resource access based on predefined constraints:
- mode-based (Deployment modes)
- tenant-based (Multi-tenant systems)
- role-based (Organization roles and responsibilities)
- scope-based (OAuth and OpenID Connect)
- level-based (Workforce and Organizational security)

## What is MBAC?
Mode-Based access control (MBAC) is a permission scoping system that enables you to limit resource access based on the deployment modes. OneImlx supports the following deployment modes for the resources and data entities.
- Test (Testing and development)
- Stage (Pre-production)
- Live (Production)
- Neutral (Mode independent)

## What is TBAC?
Tenant-Based Access Control (TBAC) is the permission validation system that enables you to define multi-tenant systems and limit access based on an active tenant. Applications can switch tenants to refresh the permissions and access control.

e.g., picture 

## What is RBAC?
Role-Based Access Control (RBAC) is the permission management system that enables you to closely align the roles you assign users, administrators, contributors, internal and external collaborators to the actual roles they hold within your organization.

e.g., picture

## What is SBAC?
Scope-Based Access Control (SBAC) is the permission limiting system that enables you to limit access to resources and user account. An application can request multiple scopes that an authorization server then presents in a consent screen. The user can consent, modify or reject the requested scopes entirely. If the user gives the consent, the authorization server will issue an access_token with the selected scoped granting access to the application or service.

## What is LBAC?
Level-Based access control (LBAC) is a permission limiting system that enables you to limit access to resources based on the organization levels. LBAC enforces workforce and organizational security based on corporate structures, business segments, engineering departments, dev groups, public-private partnerships, or government hierarchies for up to 10 levels.

The levels can be hierarchical or structural, horizontal or flat, or hybrid within an organization.

> Organizations have complete freedom to define permissions, roles, scopes, and levels to enable optimal access control for their apps and services.

e.g., picture

## Identity Provider (IdP or IDP)
An identity provider (IdP) is a managed service that securely stores and manages the digital identities of your users. They provide authentication and authorization services to the relying parties (RPs) within a federation or distributed network. 

## RP
Relying party (RP) is a service, application, or system that relies on an identity provider (IdP) to authenticate a user requesting access to the resources. A relying party does not store any user profile data or its credentials. Instead, it delegates the identity management, authentication, and authorization to the identity provider (IdP).

## OP
An OP is the [OpenID Connect](https://openid.net/connect/) compliant identity provider. It provides authentication and authorization for the relying parties (RPs). It may rely on itself, another OIDC Provider (OP), or another Identity Provider (IdP) (ex: the OP provides a front-end for LDAP, WS-Federation, or SAML).

## Resource
A resource is any and everything that you want to protect.

### Scoped resource
A scoped resource is a set of claims that can be requested using a predefined scope. E.g., The RP requesting access to the user's data may use ***profile*** scope to request username, first and last name, email, picture, etc. The [OpenID Connect](https://openid.net/connect/) specification defines the standard scope name to claim type mappings. Organizations can use these predefined mappings or specify new mappings based on their needs.

### Protected resource

### Metered resource

### Unprotected resource

## Permission

## Permission Set

## Role

## Scope

## Group

## User

## Tenant

## Organization

## Organization Level

