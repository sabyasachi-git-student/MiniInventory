MiniInventory

MiniInventory is a minimal full-stack inventory management application built using:

Backend: .NET 8, GraphQL (Hot Chocolate), Entity Framework Core, SQLite

Frontend: React (Vite), Apollo Client

This project demonstrates CRUD operations implemented using GraphQL with a clean React user interface.

Features

Add inventory items (name, type, quantity)

Update quantity of existing items

Delete inventory items

GraphQL API built using Hot Chocolate

React UI using Apollo Client

SQLite database (no separate installation required)

Technology Stack
Backend

.NET 8

GraphQL (Hot Chocolate)

Entity Framework Core

SQLite

Frontend

React

Vite

Apollo Client

Prerequisites

This project runs on Windows, macOS, and Linux.

1. .NET SDK (8.0 or later)

Download from:
https://dotnet.microsoft.com/download

Verify installation:

dotnet --version

2. Node.js (18 or later recommended)

Download from:
https://nodejs.org/

Verify installation:

node -v
npm -v

Note about SQLite

You do not need to install SQLite separately.
SQLite is bundled and managed automatically through Entity Framework Core.

Project Structure
MiniInventory
├── backend
│   └── MiniInventory
│       └── Inventory.api        (.NET GraphQL API)
└── frontend
    └── inventory-ui             (React application)

Step 1 — Clone the Repository
git clone https://github.com/sabyasachi-git-student/MiniInventory.git
cd MiniInventory

Step 2 — Run the Backend (.NET GraphQL API)

Open a terminal or PowerShell window and run:

cd backend/MiniInventory/Inventory.api
dotnet restore
dotnet run

You should see output similar to:

Now listening on: http://localhost:7054

Verify Backend

Open a browser and navigate to:

http://localhost:7054/graphql


The GraphQL playground (Banana Cake Pop) should load.

Note:
The port number may differ. Always use the port shown in the terminal output.

Step 3 — Run the Frontend (React)

Open a second terminal and keep the backend terminal running.

cd frontend/inventory-ui
npm install
npm run dev


You should see output similar to:

Local: http://localhost:5173/


Open the displayed URL in your browser.

Step 4 — Verify Frontend and Backend Connection

The frontend communicates with the backend using Apollo Client.

Open the following file:

frontend/inventory-ui/src/apolloClient.js


Ensure the GraphQL endpoint matches the backend port:

uri: "http://localhost:7054/graphql"


If the backend is running on a different port, update this value and restart the frontend server.

Step 5 — Using the Application

From the user interface, you can:

Add a new inventory item

Update the quantity of an existing item

Delete an item

Data is stored using SQLite and persists while the backend application is running.

Sample GraphQL Queries (Optional)
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

Common Issues and Troubleshooting
CORS Errors

Ensure the backend is running

Ensure the frontend port (5173 or 5175) is allowed in the backend CORS configuration

Restart the backend after making CORS changes

Blank Screen in Browser

Open browser developer tools and check the console for errors

Verify the GraphQL endpoint in apolloClient.js

Restart the frontend server

Unable to Fetch Data

Check the following:

Backend server is running

GraphQL playground opens successfully

Apollo Client endpoint matches backend port

No CORS errors are present in the browser console

Expected Result

The setup is successful if:

The GraphQL playground loads in the browser

The React UI loads successfully

Inventory items can be added, updated, and deleted

UI updates immediately after each operation

Purpose of This Project

This project is intended as:

A learning demo for GraphQL with .NET

A reference implementation of a full-stack CRUD application

A technical assignment or interview showcase

Author

Sabyasachi Gupta
