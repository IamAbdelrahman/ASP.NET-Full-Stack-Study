/*
	The DBA creates privilage to Ahmed and Mary:-
	1) The DBA doesn't allow Mary to update the table of Departmetn.
	2) The DBA doesn't allow Mary and Ali to manipulate the table of Employee.
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
/********************************************************************************/

--1) 
REVOKE UPDATE ON TABLE Department FROM Mary;

--2)
REVOKE ALL ON TABLE Employee FROM Mary, Ali;

