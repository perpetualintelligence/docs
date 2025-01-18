```mermaid
flowchart TD
    A["🖥️ Customer Azure Portal"] --> B["☁️ Create SaaS Resource"]
    B --> C["🛠️ OneImlx.Terminal Framework"]
    C --> D["🌐 Consumer Portal (consumer.perpetualintelligence.com)"]
    D --> F["📄 Activate Subscription"]
    F --> G["⚙️ Generate Application"]
    G --> H["🔑 Generate License"]
    
    H --> H1["🏢 On-Prem License"]
    H --> H2["☁️ Cloud License"]
    H --> H3["🧪 Demo License"]

    G --> I["📝 Create Terminal Application"]
    I --> J["📚 Review Documentation (docs.perpetualintelligence.com)"]
    J --> K["🛡️ Configure License"]
    K --> L["🧪 Test Terminal Application"]
    L --> M["🚀 Deploy Terminal Application"]

    M --> M1["🌐 On-Cloud (Web Terminal)"]
    M --> M2["🏢 On-Premise"]
    M --> M3["💻 Desktop Servers"]

    M1 --> M1A["🔵 Azure Cloud"]
    M1 --> M1B["🟠 AWS Cloud"]
    M1 --> M1C["🟡 GCP Cloud"]
