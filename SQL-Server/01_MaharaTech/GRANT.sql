/*
	The DBA creates privilage to Ahmed and Mary:-
	1) The DBA allows Ahmed to only view the table of Employee.
	2) The DBA allows Mary and Ali to manipulate the table of Department.
	3) The DBA allows Ahmed to only view the table of Employee, and shares this grant with other users too.
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
GRANT SELECT ON TABLE Employee TO Ahmed;

--2)
GRANT ALL ON TABLE Department TO Mary, Ali;

--3)
GRANT SELECT ON TABLE Employee TO Ahmed WITH GRANT OPTION;