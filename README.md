# ♻️ PolyLoop Packaging Assist

A Blazor Server application designed to assist with plastic packaging classification and labeling in an industrial or recycling setting.

## 📖 Description

PolyLoop Packaging Assist is a web-based tool that guides users through creating a new plastic packaging record. Users select the general plastic type, the specific subtype, and the packaging form. The system then uses two cameras:
- One captures the **weight display**, which is read using Optical Character Recognition (OCR).
- The other captures an **image of the plastic item**, which is uploaded to OneDrive as proof.

Once recorded, the system prints a label containing a **QR code** with the ID, plastic type, and weight. All data is also saved to a database and can be reviewed from a list view.

## 🚀 Features

- Guided multi-step packaging creation process
- Plastic type, subtype, and packaging type selection
- Camera integration:
  - OCR from weight scale image
  - Photo proof storage to OneDrive
- Label printing with QR code
- Data persistence to database
- Record viewing through UI list

## 🛠️ Technologies Used

- .NET 8 / .NET 7
- Blazor Server
- Entity Framework Core
- Azure OneDrive API
- OCR library (e.g., Tesseract or IronOCR)
- QR Code generation (e.g., QRCoder)
- Brother QL-820NWB printer integration
- SQL Server / SQLite

## 🧑‍💻 Getting Started

### Prerequisites

- .NET SDK 8.x
- Visual Studio 2022+
- Camera support on local device or connected hardware
- SQL Server (or your configured DB)
- Brother QL-820NWB printer driver
- OneDrive credentials for image storage

### Installation

```bash
git clone https://github.com/GerhardHalkjaer/PolyLoop.git
cd polyloop-packaging-assist
dotnet restore
dotnet run
