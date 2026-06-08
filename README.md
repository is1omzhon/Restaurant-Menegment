# 🍽️ RESTAURANT RESERVATION SYSTEM

## 📌 *Complete Restaurant Management Solution*

---

## 📖 Loyiha haqida

**Restaurant Reservation System** — bu restoranlar uchun mo'ljallangan to'liq boshqaruv tizimi. Ushbu tizim orqali mijozlar **restoran qidirish**, **stol band qilish**, **menu ko'rish**, **buyurtma berish** va **sharh qoldirish** imkoniyatlariga ega. Restoran egalari esa o'z restoranlarini, stollarini va menyularini boshqarishi mumkin.

---

## 👥 Foydalanuvchi turlari

| Rol | Imkoniyatlar |
|-----|--------------|
| 🧑 **Customer (Mijoz)** | Restoran qidirish, stol band qilish, menu ko'rish, buyurtma berish, sharh yozish |
| 👨‍💼 **RestaurantOwner (Restoran egasi)** | Restoran qo'shish, stol qo'shish, menu boshqarish, bandlarni ko'rish |
| 👑 **Admin (Administrator)** | Hamma narsani boshqarish, userlarni bloklash, statistikalar |

---

## 🏗️ Loyiha tuzilishi
RestaurantReservationSystem/
│
├── Enums/
│ ├── UserRole.cs # Customer, Owner, Admin
│ ├── ReservationStatus.cs # Pending, Confirmed, Cancelled, Completed
│ └── OrderStatus.cs # Received, Preparing, Ready, Served
│
├── Models/
│ ├── Common/
│ │ └── BaseEntity.cs # Id, CreatedAt, UpdatedAt
│ │
│ ├── Users/
│ │ ├── User.cs
│ │ ├── Customer.cs
│ │ ├── RestaurantOwner.cs
│ │ └── Admin.cs
│ │
│ └── Restaurant/
│ ├── Restaurant.cs
│ ├── Table.cs
│ ├── MenuItem.cs
│ └── Category.cs
│
├── Services/
│ ├── Helpers/
│ │ └── FileStorage.cs
│ │
│ ├── Interfaces/
│ │ ├── IUserService.cs
│ │ └── IRestaurantService.cs
│ │
│ └── Implementations/
│ ├── UserService.cs
│ └── RestaurantService.cs
│
├── Data/
│ ├── users.json
│ └── restaurants.json
│
└── Program.cs

## ⚙️ Asosiy funksiyalar
#### 👤 Mijoz (Customer) uchun:
#### 🔍 Restoranlarni qidirish (nom, cuisine, rating bo'yicha)
#### 🪑 Stol band qilish (real-time availability)
#### 📋 Menu ko'rish
#### 🛒 Buyurtma berish
#### ⭐ Sharh va reyting qoldirish

## 👨‍💼 Restoran egasi (RestaurantOwner) uchun:
#### ➕ Restoran qo'shish / tahrirlash / o'chirish
#### 🪑 Stol qo'shish / tahrirlash
#### 📝 Menyuga taom qo'shish / tahrirlash
#### 📊 Bandlarni ko'rish

## 👑 Admin uchun:
#### 👥 Barcha userlarni boshqarish
#### 🏪 Barcha restoranlarni boshqarish
#### 📈 Statistikalar ko'rish