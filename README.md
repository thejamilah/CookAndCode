# Cook && Code E-Commerce Site

## Contributers
Jamilah McWilliams && Danul De Leon

## Version
- 2.0.0 : Sprint 2
- 1.0.0 : Sprint 1

## Description
This is an e-commerce site dedicated to cookware items with quirky code related merchandise.  It can vary from high tech gadgets that can be used in the kitchen, to an apron with a script printed on it on how to bake a cake, to T-Shirts with code memes.

## Claims
- First and Last Name: To be used later on in the site
- Email Domain: if .edu domain email is used, user is eligible for student discounts
- Birthday: Used for age restriction for certain products
- Favorite Coding Language: Will grant access to certain items in database.

## Policies
- Over 21 to access 21+ page products: There are alcohol related cookware products.
- C# as favorite language: C# is special and allows users to see different items.
- Email domain, .edu is used for student discount page.

## OAuth Providers

We are holding off on making a decision on this for now.  This will be included in Sprint 3.

## Database Schema

![DB Schema](assets/CookwareDBSchema.PNG)

Our BasketItem table is essentially an Entity Join table with a payload of quantity.  These basket items are gathered by user ID and are used to contruct a shopping cart for each user.  Once they are ready to purchase, these items will be moved over to another table that is yet to be constructed in Sprint 3.

## Deployed Site
### https://cookandcode.azurewebsites.net/