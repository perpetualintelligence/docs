# Hosting
The `OneImlx.Terminal` framework is hosting agnostic, meaning no hosting limitations at all. Application authors can host and run their CLI apps, terminals, or servers on their self-hosting environment, use a managed-hosting environment, or rely on a third party to provide a hosting environment.

You can configure your terminal using Dependency Injection(DI services) and options pattern to provide your self-hosting implementations for stores and host in an environment of your choice, e.g., Windows, Linux, macOS, Docker, Kubernetes, etc.

# Deployment
The `OneImlx.Terminal` framework adopts microservices architectural style for building terminal applications that are resilient, highly scalable, independently deployable, and able to evolve quickly. 

You can build deployment agnostic CLI terminals with all dependencies, test them in local environments and deploy the production terminals on-premise, cloud (public, private, or government), or hybrid.