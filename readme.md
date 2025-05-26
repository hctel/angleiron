# Angleiron

## Introduction

**Angleiron** is a modular software solution composed of multiple independent yet complementary projects. It is designed to manage interactions between a client application, a server, database management tools, and merchant-related processes.

The main goal of this solution is to maintain a clean, scalable, and maintainable architecture.

---

## Diagram

---

## Server

The `serverapp` project contains the main backend API. It exposes REST (or gRPC, if applicable) endpoints to handle data exchange between clients and the database.

**Main features:**
- Authentication & Security
- User and Role Management
- Request Handling
- Database Communication

The protocol for proper use of the server can be found [here](doc/protocol.md).

---
## Managing Database

The `merchandapp` project manages the merchant side of the database. It handles creation, updates, and deletion of records related to products, transactions, or partners.

It may also include:
- Initialization scripts for the database
- Tools for migrations or data integrity checks
- Internal administration utilities

---

## Client App

Two versions of the client are available:

- `clientapp`: the current main client application.
- `ClientAppRemake`: an alternative or redesigned version experimenting with new UI/UX concepts.

Both clients consume services from the `serverapp` and provide user interfaces to interact with the system.

---

## Merchand App

The `merchandapp` project is responsible for the merchant-facing application. It provides a user interface for merchants to manage their products, view transactions, and interact with customers.


> 📌 **Note**: For contributions, issues, or suggestions, feel free to open a ticket or a pull request in the corresponding repository.
