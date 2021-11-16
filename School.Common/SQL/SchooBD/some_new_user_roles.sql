
--Database Constraints - What they are and How to use them
--https://www.youtube.com/watch?v=8czTg7Jw8No

create table Logins (
	ID int identity not null primary key,
    UserID  nvarchar(128) not null,
    UserName nvarchar(128) not null,
    Password nvarchar(128) not null,
    Email nvarchar(128),
	--UNIQUE KEY email_UNIQUE (Email)
)


create table Users (
    UserID int identity not null primary key,
    UserName nvarchar(128) not null,
    Password nvarchar(128) not null,
    Email nvarchar(128)
)
go

create table UserRoles (
    UserID int not null,
    RoleID int not null,
    primary key(UserID, RoleID)
)
go


create table Roles (
   RoleID int identity not null primary key,
   RoleName nvarchar(50)
)
go


alter table UserRoles with check add constraint FK_UserRoles_Roles 
foreign key (RoleID) references Roles (RoleID)

alter table UserRoles with check add constraint FK_UserRoles_Users 
foreign key (UserID) references Users (UserID)





create table UserRoles (
    UserId  varchar(50)  NOT NULL,
    RoleID int not null,
    primary key(UserId, RoleID)
)
go

create table Roles (
   RoleID int not null primary key,
   RoleName nvarchar(50)
)
go


alter table UserRoles with check add constraint FK_UserRoles_Roles 
foreign key (RoleID) references Roles (RoleID)

alter table UserRoles with check add constraint FK_UserRoles_Teacher
foreign key (UserId) references Teacher (UserId)

alter table UserRoles with check add constraint FK_UserRoles_Student
foreign key (UserId) references Student (UserId)


ALTER TABLE UserRoles DROP CONSTRAINT FK_UserRoles_Roles
GO

INSERT INTO Roles VALUES
  (10, 'low'),
  (20, 'medium'),
  (50, 'high'),
  (1000, 'Owner'),
  (100, 'Admin'),
  (200, 'Teacher'),
  (300, 'Student'),
  (400, 'Public');





--https://radacad.com/deep-dive-into-security-schema-of-master-data-services-database
CREATE TABLE groups (group_id int PRIMARY KEY,
                     group_name text NOT NULL);
INSERT INTO groups VALUES
  (1, 'low'),
  (2, 'medium'),
  (5, 'high');




  --https://stackoverflow.com/questions/7844460/foreign-key-to-multiple-tables
--CREATE TABLE dbo.Group
--(
--    ID int NOT NULL,
--    Name varchar(50) NOT NULL
--)  

--CREATE TABLE dbo.User
--(
--    ID int NOT NULL,
--    Name varchar(50) NOT NULL
--)

--CREATE TABLE dbo.Ticket
--(
--    ID int NOT NULL,
--    Owner_ID int NOT NULL,
--    Subject varchar(50) NULL
--)

--CREATE TABLE dbo.Owner
--(
--    ID int NOT NULL,
--    User_ID int NULL,
--    Group_ID int NULL,
--    {{AdditionalEntity_ID}} int NOT NULL
--)










  /*CREATE TABLE `users` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `email` varchar(45) NOT NULL,
  `full_name` varchar(45) NOT NULL,
  `password` varchar(64) NOT NULL,
  `enabled` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `email_UNIQUE` (`email`)
);
 
CREATE TABLE `roles` (
  `role_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
);
 
CREATE TABLE `users_roles` (
  `user_id` int(11) NOT NULL,
  `role_id` int(11) NOT NULL,
  KEY `user_fk_idx` (`user_id`),
  KEY `role_fk_idx` (`role_id`),
  CONSTRAINT `role_fk` FOREIGN KEY (`role_id`) REFERENCES `roles` (`role_id`),
  CONSTRAINT `user_fk` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`)
);*/


--INSERT INTO `roles` (`name`) VALUES ('USER');
--INSERT INTO `roles` (`name`) VALUES ('CREATOR');
--INSERT INTO `roles` (`name`) VALUES ('EDITOR');
--INSERT INTO `roles` (`name`) VALUES ('ADMIN');

--INSERT INTO `users` (`username`, `password`, `enabled`) VALUES ('patrick', '$2a$10$cTUErxQqYVyU2qmQGIktpup5chLEdhD2zpzNEyYqmxrHHJbSNDOG.', '1');
--INSERT INTO `users` (`username`, `password`, `enabled`) VALUES ('alex', '$2a$10$.tP2OH3dEG0zms7vek4ated5AiQ.EGkncii0OpCcGq4bckS9NOULu', '1');
--INSERT INTO `users` (`username`, `password`, `enabled`) VALUES ('john', '$2a$10$E2UPv7arXmp3q0LzVzCBNeb4B4AtbTAGjkefVDnSztOwE7Gix6kea', '1');
--INSERT INTO `users` (`username`, `password`, `enabled`) VALUES ('namhm', '$2a$10$GQT8bfLMaLYwlyUysnGwDu6HMB5G.tin5MKT/uduv2Nez0.DmhnOq', '1');
--INSERT INTO `users` (`username`, `password`, `enabled`) VALUES ('admin', '$2a$10$IqTJTjn39IU5.7sSCDQxzu3xug6z/LPU6IF0azE/8CkHCwYEnwBX.', '1');

--INSERT INTO `users_roles` (`user_id`, `role_id`) VALUES (1, 1); -- user patrick has role USER
--INSERT INTO `users_roles` (`user_id`, `role_id`) VALUES (2, 2); -- user alex has role CREATOR
--INSERT INTO `users_roles` (`user_id`, `role_id`) VALUES (3, 3); -- user john has role EDITOR
--INSERT INTO `users_roles` (`user_id`, `role_id`) VALUES (4, 2); -- user namhm has role CREATOR
--INSERT INTO `users_roles` (`user_id`, `role_id`) VALUES (4, 3); -- user namhm has role EDITOR
--INSERT INTO `users_roles` (`user_id`, `role_id`) VALUES (5, 4); -- user admin has role ADMIN


--https://radacad.com/deep-dive-into-security-schema-of-master-data-services-database




--CREATE TABLE PARTY (party_id int not null auto_increment primary key,
--party_type enum('person','organization') not null,
--CONSTRAINT UQ_PARTY UNIQUE(party_id,party_type));

--CREATE TABLE PERSON (party_id int not null primary key, 
--party_type enum('person') NOT NULL DEFAULT 'person',
--....
--CONSTRAINT FK_PERSON_PARTY FOREIGN KEY(party_id,party_type) 
-- REFERENCES PARTY(party_id,party_type));

--CREATE TABLE ORGANIZATION (party_id int not null primary key, 
--party_type enum('organization') NOT NULL DEFAULT 'organization',
--....
--CONSTRAINT FK_PERSON_PARTY FOREIGN KEY(party_id,party_type) 
-- REFERENCES PARTY(party_id,party_type));

--CREATE TABLE ADDRESS(address_id INT NOT NULL auto_increment PRIMARY KEY,
--.... );

--CREATE TABLE PARTY_ADDRESS (party_id INT NOT NULL, address_id INT NOT NULL,
--CONSTRAINT PK_PARTY_ADDRESS PRIMARY KEY(party_id,address_id),
--CONSTRAINT FK_PARTY_ADDRESS_PARTY FOREIGN KEY (party_id) REFERENCES PARTY(party_id),
--CONSTRAINT FK_PARTY_ADDRESS_ADDRESS FOREIGN KEY (address_id) REFERENCES ADDRESS(address_id));



--Constraints in SQL Server 
--What is SQL constraints - Great 
--The purpose of constraints is to maintain the data integrity during an update/delete/insert into a table. 



UPDATE
    Table_A
SET
    Table_A.col1 = Table_B.col1,
    Table_A.col2 = Table_B.col2
FROM
    Some_Table AS Table_A
    INNER JOIN Other_Table AS Table_B
        ON Table_A.id = Table_B.id
WHERE
    Table_A.col3 = 'cool'




-- 1 Select update
    update P1
    set Name = P2.Name
    from Product P1
    inner join Product_Bak P2 on p1.id = P2.id
    where p1.id = 2
--2 Update with a common table expression
    ; With CTE as
    (
        select id, name from Product_Bak where id = 2
    )
    update P
    set Name = P2.name
    from  product P  inner join CTE P2 on P.id = P2.id
    where P2.id = 2
--3 Merge
    --Merge into product P1
    --using Product_Bak P2 on P1.id = P2.id

    --when matched then
    --update set p1.[description] = p2.[description], p1.name = P2.Name;


--https://blog.quest.com/how-to-use-update-from-select-in-sql-server/
--UPDATE e set
--e.City=A.City,
--e.PostCode=A.PostCode
--FROM Employee e
--INNER JOIN [Address] a
--ON e.EmpID = A.EmpID


--UPDATE table1
--SET table1.column = table2.expression1
--FROM table1
--INNER JOIN table2
--ON (table1.column1 = table2.column1)
--[WHERE conditions];