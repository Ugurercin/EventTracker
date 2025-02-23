# 🚀 EventTracker - Kafka Event Processing in .NET 8

![Kafka](https://img.shields.io/badge/Kafka-3.5.1-orange?style=flat-square)
![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet?style=flat-square)
![C#](https://img.shields.io/badge/C%23-9.0-blue?style=flat-square)
![OpenTelemetry](https://img.shields.io/badge/OpenTelemetry-Supported-brightgreen?style=flat-square)
![License](https://img.shields.io/badge/License-MIT-success?style=flat-square)

### **📡 Real-time Event Processing with Kafka & .NET**
🔌 Plug & Play Kafka Event Processing for .NET
A lightweight, event-driven Kafka microservice designed for seamless integration into any .NET project. This module provides asynchronous messaging, event processing, and observability with minimal setup.

🚀 The goal? Just copy, paste, and plug it into your project—perfect for quick setups and scalable event-driven applications.

This makes it clear that the module is meant to be reusable, saving time for developers who need a quick and reliable Kafka consumer-producer setup.

Would you like to add an example on how to integrate this into an existing project? 🚀

## 📑 **Table of Contents**
- [🔹 Features](#-features)
- [🛠️ Tech Stack](#️-tech-stack)
- [📦 Project Structure](#-project-structure)
- [🚀 Quick Start](#-quick-start)
- [⚙️ Configuration](#️-configuration)
- [🔗 Resources](#-resources)


---

## 🔹 **Features**
✅ **Kafka Event Streaming** - Publishes and consumes messages in real-time.  
✅ **Microservices Architecture** - Modular and scalable design.  
✅ **Observability** - Integrated with **OpenTelemetry + Jaeger** for tracing events.  
✅ **Background Processing** - Uses `.NET IHostedService` to run Kafka consumers.  
✅ **Error Handling & Retry** - Implements **robust retry mechanisms** for failed events.  
✅ **Swagger API Documentation** - OpenAPI support for testing.  
✅ **Dockerized Setup** - Easily deploy with **Docker + Docker Compose**.  

---

## 🛠️ **Tech Stack**
| **Technology**   | **Version** |
|-----------------|------------|
| **.NET**        | 8.0        |
| **Kafka**       | 3.5.1      |
| **Zookeeper**   | 3.8.2      |
| **OpenTelemetry** | Latest    |
| **Docker**      | 24.0.5     |
| **Swagger**     | 6.6.0      |

---


---

## 🚀 **Quick Start**
### **📌 1️⃣ Clone the Repository**
```sh
git clone https://github.com/Ugurercin/EventTracker.git
cd EventTracker

```


### **📌 2️⃣ Run Kafka with Docker**
```sh
docker-compose up -d
```


### **📌 3️⃣ Run the API**
```sh
docker-compose up -d

Swagger should now be available at: http://localhost:5000
```


## 🔗 **Resources**
📚 Kafka Docs: https://kafka.apache.org/documentation

📚 .NET Kafka Client: https://github.com/confluentinc/confluent-kafka-dotnet

📚 OpenTelemetry Docs: https://opentelemetry.io/docs/