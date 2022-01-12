## IAM 
Identity and access management (IAM) is a system or a service that helps you securely control access to your resources. Organizations use IAM to control who is authenticated (signed in) and authorized (has permissions) to use resources.

## Access Management
Access management for resources is critical for any organization, whether on-premise, cloud, or hybrid environments. Perpetual Intelligence [OneImlx](/articles/concepts/oneimlx.md) framework provides state-of-the-art access control that helps you manage:
- who has access to resources (users or subjects)?
- what times can they access resources (expirations and renewals)?
- what can they do with those resources (permissions)?
- what areas do they have access to (groups)?

The framework supports multi-tiered access control systems designed to limit resource access based on predefined constraints:
- mode-based (Deployment modes)
- tenant-based (Multi-tenant systems)
- role-based (Organization roles and responsibilities)
- scope-based (OAuth and OpenID Connect)
- level-based (Workforce and Organizational security)

### What is MBAC?
Mode-Based access control (MBAC) is a permission scoping system that enables you to limit resource access based on the deployment modes. [OneImlx](/articles/concepts/oneimlx.md) supports the following deployment modes for the resources and data entities.
- Test (Testing and development)
- Stage (Pre-production)
- Live (Production)
- Neutral (Mode independent)

### What is TBAC?
Tenant-Based Access Control (TBAC) is the permission validation system that enables you to define multi-tenant systems and limit access based on an active tenant. Applications can switch tenants to refresh the permissions and access control.

e.g., picture 

### What is RBAC?
Role-Based Access Control (RBAC) is the permission management system that enables you to closely align the roles you assign users, administrators, contributors, internal and external collaborators to the actual roles they hold within your organization.

e.g., picture

### What is SBAC?
Scope-Based Access Control (SBAC) is the permission limiting system that enables you to limit access to resources and user account. An application can request multiple scopes that an authorization server then presents in a consent screen. The user can consent, modify or reject the requested scopes entirely. If the user gives the consent, the authorization server will issue an access_token with the selected scoped granting access to the application or service.

### What is LBAC?
Level-Based access control (LBAC) is a permission limiting system that enables you to limit access to resources based on the organization levels. LBAC enforces workforce and organizational security based on corporate structures, business segments, engineering departments, dev groups, public-private partnerships, or government hierarchies for up to 10 levels.

The levels can be hierarchical or structural, horizontal or flat, or hybrid within an organization.

> Organizations have complete freedom to define permissions, roles, scopes, and levels to enable optimal access control for their apps and services.

e.g., picture

## Identity Management

### Identity Provider (IdP or IDP)
An identity provider (IdP) is a managed service that securely stores and manages the digital identities of your users. They provide authentication and authorization services to the relying parties (RPs) within a federation or distributed network. 

### RP
Relying party (RP) is a service, application, or system that relies on an identity provider (IdP) to authenticate a user requesting access to the resources. A relying party does not store any user profile data or its credentials. Instead, it delegates the identity management, authentication, and authorization to the identity provider (IdP).

### OP
An OP is the [OpenID Connect](https://openid.net/connect/) compliant identity provider. It provides authentication and authorization for the relying parties (RPs). It may rely on another OIDC Provider (OP) or another Identity Provider (IdP).

### Subject
A subject is an object that represents a user, group, service principal, or managed identity that is requesting access to resources. You can assign a role to a subject.

### User
A user is a subject that is a person that requests access to a resource. Typically user never accesses a resource directly. They often rely on Relying Party (RP) to initiate authentication with the OP.

### Tenant
The customers signing up to use your system are your tenants. A tenant can be an individual user, a small-medium business (SMB), a government organization, a corporate, or a large enterprise. See [Multi-tenant systems](/articles/concepts/multi_tenant_systems.md) for more information.

### Organization
An organization is an object that represents a company, business, or enterprise. In a multi-tenant environment, we add organization to the tenant of a system. The LBAC

### Organization Level
An organization level is a hierarchical, structural, or horizontal categorization of various departments or groups.

### Client
A client is an (RP) application or a service that defines how users are authenticated or authorized with an OP. The Clients have metadata associated with their unique client identifier at the Authorization Server. These can range from human-facing display strings, such as a client name, to items that impact the protocol's security, such as the list of valid redirect URIs.  See [OpenID Connect Registration](https://openid.net/specs/openid-connect-registration-1_0.html) for more information

## Permission Management

### Permission
A permission is an action the subject can perform on the resource.

### Role
A role is a named object with a collection of permissions. A role definition lists the actions that a subject can perform, such as read, write, and delete. Roles can be high-level, like an admin, owner, contributor, collaborator, or specific to action, e.g., api-deploy-approver.

### Scope
The scope is a named object that identifies the set of resources and permissions for those resources.

### Group
A group is a collection of subjects who share common access to resources. A group defines transitive permissions to a subject. E.g., user U1 is a member of group G1, and G1 is a member of another group, G2, that has role R1 role assignment. The user U1 will automatically have R1 permissions.

## Resource Protection

### Resource
A resource is any and everything that you want to protect.

### Scoped resource
A scoped resource is a set of claims requested using a scope. The [OpenID Connect](https://openid.net/connect/) specification defines the standard scope to claim type mappings. Organizations can use these predefined mappings or specify new mappings based on their needs. E.g., The RP requesting access to the user's data may use ***profile*** scope to request username, first and last name, email, picture, etc.

### Protected resource
A protected resource is an entity or a service that performs a protected action based on the request sent by the RP. E.g., The RP sends a request to create a new user at the ***/users/create*** API endpoint. The API endpoint is a protected resource that can be accessed only by an authorized RP.

### Metered resource
A metered resource is a protected resource that costs based on its usage. A metered resource has a metering policy that measures its use and a costing policy that determines the cost based on the use. E.g., The RP sends a request to licensing service to start the usage.

### Public resource
A public resource is an unprotected resource accessible by a public URI. No authentication or authorization is needed to access this resource.