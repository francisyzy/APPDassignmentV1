ST1011 Application Development

APPD Assignment 1 Proposal V2
Proposed to:
Mr Tan Hu Shien

Singapore Polytechnic

By
Class: DIT/FT/1A/23

Team Members(Student ID):
Francis Yeo (1625950)
ZHAO FENGYE (1651449)


Submission Date: 17 Nov 2016
Word count: 232

Objectives
Booking of houses for rental to let landlords to rent their houses for a short period of time to tourists. 
Users can login into the system to book the houses.
The scheduling system will be based on days and not hours.
List of candidate class
Resource Class: 
Rooms of how people can book. List of rooms that users can select from browsing the index.
Properties: Rent Period, Region. Price, BedCount, FullAddress, PostalCode, ResourceId(Primary Key)
Methods: Dont have

Unit: Aircon(int), UnitID, RoomCount, House size, Facilities

Room: Aircon(boolean), RoomID, Room size
Cart Class:
People select which rooms they want to book, like reserve/shortlist the rooms?
Properties: List<CartitemList>
Methods: Compute total amount, Remove cart item, add cart item, Remove all items
Transaction Xaml Class:
Booking Class where people book rooms.
Properties: From Resource Class
Methods: Calls clear all cart items

(Suggested Classes)
Login Class:
Verify user input match with the info inside database, and provide user ID variable
Properties:Email,Password
Methods: CheckAgainstDatabase
Retrieve Class:
Get other user information after success login
Properties: ContactNo, FirstName, LastName, Email,Password, Birthdate, AcceptContract, CreditNo ,CVC, Expiredate
Methods: Retrieve from database
