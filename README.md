🧾 MiniInventory

A minimal full-stack inventory management demo built with:

Backend: .NET 8 + GraphQL (Hot Chocolate) + EF Core + SQLite

Frontend: React (Vite) + Apollo Client

This project demonstrates CRUD operations using GraphQL with a clean React UI.

Features

Add inventory items (name, type, quantity)

Update quantity of existing items

Delete items

GraphQL API with Hot Chocolate

React UI with Apollo Client

SQLite database (no separate installation required)

 ech Stack

Backend

.NET 8

GraphQL (Hot Chocolate)

Entity Framework Core

SQLite

Frontend

React

Vite

Apollo Client

📋 Prerequisites
1. .NET SDK (8.0+)

Download: https://dotnet.microsoft.com/download

Verify:

dotnet --version

2. Node.js (18+ recommended)

Download: https://nodejs.org/

Verify:

node -v
npm -v


❗ You do NOT need to install SQLite separately.
SQLite is bundled via EF Core and works automatically.

📁 Project Structure
MiniInventory
├── backend
│   └── MiniInventory
│       └── Inventory.api        (.NET GraphQL API)
└── frontend
    └── inventory-ui             (React application)

📥 Step 1 — Clone the Repository
git clone https://github.com/sabyasachi-git-student/MiniInventory.git
cd MiniInventory

⚙️ Step 2 — Run the Backend (.NET GraphQL API)

Open Terminal / PowerShell:

cd backend/MiniInventory/Inventory.api
dotnet restore
dotnet run


You should see output similar to:

Now listening on: http://localhost:7054

Open GraphQL Playground

Open browser:

http://localhost:7054/graphql


You should see Banana Cake Pop (GraphQL UI).

ℹ️ Port number may differ.
Always use the port shown in the terminal.

🎨 Step 3 — Run the Frontend (React)

Open a second terminal (keep backend running):

cd frontend/inventory-ui
npm install
npm run dev


You should see:

Local: http://localhost:5173/


Open this URL in your browser.

🔗 Step 4 — Verify Frontend ↔ Backend Connection

The frontend uses Apollo Client.

Check this file:

frontend/inventory-ui/src/apolloClient.js

Ensure the GraphQL endpoint matches the backend port:

uri: "http://localhost:7054/graphql"

If your backend runs on a different port, update this value accordingly.

✅ Step 5 — Using the Application

From the UI, you can:

Add an item (name, type, quantity)

Update quantity directly

Delete items

📌 Data is stored in SQLite and persists while the backend is running.

🧪 Sample GraphQL Queries (Optional)
Fetch all items
query {
  items {
    id
    name
    type
    quantity
  }
}

Add an item
mutation {
  addItem(name: "Rice", type: "Grain", quantity: 10) {
    id
  }
}

Delete an item
mutation {
  deleteItem(id: 1)
}

Common Issues & Fixes
CORS Error

Ensure backend is running

Ensure frontend port (5173 or 5175) is allowed in CORS policy

Restart backend after CORS changes

Blank Screen

Check browser console for errors

Verify apolloClient.js GraphQL URL

Restart frontend server

Purpose

This project is intended as:

A learning demo for GraphQL with .NET

A reference full-stack CRUD implementation

A technical assignment / interview showcase

👤 Author
Sabyasachi Gupta
