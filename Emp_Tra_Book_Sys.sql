Create database Employee_Travel_Booking_System

use Employee_Travel_Booking_System


-- admins table to store information about administrators
create table admins (
    adminid int primary key,
    name varchar(100),
    email varchar(100),
	admin_password varchar(50),
)

drop table admins


-- managers table to store information about managers
create table managers (
    managerid int primary key identity (100,1),
    name varchar(50),
    department varchar(50),
    email varchar(50),
	mgr_password varchar(50)
)

drop table managers


-- travel agents table to store information about travel agents
create table travelagents (
    agentid int primary key,
    name varchar(100),
    email varchar(100),
	travel_agent_password varchar(50)
)

-- employees table to store information about employees
create table employees (
    employeeid int primary key identity (100,1),
    emp_name varchar(50),
	email varchar(50),
	emp_password varchar(50),
    department varchar(50),
	position varchar(50),
	hiredate date,
    phonenumber varchar(20),
    address varchar(255),
	Reporting_Manager_Id int foreign key references managers(managerid)
)

drop table employees

-- travelrequests table to store travel requests submitted by employees
create table travelRequest (
    requestid int primary key,
    employeeFirstName varchar(100),
    employeeLastName varchar(100),
    employeeEmail varchar(100),
    employeeid int,
    reasonForTravel varchar(255),
    flightNeeded bit,
    hotelNeeded bit,
    departureCity varchar(100),
    arrivalCity varchar(100),
    departureDate date,
	arrivalDate date,
    additionalInformation text,
	foreign key (employeeid) references employees(employeeid),
	approvalstatus VARCHAR(50) DEFAULT 'Pending' CHECK (approvalstatus IN ('approved', 'rejected','pending'))
)

drop table travelRequest

-- approval table to store approvals/rejections by managers
--create table approvals (
--    approvalid int primary key,
--    requestid int,
--    managerid int,
--    approvalstatus varchar(50) check (approvalstatus in ('approved', 'rejected')),
--    foreign key (requestid) references travelrequest(requestid),
--    foreign key (managerid) references managers(managerid)
--)

--drop table approvals


-- bookingstatus table to store booking status by travel agents
create table bookingstatus (
    bookingid int primary key,
    requestid int,
    agentid int,
    status varchar(50) check (status IN ('confirmed', 'not available')), -- Restriction on status
    foreign key (requestid) references travelRequest(requestid),
    foreign key (agentid) references travelagents(agentid)
)

drop table bookingstatus


Select * from admins
Select * from managers
Select * from travelagents
Select * from employees
Select * from travelRequest
Select * from bookingstatus


Insert into admins values(111,'Suryansh','SuryanshD@gmail.com','Surya@123')

Insert into managers values('Venuegopal','It','Venue@gmail.com','Venue@123')
Insert into managers values('Surya','Development','Surya@gmail.com','Surya@123')

Insert into employees values('Suryansh','Suryansh@gmail.com','Ssssss','It','S.E.','02-02-2022','1234567890','HYD',100),
('Vishal','Vishu@gmail.com','Ssssss','It','S.E.','02-02-2022','1234567890','HYD',100)

Insert into employees values('S D','Suryansh@gmail.com','Ssssss','It','S.E.','02-02-2022','1234567890','HYD',101),
('V D','Vishu@gmail.com','Ssssss','It','S.E.','02-02-2022','1234567890','HYD',101)
   

Insert into travelRequest values(1, 'John', 'Doe', 'john.doe@example.com', 101, 'Business meeting', 1, 1, 'New York',
'Los Angeles', '2024-05-15', '2024-05-20', 'Additional info 1', 'pending')
Insert into travelRequest values(3, 'John', 'Doe', 'john.doe@example.com', 102, 'Business meeting', 1, 1, 'New York',
'Los Angeles', '2024-05-15', '2024-05-20', 'Additional info 1', 'pending')
Insert into travelRequest values(4, 'John', 'Doe', 'john.doe@example.com', 103, 'Business meeting', 1, 1, 'New York',
'Los Angeles', '2024-05-15', '2024-05-20', 'Additional info 1','pending')
Insert into travelRequest values(5, 'John', 'Doe', 'john.doe@example.com', 101, 'Business meeting', 1, 1, 'New York',
'Los Angeles', '2024-05-15', '2024-05-20', 'Additional info 1', 'pending')



--values for manager surya 
Insert into travelRequest values(6, 'John2', 'Doe', 'john.doe@example.com', 108, 'Business meeting', 1, 1, 'New York',
'Los Angeles', '2024-05-15', '2024-05-20', 'Additional info 1', 'pending')
Insert into travelRequest values(7, 'John2', 'Doe', 'john.doe@example.com', 109, 'Business meeting', 1, 1, 'New York',
'Los Angeles', '2024-05-15', '2024-05-20', 'Additional info 1', 'pending')
Insert into travelRequest values(8, 'John2', 'Doe', 'john.doe@example.com', 108, 'Business meeting', 1, 1, 'New York',
'Los Angeles', '2024-05-15', '2024-05-20', 'Additional info 1','pending')
Insert into travelRequest values(9, 'John2', 'Doe', 'john.doe@example.com', 109, 'Business meeting', 1, 1, 'New York',
'Los Angeles', '2024-05-15', '2024-05-20', 'Additional info 1', 'pending')

Insert into travelRequest(requestid, employeeFirstName, employeeLastName, employeeEmail, employeeid, reasonForTravel, flightNeeded, hotelNeeded, departureCity, arrivalCity, departureDate, arrivalDate, additionalInformation) 
values
(5, 'John', 'Doe', 'john.doe@example.com', 101, 'Business meeting', 1, 1, 'New York', 'Los Angeles', '2024-05-15', '2024-05-20', 'Additional info 1'),
(6, 'John', 'Doe', 'john.doe@example.com', 102, 'Business meeting', 1, 1, 'New York', 'Los Angeles', '2024-05-15', '2024-05-20', 'Additional info 1'),
(7, 'John', 'Doe', 'john.doe@example.com', 104, 'Business meeting', 1, 1, 'New York', 'Los Angeles', '2024-05-15', '2024-05-20', 'Additional info 1');



(1027,'Suryansh','Dwivedi','SuryanshD@gmail.com',103,'For business purpose',
1,1,'Lucknow','Delhi','12-12-2022','14-12-2022','No additional info','Pending')