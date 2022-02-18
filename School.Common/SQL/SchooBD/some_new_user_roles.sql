


/*

https://www.geeksengine.com/database/subquery/subquery-in-join-operation.php
For each product category, we want to know at what average unit 
price they were sold and what the average unit price we would 
like to sell for.
 
Subquery is used in FROM clause to get table x which returns the 
average unit price sold for each product category.
 
Table y in the join clause returns the average unit price 
we'd like to sell for each product category.
 
Then table x is joined with table y for each category.
*/
select y.CategoryID, 
    y.CategoryName,
    round(x.actual_unit_price, 2) as "Actual Avg Unit Price",
    round(y.planned_unit_price, 2) as "Would-Like Avg Unit Price"
from
(
    select avg(a.UnitPrice) as actual_unit_price, c.CategoryID
    from order_details as a
    inner join products as b on b.ProductID = a.ProductID
    inner join categories as c on b.CategoryID = c.CategoryID
    group by c.CategoryID
) as x
inner join 
(
    select a.CategoryID, b.CategoryName, avg(a.UnitPrice) as planned_unit_price
    from products as a
    inner join categories as b on b.CategoryID = a.CategoryID
    group by a.CategoryID
) as y on x.CategoryID = y.CategoryID



SELECT wp_woocommerce_order_items.order_id As No_Commande
FROM  wp_woocommerce_order_items
LEFT JOIN 
    (
        SELECT meta_value As Prenom, post_id  -- <----- this
        FROM wp_postmeta
        WHERE meta_key = '_shipping_first_name'
    ) AS a
ON wp_woocommerce_order_items.order_id = a.post_id
WHERE  wp_woocommerce_order_items.order_id =2198 



-- complete database
--https://www.sqlservertutorial.net/sql-server-basics/sql-server-left-join/
--https://sql.queryexamples.com/sql-query-examples-with-answers

--SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME ='books'
--use schooldb;
--SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME ='Teaching'

--For instance, decimal (4,2) indicates that the number will have 2 digits before the decimal point and 2 digits after the decimal point, 
--something like this has to be the number value- ##.##.
CREATE TABLE dbo.Patients
( Name varchar(10),
  Gender varchar(2),
  Height decimal (3,2),
  Weight decimal (5,2)
)
INSERT INTO PATIENTS VALUES('John','M',6.1,80.4)
INSERT INTO PATIENTS VALUES('Bred','M',5.8,73.7)
INSERT INTO PATIENTS VALUES('Leslie','F',5.3,66.9)
INSERT INTO PATIENTS VALUES('Rebecca','F',5.7,50.2)
INSERT INTO PATIENTS VALUES('Shermas','M',6.5,190.6)


CREATE TABLE dbo.MyTable  
(  
  MyDecimalColumn DECIMAL(5,2)  
,MyNumericColumn NUMERIC(10,5)
  
);  
  
GO  
INSERT INTO dbo.MyTable VALUES (123, 12345.12);  
GO  
SELECT MyDecimalColumn, MyNumericColumn  
FROM dbo.MyTable;  

--MyDecimalColumn                         MyNumericColumn  
--------------------------------------- ---------------------------------------  
--123.00                                  12345.12000    
--(1 row(s) affected)  



 
  use schooldb;
	  --https://sql.queryexamples.com/sql-query-examples-with-answers
  use schooldb;
	CREATE TABLE Books
	(
	ISBN varchar(50)  NOT NULL,
    BookId varchar(50)  NOT NULL,
	BookName varchar(100) NOT NULL,
	BookEdition int null ,
	AuthorId varchar(50) NULL,
	Author varchar(100) NULL,
	PublishedDate DATETIME NULL,
	BookType varchar(50) NOT NULL,
	Rating DECIMAL(5, 2) NULL, --1.00  10.00  100.00    1.10  10.25  100.75
    GradeId varchar(50)  NOT NULL,
	GradeName varchar(50)  NOT NULL,
	FilePath varchar(255) NULL,
	FileType varchar(10)  NOT NULL,
	CreatedDate  DATETIME  NULL,
	UpdatedDate  DATETIME  NULL,
	PRIMARY KEY (BookId),
	UNIQUE (ISBN)
	)

	CREATE TABLE QuestionPaper
	(
	ISBN varchar(50)  NOT NULL,
    QuestionPaperId varchar(50)  NOT NULL,
	QuestionPaperName varchar(100) NOT NULL,
	AuthorId varchar(100) NULL,
	Author varchar(100) NULL,
	PublishedDate DATETIME NULL,
	QuestionPaperType varchar(50) NOT NULL,
    GradeId varchar(50)  NOT NULL,
	GradeName varchar(50) NULL,
	FilePath varchar(100) NULL,
	FileType varchar(10)  NOT NULL,
	CreatedDate  DATETIME NULL,
	UpdatedDate  DATETIME NULL,
	PRIMARY KEY (QuestionPaperId),
	UNIQUE (ISBN)
	)

INSERT INTO Books(ISBN,BookId,BookName,BookEdition,AuthorId,Author,PublishedDate,BookType,Rating,
GradeId,GradeName,FilePath,FileType,CreatedDate,UpdatedDate)
 values('ISBN0000000008','BK0000000008','English Little Sister 8',1,'AUT0000000008','Sphiwe The Writter','09/11/2021',
 'Novel',1.10,'Grade8','Grade 8','~/books/','pdf','09/11/2021','09/11/2021') ;

INSERT INTO Books(ISBN,BookId,BookName,BookEdition,AuthorId,Author,PublishedDate,BookType,Rating,
GradeId,GradeName,FilePath,FileType,CreatedDate,UpdatedDate)
 values('ISBN0000000009','BK0000000009','English Little Sister 9',1,'AUT0000000009','Sphiwe The Writter','09/11/2021',
 'Novel',55.75,'Grade9','Grade 9','~/books/','pdf','09/11/2021','09/11/2021') ;

INSERT INTO Books(ISBN,BookId,BookName,BookEdition,AuthorId,Author,PublishedDate,BookType,Rating,
GradeId,GradeName,FilePath,FileType,CreatedDate,UpdatedDate)
 values('ISBN0000000010','BK0000000010','English Little Sister 10',1,'AUT0000000010','Sphiwe The Writter','09/11/2021',
 'Novel',75.15,'Grade10','Grade 10','~/books/','pdf','09/11/2021','09/11/2021') ;

INSERT INTO Books(ISBN,BookId,BookName,BookEdition,AuthorId,Author,PublishedDate,BookType,Rating,
GradeId,GradeName,FilePath,FileType,CreatedDate,UpdatedDate)
 values('ISBN0000000011','BK0000000011','English Little Sister 11',1,'AUT0000000011','Sphiwe The Writter','09/11/2021',
 'Novel',95.75,'Grade11','Grade 11','~/books/','pdf','09/11/2021','09/11/2021') ;

INSERT INTO Books(ISBN,BookId,BookName,BookEdition,AuthorId,Author,PublishedDate,BookType,Rating,
GradeId,GradeName,FilePath,FileType,CreatedDate,UpdatedDate)
 values('ISBN0000000012','BK0000000012','English Little Sister 12',1,'AUT0000000012','Sphiwe The Writter','09/11/2021',
 'Novel',85.15,'Grade12','Grade 12','~/books/','pdf','09/11/2021','09/11/2021') ;

 --########################################################

INSERT INTO Books(ISBN,BookId,BookName,BookEdition,AuthorId,Author,PublishedDate,BookType,Rating,
GradeId,GradeName,FilePath,FileType,CreatedDate,UpdatedDate)
 values('ISBN0000000108','BK0000000108','Maths 8',1,'AUT0000000108','Sphiwe The Writter','09/11/2021',
 'Novel',7,'Grade8','Grade 8','~/books/','pdf','09/11/2021','09/11/2021') ;

INSERT INTO Books(ISBN,BookId,BookName,BookEdition,AuthorId,Author,PublishedDate,BookType,Rating,
GradeId,GradeName,FilePath,FileType,CreatedDate,UpdatedDate)
 values('ISBN0000000109','BK0000000109','Maths 9',1,'AUT0000000109','Sphiwe The Writter','09/11/2021',
 'Novel',7,'Grade9','Grade 9','~/books/','pdf','09/11/2021','09/11/2021') ;

INSERT INTO Books(ISBN,BookId,BookName,BookEdition,AuthorId,Author,PublishedDate,BookType,Rating,
GradeId,GradeName,FilePath,FileType,CreatedDate,UpdatedDate)
 values('ISBN0000000110','BK0000000110','Maths 10',1,'AUT0000000110','Sphiwe The Writter','09/11/2021',
 'Novel',66,'Grade10','Grade 10','~/books/','pdf','09/11/2021','09/11/2021') ;

INSERT INTO Books(ISBN,BookId,BookName,BookEdition,AuthorId,Author,PublishedDate,BookType,Rating,
GradeId,GradeName,FilePath,FileType,CreatedDate,UpdatedDate)
 values('ISBN0000000111','BK0000000111','Maths 11',1,'AUT0000000111','Sphiwe The Writter','09/11/2021',
 'Novel',77,'Grade11','Grade 11','~/books/','pdf','09/11/2021','09/11/2021') ;

INSERT INTO Books(ISBN,BookId,BookName,BookEdition,AuthorId,Author,PublishedDate,BookType,Rating,
GradeId,GradeName,FilePath,FileType,CreatedDate,UpdatedDate)
 values('ISBN0000000112','BK0000000112','Maths 12',1,'AUT0000000112','Sphiwe The Writter','09/11/2021',
 'Novel',89,'Grade12','Grade 12','~/books/','pdf','09/11/2021','09/11/2021') ;



CREATE TABLE BookCheckouts (
  id  int NOT NULL,
  user_id int NOT NULL,
  book_id int NOT NULL,
  checkout_date timestamp,
  return_date timestamp,
  PRIMARY KEY (id),
  FOREIGN KEY (user_id) REFERENCES users(id)
                        ON DELETE CASCADE,
  FOREIGN KEY (book_id) REFERENCES books(id)
                        ON DELETE CASCADE
);


--ImageID
--ImagePath
--UserID
--ImageType
--IsProfilePicture
--CreatededDate
--UpdatedDate
--IsNudity



--https://www.queryexamples.com/sql/table/get-column-names-from-table-sql/

Select * from students where birthdate = 
(Select min(birthdate) from students)




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



use schooldb;
    
DELETE FROM Teaching   
WHERE TeacherId IN   
    (SELECT TeacherId   
     FROM Teaching   
     WHERE TeacherId ='TC0000000888'
	 AND GradeId='Grade008'
	 );  
GO  





/*


CREATE TABLE books(
  book_id        INT GENERATED BY DEFAULT AS IDENTITY NOT NULL, 
  title          VARCHAR(255) NOT NULL, 
  total_pages    INT NULL, 
  rating         DECIMAL(4, 2) NULL, 
  isbn           VARCHAR(13) NULL, 
  published_date DATE NULL, 
  publisher_id   INT NULL, 
  PRIMARY KEY(book_id),
  CONSTRAINT fk_publisher 
    FOREIGN KEY(publisher_id) 
    REFERENCES publishers(publisher_id)
);

CREATE TABLE authors( 
  author_id   INT GENERATED BY DEFAULT AS IDENTITY NOT NULL,
  first_name  VARCHAR(100) NOT NULL, 
  middle_name VARCHAR(50) NULL, 
  last_name   VARCHAR(100) NULL,
  PRIMARY KEY(author_id)
);

CREATE TABLE book_authors (
  book_id   INT NOT NULL, 
  author_id INT NOT NULL, 
  PRIMARY KEY(book_id, author_id), 
  CONSTRAINT fk_book 
    FOREIGN KEY(book_id) 
    REFERENCES books(book_id) ON DELETE CASCADE, 
  CONSTRAINT fk_author 
    FOREIGN KEY(author_id) 
    REFERENCES authors(author_id) ON DELETE CASCADE
);

CREATE TABLE genres (
  genre_id  INT GENERATED BY DEFAULT AS IDENTITY NOT NULL,
  genre     VARCHAR(255) NOT NULL, 
  parent_id INT NULL, 
  PRIMARY KEY(genre_id),
  CONSTRAINT fk_parent 
    FOREIGN KEY(parent_id) REFERENCES genres(genre_id)
);

*/