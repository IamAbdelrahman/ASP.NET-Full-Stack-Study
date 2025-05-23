/*
	Insert the full data of employee, department, and projects.
*/


-- Create the Employee table
CREATE TABLE Employee
(
    Fname VARCHAR(10),
    Lname VARCHAR(10), 
    SSN INT PRIMARY KEY, 
    Bdate VARCHAR(10),
    City VARCHAR(10), 
    Salary FLOAT, 
    SuperSSN INT,                         -- Foreign Key
    E_DNO INT,                            -- Foreign Key
);

-- Create the Department table
CREATE TABLE Department
(
    D_Name VARCHAR(10) NOT NULL,
    DNO INT PRIMARY KEY,
    MGRSSN INT,                           -- Foreign Key
    MGRStartDate VARCHAR(10)
);


-- Create the Projects table
CREATE TABLE Projects 
(
    PNO INT PRIMARY KEY, 
    P_Name VARCHAR(50) NOT NULL
);
/********************************************************************************/

INSERT INTO Employee VALUES ('Asmaa', 'Ali', 102661, 
'18-Oct-85', 'Cairo', 1200, NULL, 10);

INSERT INTO Employee VALUES ('Moheb', 'Rafaat', 102674,
'06-May-84', 'Tanta', 1700, 112233, 10);

INSERT INTO Employee VALUES ('Ahmad', 'Sameh', 102680,
'12-Dec-86', 'Alex', 1900, 223344, 10);

INSERT INTO Employee VALUES ('Maged', 'Raoot', 521634,
'04-Jun-80', 'Giza', 1000, 968574, 30);

INSERT INTO Employee VALUES ('Noha', 'Mohamed', 968574,
'02-Jan-75', 'Fayoum', 1600, 321654, 20);

INSERT INTO Department VALUES ('DP1', 10, 223344, '01-Jan-05');
INSERT INTO Department VALUES ('DP2', 20, 512463, '06-Jan-06');
INSERT INTO Department VALUES ('DP3', 30, 968574, '03-Jan-06');

INSERT INTO Projects VALUES (1, 'FaceBook');
INSERT INTO Projects VALUES (2, 'Twitter');