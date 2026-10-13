# Task Management Mobile

Cross-platform task management mobile application built with .NET MAUI.

The application consumes a RESTful ASP.NET Core Web API to authenticate users and manage their tasks.

## 🚀 Features

- User authentication with JWT
- Task listing
- Task details
- Create and edit tasks
- Task status and priority management
- REST API integration
- Firebase Cloud Messaging (FCM)
- Firebase Crashlytics
- Local notification permission handling
- MVVM architecture
- Dependency Injection
- HTTP error handling and API response mapping

## 🛠️ Technologies

- .NET 10
- .NET MAUI
- C#
- CommunityToolkit.Mvvm
- HttpClient
- REST API
- JWT Authentication
- Firebase Cloud Messaging
- Firebase Crashlytics

## 🏗️ Architecture

The application follows an MVVM-based structure:

TaskManagement.Mobile
│
├── Models
├── Services
│   └── Interfaces
├── ViewModels
├── Views
├── Routes
└── Platforms
    └── Android

## 🔐 Authentication
The application uses JWT authentication. <br>
After a successful login, the JWT token is stored securely on the device and automatically included in authenticated API requests.

## 🔔 Firebase
Firebase Cloud Messaging is integrated to support push notifications. <br>
Firebase Crashlytics is used to capture and report unexpected application exceptions.

## ⚙️ Configuration
Before running the application, configure the API URL according to the environment. <br>
For Android development, the API must be accessible from the mobile device through the local network. <br>
Firebase configuration requires the corresponding google-services.json file in:
Platforms/Android/google-services.json<br>
The Firebase configuration file is not included in this repository.

## ▶️ Running the application
1. Clone the repository.
2. Open the solution in Visual Studio.
3. Restore NuGet packages.
4. Configure the API base URL.
5. Configure Firebase for Android.
6. Run the application on an Android device or emulator.

## 🔗 Backend
This application consumes the Task Management API:
Task Management API

## 📌 Future Improvements
- Offline-first support
- SQLite local persistence
- Data synchronization between local storage and the API
- Conflict resolution
- Background synchronization
- Push notifications triggered by backend events



## 👨‍💻 Author
Carlos Bolaños

