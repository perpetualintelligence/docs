![in-progress](https://img.shields.io/badge/status-under--review-yellow)

# Communication Protocol Routers Overview

This overview summarizes specialized routers designed to abstract and simplify the integration of various communication protocols within .NET applications.

## TCP Router (TerminalTcpRouter)

- **Purpose**: Facilitates reliable, ordered, and error-checked delivery of data between applications over TCP.
- **Use Cases**: Applications requiring dependable data transmission, such as file transfers or any server-client communication needing guaranteed delivery.

## UDP Router (TerminalUdpRouter)

- **Purpose**: Provides efficient, low-latency communication for sessions that can tolerate some data loss.
- **Use Cases**: Real-time applications such as gaming, streaming, and VoIP where speed is critical and some data loss is acceptable.

## HTTP Router (TerminalHttpRouter)

- **Purpose**: Manages HTTP request-response cycles, serving web pages or RESTful APIs over the internet.
- **Use Cases**: Web browsing, web services, and REST APIs where interoperability and stateless operation are essential.

## gRPC Router (TerminalGrpcRouter)

- **Purpose**: Enables high-performance RPC communication using HTTP/2, facilitating efficient, cross-language service invocation.
- **Use Cases**: Microservices architectures, distributed computing, and cloud-native applications demanding scalable and performant inter-service communication.

## Pulsar Router (TerminalPulsarRouter)

- **Purpose**: Integrates with Apache Pulsar for scalable, high-throughput messaging and streaming, supporting pub-sub and persistent messaging patterns.
- **Use Cases**: Real-time analytics, data integration pipelines, and microservices communication in distributed systems.

## MQTT Router (TerminalMqttRouter)

- **Purpose**: Simplifies messaging for IoT devices and mobile applications over low-bandwidth, high-latency networks.
- **Use Cases**: IoT device management, real-time monitoring, and scenarios requiring efficient, low-power communication.

## WebSocket Router (TerminalWebSocketRouter)

- **Purpose**: Manages full-duplex communication channels over WebSockets, enabling real-time data flow between clients and servers.
- **Use Cases**: Interactive web applications, live content updates, and applications requiring persistent, real-time communication.

## AMQP Router (TerminalAmqpRouter)

- **Purpose**: Supports enterprise-level messaging with complex routing, reliability, and security features over AMQP.
- **Use Cases**: Enterprise messaging, system integration, and business process automation requiring robust messaging solutions.

## Selecting a Router

Choosing the right router depends on your application's specific communication needs—reliability, speed, bidirectional communication, or message brokering capabilities. Each router abstracts the underlying protocol complexities, providing a simplified interface for developers to integrate network communication features seamlessly into their applications.
